using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelStateTry_2022.Models;

namespace ModelStateTry_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//It makes auto validaton. Disalbe it to make mnaul validation.
    public class BooksController : ControllerBase
    {
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Post([FromBody] CreateBookInputModel createBookInputModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return UnprocessableEntity(ModelState);
            //}

            return Ok(createBookInputModel);
        }
    }
}
