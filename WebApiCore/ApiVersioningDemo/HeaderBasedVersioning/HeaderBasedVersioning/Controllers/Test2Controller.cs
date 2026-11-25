using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeaderBasedVersioning.Controllers
{
    [Route("api/test")]
    [ApiController]
    [ApiVersion("2.0")]
    public class Test2Controller : ControllerBase
    {
        public Test2Controller()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This result is received from V2 API - Method: GET");
        }
    }
}
