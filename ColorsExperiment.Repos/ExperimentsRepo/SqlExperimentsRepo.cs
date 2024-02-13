using Experiments.Data.Context;
using Experiments.Repos.Abstract;

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

        private async Task<KeyValuePair<string, string>> CreateNewExperiment()
        {
            var createProcedure = $"";

            return new KeyValuePair<string, string>();
        }

        public async Task<KeyValuePair<string, string>> GetColorForDevice(string deviceToken)
        {
            //does same device token exist in db
            var experimentCase = await _db.Experiments.FindAsync(deviceToken);

            if (experimentCase == null)
                return await CreateNewExperiment();

            return new KeyValuePair<string, string>("key", "value");
        }
    }
}
