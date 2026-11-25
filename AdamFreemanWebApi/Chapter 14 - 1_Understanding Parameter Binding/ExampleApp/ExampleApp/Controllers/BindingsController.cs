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

        /*
         http://localhost:29844/api/bindings/sumnumbers?first=2&second=5
             */
        [HttpGet]
        [HttpPost]
        public int SumNumbers(int first, int second) {
            return first + second;
        }
    }
}
