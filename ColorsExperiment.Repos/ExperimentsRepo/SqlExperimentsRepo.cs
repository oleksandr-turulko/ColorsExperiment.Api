using Experiments.Data.Context;
using Experiments.Models.Entities;
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

        public async Task<KeyValuePair<string, string>> GetColorForDeviceToken(string deviceToken)
        {
            //does same device token exist in db
            var experimentCase = await _db.Experiments.FindAsync(deviceToken);

            if (experimentCase == null)
            {
                //create new 
                var newExperiment = new Experiment
                {
                    Id = Guid.NewGuid(),
                    ExperimentKey = ""
                };
                //and return
            }

            //return 

            return new KeyValuePair<string, string>("key", "value");
        }

        public Task<KeyValuePair<string, decimal>> GetPriceForDeviceToken(string deviceToken)
        {
            throw new NotImplementedException();
        }
    }
}
