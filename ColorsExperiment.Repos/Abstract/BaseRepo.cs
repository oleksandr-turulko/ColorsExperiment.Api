using Experiments.Data.Context;

namespace Experiments.Repos.Abstract
{
    public abstract class BaseRepo(ExperimentsDbContext context)
    {
        protected ExperimentsDbContext _db = context;
    }
}
