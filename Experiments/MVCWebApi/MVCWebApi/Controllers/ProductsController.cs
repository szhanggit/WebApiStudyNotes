using MVCWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        Repository repo;
        public ProductsController()
        {
            repo = Repository.Current;
        }

        /*http://localhost:63986/api/products*/
        public IEnumerable<Product> GetAll()
        {
            return repo.Products;
        }
    }
}
