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
        public int SumNumbers([FromUri] Numbers calc, [FromUri] Operation op)//One object per request body.
        {
            int result = op.Add ? calc.First + calc.Second : calc.First - calc.Second;
            return op.Double ? result * 2 : result;
        }

        /*
         Get http://localhost:29844/api/bindings/sumnumbers?first=2&second=5&add=true&double=false
         Headers:   
         Content-Type       application/json
         Body(raw):         { "first": 2, "second": 5, "add": true, "double": false }
             */
    }
}
