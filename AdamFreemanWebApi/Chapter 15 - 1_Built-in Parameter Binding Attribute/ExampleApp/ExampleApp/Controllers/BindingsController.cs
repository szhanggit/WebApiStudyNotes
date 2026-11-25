using System.Web.Http;
using ExampleApp.Models;
using System.Web.Http.ValueProviders;
using ExampleApp.Infrastructure;

namespace ExampleApp.Controllers {
    public class BindingsController : ApiController {
        private IRepository repo;

        public BindingsController(IRepository repoArg) {
            repo = repoArg;
        }

        /*
         Use value providers and value provider factories 
         when you want to bind parameter values from parts of the request 
         other than the URL or the body or from some other data source entirely.
             */
        [HttpGet]
        [HttpPost]
        public string SumNumbers(Numbers numbers, [ValueProvider(typeof(HeaderValueProviderFactory))] string Host) {
            return string.Format("{0} (Accept: {1})", numbers.First + numbers.Second, Host);
        }

        /*
         Post http://localhost:29844/api/bindings/sumnumbers
         Headers:   
         Content-Type       application/json
         Body(raw):         { "first": 2, "second": 5 } 
             */
    }
}
