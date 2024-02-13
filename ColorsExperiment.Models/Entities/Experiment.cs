using System.ComponentModel.DataAnnotations;

namespace Experiments.Models.Entities
{
    public class Experiment
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string ExperimentKey { get; set; }
        [MaxLength(10)]
        public string DeviceToken { get; set; }
        [MaxLength(6)]
        public string Value { get; set; }
    }
}
