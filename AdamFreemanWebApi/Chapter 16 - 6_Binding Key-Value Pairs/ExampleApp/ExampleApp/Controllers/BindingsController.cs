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
            /api/bindings/sumnumbers?numbers[0][key]=one&numbers[0][value][first]=2
            &numbers[0][value][second]=52&numbers[1][key]=two&numbers[1][value][first]=100
            &numbers[1][value][second]=200
             */
        /*
         Use value providers and value provider factories 
         when you want to bind parameter values from parts of the request 
         other than the URL or the body or from some other data source entirely.
             */
        [HttpGet]
        [HttpPost]
        public string SumNumbers([ModelBinder] Dictionary<string, Numbers> numbers)
        {
            return numbers.Select(x => x.Value.First + x.Value.Second).Sum().ToString();
        }
    }
}
