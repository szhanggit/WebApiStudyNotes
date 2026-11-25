using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dispatch.Infrastructure;
using Dispatch.Models;

namespace Dispatch.Controllers {
    [Time]
    public class ProductsController : ApiController {
        private static List<Product> products = new List<Product> { 
                new Product {ProductID = 1, Name = "Kayak", Price = 275M },
                new Product {ProductID = 2, Name = "Lifejacket", Price = 48.95M },
                new Product {ProductID = 3, Name = "Soccer Ball", Price = 19.50M },
                new Product {ProductID = 4, Name = "Thinking Cap", Price = 16M },
            };
        
        public IEnumerable<Product> Get() {
            return products;
        }

        /*
         Get:   http://localhost:49412/api/Products
         Headers:   
         Content-Type       application/json
         */

        [LogErrors]
        public HttpResponseMessage Get(int id)
        {
            Product product = products.Where(x => x.ProductID == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                new HttpError
                {
                    Message = "No such data item",
                    MessageDetail = string.Format("No item ID {0} was found", id)
                });
            }
            return Request.CreateResponse(product);
        }

        public Product Post(Product product) {
            product.ProductID = products.Count + 1;
            products.Add(product);
            return product;
        }
    }
}