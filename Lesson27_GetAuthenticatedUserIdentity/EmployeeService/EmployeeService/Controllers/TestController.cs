using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            bool IsAuth = RequestContext.Principal.Identity.IsAuthenticated; // Returns true or false depending on whether the user is authenticated
            string type = RequestContext.Principal.Identity.AuthenticationType; // Authentication Type used
            string UserName = RequestContext.Principal.Identity.Name; // Logged in username

            return "Hello from TestController";
        }
    }
}
