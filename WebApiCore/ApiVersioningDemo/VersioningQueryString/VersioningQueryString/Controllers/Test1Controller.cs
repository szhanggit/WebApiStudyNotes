using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VersioningQueryString.Controllers
{
    [Route("api/test")]
    [ApiVersion("1.0")] //default version can be set at controller
    [ApiController]
    public class Test1Controller : ControllerBase
    {
        public Test1Controller()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This result is received from V1 API");
        }
    }
}
