namespace ColorsExperiment.Repos.ColorsExperimentRepo
{
    public interface IColorsExperimentRepo
    {
        Task<KeyValuePair<string, string>> GetButtonByDeviceToken(string deviceToken);
    }
}
