using Experiments.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Experiments.Data.Context
{
    public class ExperimentsDbContext : DbContext
    {
        public ExperimentsDbContext(DbContextOptions<ExperimentsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Experiment> Experiments { get; set; }
    }
}
