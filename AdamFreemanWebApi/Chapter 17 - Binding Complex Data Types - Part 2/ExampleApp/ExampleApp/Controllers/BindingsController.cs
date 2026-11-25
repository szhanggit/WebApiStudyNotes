using System.Web.Http;
using System.Web.Http.ModelBinding;
using ExampleApp.Models;
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
        public int SumNumbers(Numbers numbers) {
            var result = numbers.Op.Add ? numbers.First + numbers.Second
                : numbers.First - numbers.Second;
            return numbers.Op.Double ? result * 2 : result;
        }
        /*
         POST http://localhost:29844/api/bindings/sumnumbers 
         Content-Type       application/xml
         Body(raw)          <Numbers><First>2</First><Op><Add>true</Add><Double>true</Double></Op><Second>5</Second></Numbers>
         */
    }
}
