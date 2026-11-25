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
        //public string SumNumbers([FromUri] Numbers numbers) {
        //    return string.Format("{0}", numbers.First + numbers.Second);
        //}
        public string SumNumbers([FromUri] Numbers numbers1, [FromUri] Numbers numbers2)
        {
            return string.Format("{0}", numbers1.First + numbers1.Second + numbers2.First + numbers2.Second);
        }

        /*
         Get http://localhost:29844/api/bindings/sumnumbers?numbers1.first=2&numbers1.second=5&numbers2.first=10&numbers2.second=100 
         Content-Type       application/json
         */
    }
}
