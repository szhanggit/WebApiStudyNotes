using EmployeeService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace EmployeeService.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                bool IsAuth = RequestContext.Principal.Identity.IsAuthenticated; // Returns true or false depending on whether the user is authenticated
                string type = RequestContext.Principal.Identity.AuthenticationType; // Authentication Type used
                string UserName = RequestContext.Principal.Identity.Name; // Logged in username

                IsAuth = User.Identity.IsAuthenticated; // Returns true or false depending on whether the user is authenticated
                type = User.Identity.AuthenticationType; // Authentication Type used
                UserName = User.Identity.Name; // Logged in username

                return entities.Employees.ToList();
            }
        }
    }
}
