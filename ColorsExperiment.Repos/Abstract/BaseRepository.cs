using Experiments.Data.Context;

namespace Experiments.Repositories.Abstract
{
    public abstract class BaseRepository(ExperimentsDbContext context)
    {
        protected ExperimentsDbContext _db = context;
    }
}
