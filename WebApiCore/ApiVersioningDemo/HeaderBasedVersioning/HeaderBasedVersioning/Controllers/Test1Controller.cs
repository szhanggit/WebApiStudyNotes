using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeaderBasedVersioning.Controllers
{
    [Route("api/test")]
    [ApiController]
    [ApiVersion("1.0")] //default version can be set at controller
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

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("post")] //set route at action level. This will be executed if 1.0 as version passed OR no verion passed
        public IActionResult Post(Student student)
        {
            return Ok("This result is received from V1 API - name = " + student.Name);
        }

        [HttpPost]
        [ApiVersion("2.0")]
        [Route("post")] //set route at action level. This will be executed if verion passed explicitly and POST method used
        public IActionResult PostV2(Student student)
        {
            return Ok("This result is received from V2 API - name = " + student.Name);
        }
    }
}
