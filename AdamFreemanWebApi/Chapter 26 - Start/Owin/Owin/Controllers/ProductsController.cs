using Owin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Owin.Controllers
{
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> GetProducts()
        {
            return Repository.Current.Products;
        }
        /*
             Get:   http://localhost:5000/api/products
             Headers:   
             Content-Type       application/json
         */

        public Product GetProduct(int id)
        {
            return Repository.Current.Products.Where(p => p.ProductID == id).FirstOrDefault();
        }

        public Product PostProduct(Product product)
        {
            return Repository.Current.SaveProduct(product);
        }

        public Product DeleteProduct(int id)
        {
            return Repository.Current.DeleteProduct(id);
        }
    }
}
