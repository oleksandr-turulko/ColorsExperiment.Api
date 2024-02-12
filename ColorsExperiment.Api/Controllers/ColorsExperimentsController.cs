using ColorsExperiment.Repos.ColorsExperimentRepo;
using Microsoft.AspNetCore.Mvc;

namespace ColorsExperiment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorsExperimentsController : ControllerBase
    {
        private readonly IColorsExperimentRepo _colorsRepo;

        public ColorsExperimentsController(IColorsExperimentRepo colorsRepo)
        {
            _colorsRepo = colorsRepo;
        }


        [HttpGet("button-color")]
        public async Task<ActionResult> Get(string deviceToken)
        {
            var result = await _colorsRepo.GetButtonByDeviceToken(deviceToken);
            return Ok();
        }
    }
}
