using ColorsExperiment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColorsExperiment.Data.Context
{
    public class ColorsExperimentDbContext : DbContext
    {
        public ColorsExperimentDbContext(DbContextOptions<ColorsExperimentDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Experiment> Experiments { get; set; }
    }
}
