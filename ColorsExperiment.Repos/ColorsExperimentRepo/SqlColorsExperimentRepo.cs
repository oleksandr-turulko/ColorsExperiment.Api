using ColorsExperiment.Data.Context;
using ColorsExperiment.Repos.Abstract;

namespace ColorsExperiment.Repos.ColorsExperimentRepo
{
    public class SqlColorsExperimentRepo(ColorsExperimentDbContext context)
        : BaseRepo(context), IColorsExperimentRepo
    {



    }
}
