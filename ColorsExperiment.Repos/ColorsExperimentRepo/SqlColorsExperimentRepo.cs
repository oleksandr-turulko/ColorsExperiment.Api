using ColorsExperiment.Data.Context;
using ColorsExperiment.Repos.Abstract;

namespace ColorsExperiment.Repos.ColorsExperimentRepo
{
    public class SqlColorsExperimentRepo(ColorsExperimentDbContext context)
        : BaseRepo(context), IColorsExperimentRepo
    {

        private async Task<string> GetRandomColorCode()
        {

            return "";
        }

        public async Task<KeyValuePair<string, string>> GetButtonByDeviceToken(string deviceToken)
        {

            return new KeyValuePair<string, string>("key", "value");
        }
    }
}
