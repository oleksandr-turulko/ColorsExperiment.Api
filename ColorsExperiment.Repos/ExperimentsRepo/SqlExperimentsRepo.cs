using Experiments.Data.Context;
using Experiments.Repos.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Experiments.Repos.ExperimentsRepo
{
    public class SqlExperimentsRepo(ExperimentsDbContext context)
        : BaseRepo(context), IExperimentsRepo
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

        private async Task<KeyValuePair<string, string>> CreateNewExperiment(string deviceToken)
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

        public async Task<KeyValuePair<string, string>> GetColorForDevice(string deviceToken)
        {
            //does same device token exist fror this experiment in db

            var experimentCase = _db.Experiments
                .FromSqlInterpolated($"SELECT * FROM [Experiments] WHERE [Experiments].[ExperimentKey] = 'button_color' and [Experiments].[DeviceToken] = {deviceToken}")
                .FirstOrDefault();
            // in case if doesn't create new
            if (experimentCase == null)
                return await CreateNewExperiment(deviceToken);

            return new KeyValuePair<string, string>(experimentCase.ExperimentKey, experimentCase.Value);
        }
    }
}
