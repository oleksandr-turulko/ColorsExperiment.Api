using Experiments.Data.Context;
using Experiments.Models.Dtos.Stats;
using Experiments.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Experiments.Repositories.Experiments
{
    public class SqlExperimentsRepository(ExperimentsDbContext context)
        : BaseRepository(context), IExperimentsRepository
    {

        private async Task<string> GetRandomColorCode()
        {
            var random = new Random();
            var colorSelector = random.NextDouble() * 100;

            return colorSelector switch
            {
                < 33.3 => "#FF0000",
                > 33.3 and < 66.6 => "#00FF00",
                _ => "#0000FF"
            };
        }
        private async Task<decimal> GetRandomPrice()
        {
            var random = new Random();
            var colorSelector = random.NextDouble() * 100;

            return colorSelector switch
            {
                < 5 => 50,
                > 5 and < 15 => 20,
                > 15 and < 25 => 5,
                _ => 10
            };
        }

        private async Task<KeyValuePair<string, string>> CreateNewColorExperiment(string deviceToken)
        {
            var randomColorCode = await GetRandomColorCode();
            try
            {
                await _db.Database.ExecuteSqlAsync($"INSERT INTO Experiments (Id, ExperimentKey,DeviceToken,Value) Values({Guid.NewGuid()},'button_color',{deviceToken},{randomColorCode})");

                return new KeyValuePair<string, string>("button_color", randomColorCode);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private async Task<KeyValuePair<string, decimal>> CreateNewPriceExperiment(string deviceToken)
        {
            var randomPrice = await GetRandomPrice();
            try
            {
                await _db.Database.ExecuteSqlAsync($"INSERT INTO Experiments (Id, ExperimentKey,DeviceToken,Value) Values({Guid.NewGuid()},'price',{deviceToken},{randomPrice})");

                return new KeyValuePair<string, decimal>("price", randomPrice);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<KeyValuePair<string, string>> GetColorForDevice(string deviceToken)
        {
            //does same device token exist for this experiment in db

            var experimentCase = _db.Experiments
                .FromSqlInterpolated(
                    $"SELECT * FROM [Experiments] WHERE [Experiments].[ExperimentKey] = 'button_color' and [Experiments].[DeviceToken] = {deviceToken}")
                .FirstOrDefault();
            // in case experiment doesn't exist create new
            if (experimentCase == null)
                return await CreateNewColorExperiment(deviceToken);

            return new KeyValuePair<string, string>(experimentCase.ExperimentKey, experimentCase.Value);
        }

        public async Task<KeyValuePair<string, decimal>> GetPriceForDevice(string deviceToken)
        {
            var experimentCase = _db.Experiments
                .FromSqlInterpolated($"SELECT * FROM [Experiments] WHERE [Experiments].[ExperimentKey] = 'price' and [Experiments].[DeviceToken] = {deviceToken}")
                .FirstOrDefault();

            if (experimentCase == null)
                return await CreateNewPriceExperiment(deviceToken);

            decimal.TryParse(experimentCase.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value);
            return new KeyValuePair<string, decimal>(experimentCase.ExperimentKey, Math.Round(value));
        }

        public async Task<object> GetExperimentResults(string experimentKey)
        => await _db.Experiments
                .Where(e => e.ExperimentKey == experimentKey)
                .GroupBy(e => e.Value)
                .Select(g => new
                {
                    ExperimentCase = g.Key,
                    DevicesCount = g.Count()
                })
                .Select(q => new GetExperimentStatsDto(q.ExperimentCase, q.DevicesCount))
                .ToListAsync();

    }
}
