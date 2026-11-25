using System.Collections.Generic;
using System.Web.Http;
using ExampleApp.Models;
using System.Net;
using System.Net.Http;
using ExampleApp.Infrastructure;

namespace ExampleApp.Controllers {
    public class ProductsController : ApiController {
        IRepository repo;

        public ProductsController(IRepository repoImpl) {
            repo = repoImpl;
        }

        public IEnumerable<Product> GetAll() {
            return repo.Products;
        }

        /*
         Get:   http://localhost:29844/api/products
         Headers:   
         Content-Type       application/json
         */

        public IHttpActionResult Delete(int id)
        {
            repo.DeleteProduct(id);
            //return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
            return new NoContentResult();
        }

        /*
         Delete:   http://localhost:29844/api/products/1
         Headers:   
         Content-Type       application/json
         */

        [HttpGet]
        [Route("api/products/noop")]
        public IHttpActionResult NoOp()
        {
            return Ok();
        }

        /*
         Get:   http://localhost:29844/api/products/noop
         Headers:   
         Content-Type       application/json
         */

        /*
            BadRequest() 
            BadRequest(message) 
            BadRequest(modelstate)
            Conflict() 
            Content(status, data) 
            CreatedAtRoute(name, vals, data) 
            InternalServerError() 
            InternelServerError(exception) 
            NotFound() 
            Ok() 
            Ok(data) 
            Redirect(target) 
            RedirectToRoute(name, props)
            ResponseMessage(message)
            StatusCode(code)
            Unauthorized(headers)
         */
    }
}
