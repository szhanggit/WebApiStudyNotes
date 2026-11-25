using System.Web.Http;
using ExampleApp.Models;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ExampleApp.Controllers {
    public class BindingsController : ApiController {
        private IRepository repo;

        public BindingsController(IRepository repoArg) {
            repo = repoArg;
        }

        [HttpGet]
        [HttpPost]
        public int SumNumbers([FromBody] int number)//One object per request body.
        {
            return number * 2;
        }

    }
}
