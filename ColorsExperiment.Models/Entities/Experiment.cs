namespace ColorsExperiment.Models.Entities
{
    public class Experiment
    {
        public Guid Id { get; set; }
        public string ClientExperimentKey { get; set; }
        public string Value { get; set; }
    }
}
