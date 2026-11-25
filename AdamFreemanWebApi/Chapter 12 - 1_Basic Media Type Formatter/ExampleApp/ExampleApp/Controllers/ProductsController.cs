using System.Collections.Generic;
using System.Web.Http;
using ExampleApp.Models;

namespace ExampleApp.Controllers {
    public class ProductsController : ApiController {
        IRepository repo;

        public ProductsController(IRepository repoImpl) {
            repo = repoImpl;
        }

        /*
         Attention:
         http://localhost:29844/api/products
         Use GET
         Set Header:
         Accept         application/x.product
             */
        public IEnumerable<Product> GetAll() {
            return repo.Products;
        }

        public void Delete(int id) {
            repo.DeleteProduct(id);
        }

        /*
         Delete:   http://localhost:29844/api/products/1
         Headers:   
         Content-Type       application/json
         */
    }
}
