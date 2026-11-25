using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using System.Web.Http.Controllers;

namespace ExampleApp.Infrastructure {
    public class FromHeaderAttribute : ModelBinderAttribute {
        public override IEnumerable<ValueProviderFactory> GetValueProviderFactories(HttpConfiguration configuration) {
            return new ValueProviderFactory[] { new HeaderValueProviderFactory() }; 
        }
    }
}
