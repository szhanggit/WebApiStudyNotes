using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace ExampleApp.Infrastructure {

    /*
     The job of the factory is to examine the HttpActionContext object and 
     decide whether the value provider it is responsible for can be used to bind values for the current request.
         */
    public class HeaderValueProviderFactory : ValueProviderFactory {
        public override IValueProvider GetValueProvider(HttpActionContext context) {
            if (context.Request.Method == HttpMethod.Post) {
                return new HeaderValueProvider(new HeadersMap(context.Request.Headers));
            } else {
                return null;
            }
        }
    }
}
