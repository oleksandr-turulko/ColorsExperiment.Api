namespace Experiments.Repos.ExperimentsRepo
{
    public interface IExperimentsRepo
    {
        Task<KeyValuePair<string, string>> GetColorForDeviceToken(string deviceToken);
        Task<KeyValuePair<string, decimal>> GetPriceForDeviceToken(string deviceToken);
    }
}
