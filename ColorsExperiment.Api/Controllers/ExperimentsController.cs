using Experiments.Repos.ExperimentsRepo;
using Microsoft.AspNetCore.Mvc;

namespace Experiments.Api.Controllers
{
    [ApiController]
    [Route("experiment")]
    public class ExperimentsController : ControllerBase
    {
        private readonly IExperimentsRepo _experimentsRepo;

        public ExperimentsController(IExperimentsRepo experimentsRepo)
        {
            _experimentsRepo = experimentsRepo;
        }


        [HttpGet("button-color")]
        public async Task<IActionResult> GetButtonColorExperiment(string deviceToken)
            => Ok(await _experimentsRepo.GetColorForDevice(deviceToken));
    }
}
