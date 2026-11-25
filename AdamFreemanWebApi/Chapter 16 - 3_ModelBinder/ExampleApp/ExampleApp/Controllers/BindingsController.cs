using System.Web.Http;
using ExampleApp.Models;
using System.Web.Http.ValueProviders;
using ExampleApp.Infrastructure;
using System.Web.Http.ModelBinding;

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
        //public string SumNumbers([FromUri] Numbers numbers) {
        //    return string.Format("{0}", numbers.First + numbers.Second);
        //}
        public string SumNumbers([ModelBinder] Numbers numbers)
        {
            var result = numbers.Op.Add ? numbers.First + numbers.Second : numbers.First - numbers.Second;
            return string.Format("{0} (Accept:{1})", numbers.Op.Double ? result * 2 : result, numbers.Accept);
        }
        /*
         GET http://localhost:29844/api/bindings/sumnumbers?numbers.first=2&numbers.second=5&numbers.op.add=true&numbers.op.double=true 
         Content-Type       application/json
         */
    }
}
