using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVersioningDemo.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/test")]
    //[Route("api/{v:apiVersion}/test")] //For URL based routing
    public class Test2Controller : Controller
    {
        [HttpGet]
        //[Route("get")]
        public IActionResult Get()
        {
            return Ok("This result is received from V3 API - Method: GET");
        }
    }
}
