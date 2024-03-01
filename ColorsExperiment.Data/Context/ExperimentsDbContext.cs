using Experiments.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Experiments.Data.Context
{
    public class ExperimentsDbContext : DbContext
    {
        public DbSet<Experiment> Experiments { get; set; }

        public ExperimentsDbContext(DbContextOptions<ExperimentsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
