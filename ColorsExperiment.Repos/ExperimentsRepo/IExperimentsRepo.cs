namespace Experiments.Repos.ExperimentsRepo
{
    public interface IExperimentsRepo
    {
        Task<KeyValuePair<string, string>> GetColorForDevice(string deviceToken);
    }
}
