using System.Web.Http;
using ExampleApp.Models;
using System.Web.Http.ValueProviders;
using ExampleApp.Infrastructure;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;

namespace ExampleApp.Controllers {
    public class BindingsController : ApiController {
        private IRepository repo;

        public BindingsController(IRepository repoArg) {
            repo = repoArg;
        }

        [HttpGet]
        [HttpPost]
        public int SumNumbers(JObject jData)
        {
            Numbers numbers = new Numbers((int)jData["first"], (int)jData["second"])
            {
                Op = new Operation
                {
                    Add = (bool)jData["op"]["add"],
                    Double = (bool)jData["op"]["double"]
                }
            };
            var result = numbers.Op.Add ? numbers.First + numbers.Second : numbers.First - numbers.Second;
            return numbers.Op.Double ? result * 2 : result;
        }

        /*
         POST http://localhost:29844/api/bindings/sumnumbers
         Content-Type       application/json
         Body(raw):         {"first":2,"second":5,"op":{"add":true,"double":true}} 
         */
    }
}
