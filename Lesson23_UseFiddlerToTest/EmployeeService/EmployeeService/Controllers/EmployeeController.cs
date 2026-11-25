using EmployeeService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                return entities.Employees.ToList();
            }
        }
    }
}
