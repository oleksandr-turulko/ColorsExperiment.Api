namespace Experiments.Models.Dtos.Stats
{
    public class GetExperimentStatsDto(string experimentCase, int devicesCount)
    {
        public string ExperimentCase { get; set; } = experimentCase;
        public int DevicesCount { get; set; } = devicesCount;
    }
}
