using AutoCompleteServer.AutoCompleteServer.Lib;
using AutoCompleteServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AutoCompleteServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        public LoginController()
        {

        }

        /*
            Post:	http://localhost:56871/api/Login/
            Body	->	raw	(JSON)
            {"UserName":"zyd","Password":"62044902"}
            Headers
            Content-Type:application/json         
         */
        [HttpPost]
        public IHttpActionResult Post([FromBody] Login login)
        {
            return Json(true);
        }
    }
}
