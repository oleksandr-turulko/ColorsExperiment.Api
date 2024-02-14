namespace Experiments.Repos.ExperimentsRepo
{
    public interface IExperimentsRepo
    {
        Task<KeyValuePair<string, string>> GetColorForDevice(string deviceToken);
        Task<KeyValuePair<string, decimal>> GetPriceForDevice(string deviceToken);
        Task<object> GetExperimentResults(string experimentKey);
    }
}
