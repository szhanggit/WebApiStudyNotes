using System.Web.Http;
using ExampleApp.Models;
using System.Web.Http.ValueProviders;
using ExampleApp.Infrastructure;
using System.Net.Http.Formatting;

namespace ExampleApp.Controllers {
    public class BindingsController : ApiController {
        private IRepository repo;

        public BindingsController(IRepository repoArg) {
            repo = repoArg;
        }

        [HttpGet]
        [HttpPost]
        public int SumNumbers(Numbers numbers)
        {
            var result = numbers.Op.Add ? numbers.First + numbers.Second : numbers.First - numbers.Second;
            return numbers.Op.Double ? result * 2 : result;
        }
        /*
         POST http://localhost:29844/api/bindings/sumnumbers
         Content-Type: application/x-www-form-urlencoded
         first=2&second=5&op.add=true&op.double=true
         */
    }
}
