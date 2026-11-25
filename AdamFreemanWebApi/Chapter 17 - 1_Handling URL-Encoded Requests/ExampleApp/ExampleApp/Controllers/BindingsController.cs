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
        public IHttpActionResult SumNumbers(FormDataCollection numbers)
        {
            int first, second;
            bool add, doubleVal;
            if (int.TryParse(numbers["first"], out first)
            && int.TryParse(numbers["second"], out second)
            && bool.TryParse(numbers["add"], out add)
            && bool.TryParse(numbers["double"], out doubleVal))
            {
                int result = add ? first + second : first - second;
                return Ok(string.Format("{0}", doubleVal ? result * 2 : result));
            }
            else
            {
                return BadRequest();
            }
        }
        /*
         POST http://localhost:29844/api/bindings/sumnumbers
         Content-Type       application/x-www-form-urlencoded
         Body(raw):         first=2&second=5&add=true&double=true 
         */
    }
}
