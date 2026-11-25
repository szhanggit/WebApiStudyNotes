using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVersioningDemo.Controllers
{
    [ApiController]
    [ApiVersion("1.0")] //default version can be set at controller
    [Route("api/test")]
    //[Route("api/{v:apiVersion}/test")] //For URL based routing
    public class Test1Controller : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This result is received from V1 API");
        }
    }




    /*public class Test1Controller : Controller
    {
        [HttpGet]
        //[Route("get")] //set route at action level. This will be executed if 1.0 as version passed OR no verion passed
        public IActionResult Get()
        {
            return Ok("This result is received from V1 API - Method: GET");
        }

        [HttpPost]
        [Route("get")] //set route at action level. This will be executed if 1.0 as version passed OR no verion passed
        public IActionResult Post(Student student)
        {
            return Ok("This result is received from V1 API - Method: POST - name = " + student.Name);
        }

        [HttpGet]
        [ApiVersion("2.0")]
        [Route("get")] //set route at action level. This will be executed if verion passed explicitly and GET method used
        public IActionResult GetV2()
        {
            return Ok("This result is received from V2 API - Method: GET");
        }

        [HttpPost]
        [ApiVersion("2.0")]
        [Route("get")] //set route at action level. This will be executed if verion passed explicitly and POST method used
        public IActionResult PostV2(Student student)
        {
            return Ok("This result is received from V2 API - Method: POST - name = " + student.Name);
        }
    }*/

    public class Student {
        public string Name { get; set; }
    }
}
