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
        public int SumNumbers(Numbers calc)
        {
            return calc.First + calc.Second;
        }

        /*
         Get http://localhost:29844/api/bindings/sumnumbers?first=2&second=5
         Headers:   
         Content-Type       application/json
             */
    }
}
