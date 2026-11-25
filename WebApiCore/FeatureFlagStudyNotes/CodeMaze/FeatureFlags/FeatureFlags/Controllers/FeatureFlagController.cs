using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureFlags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureFlagController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;
        public FeatureFlagController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [FeatureGate("BooleanFilter")]
        [HttpGet("BooleanFilter")]
        public async Task<IActionResult> BooleanFilter()
        {
            //if (await _featureManager.IsEnabledAsync("BooleanFilter"))
            //{
            //    return Ok("Feature enabled");
            //}
            //else
            //{
            //    return BadRequest("Feature not enabled");
            //}
            return Ok(1);
        }

        [HttpGet("PercentageFilter")]
        public async Task<IActionResult> PercentageFilter()
        {
            if (await _featureManager.IsEnabledAsync("PercentageFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }

        [HttpGet("CustomFilter")]
        public async Task<IActionResult> CustomFilter()
        {
            if (await _featureManager.IsEnabledAsync("CustomFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }

        [HttpGet("TimeWindowFilter")]
        public async Task<IActionResult> TimeWindowFilter()
        {
            if (await _featureManager.IsEnabledAsync("TimeWindowFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }
    }
}
