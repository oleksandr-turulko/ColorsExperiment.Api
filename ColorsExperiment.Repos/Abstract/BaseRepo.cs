using ColorsExperiment.Data.Context;

namespace ColorsExperiment.Repos.Abstract
{
    public abstract class BaseRepo(ColorsExperimentDbContext context)
    {
        protected ColorsExperimentDbContext _db = context;
    }
}
