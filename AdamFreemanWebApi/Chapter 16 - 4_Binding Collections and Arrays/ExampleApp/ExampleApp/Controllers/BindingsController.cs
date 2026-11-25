using System.Web.Http;
using ExampleApp.Models;
using System.Web.Http.ValueProviders;
using ExampleApp.Infrastructure;
using System.Web.Http.ModelBinding;
using System.Linq;
using System.Collections.Generic;

namespace ExampleApp.Controllers {
    public class BindingsController : ApiController {
        private IRepository repo;

        public BindingsController(IRepository repoArg) {
            repo = repoArg;
        }

        /*
         /api/bindings/sumnumbers?numbers[]=2&numbers[]=5&numbers[]=100
         /api/bindings/sumnumbers?numbers=2&numbers=5&numbers=100
             */
        /*
         Use value providers and value provider factories 
         when you want to bind parameter values from parts of the request 
         other than the URL or the body or from some other data source entirely.
             */
        [HttpGet]
        [HttpPost]
        //public string SumNumbers([ModelBinder] int[] numbers)
        //{
        //    return numbers.Sum().ToString();
        //}
        //public string SumNumbers([ModelBinder] List<int> numbers) {
        //    return numbers.Sum().ToString();
        //}
        public string SumNumbers([ModelBinder] IEnumerable<int> numbers)
        {
            return numbers.Sum().ToString();
        }

        /*
         GET http://localhost:29844/api/bindings/sumnumbers?numbers=2&numbers=5&numbers=100 
         Content-Type       application/json
         */
    }
}
