using System.Collections.Generic;
using System.Web.Http;
using ExampleApp.Models;

namespace ExampleApp.Controllers
{
    public class ProductsController : ApiController
    {
        IRepository repo;
        public ProductsController(IRepository repoImpl)
        {
            repo = repoImpl;
        }

        /*http://localhost:29844/api/products*/
        public IEnumerable<Product> GetAll()
        {
            return repo.Products;
        }
        /*
         Get:   http://localhost:29844/api/products
         Headers:   
         Content-Type       application/json
         */
    }
}
