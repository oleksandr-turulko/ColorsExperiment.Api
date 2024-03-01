namespace Experiments.Repositories.Experiments
{
    public interface IExperimentsRepository
    {
        Task<KeyValuePair<string, string>> GetColorForDevice(string deviceToken);
        Task<KeyValuePair<string, decimal>> GetPriceForDevice(string deviceToken);
        Task<object> GetExperimentResults(string experimentKey);
    }
}
