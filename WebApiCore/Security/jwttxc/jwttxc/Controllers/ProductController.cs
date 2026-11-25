using jwttxc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace jwttxc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }

        /*
        https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-3.1#authentication-scheme
        https://learn.microsoft.com/en-us/aspnet/core/security/authorization/limitingidentitybyscheme?view=aspnetcore-3.1
        https://stackoverflow.com/questions/62322812/using-multiple-authentication-schemes-in-asp-net-core-3-1
         */
        [Authorize(AuthenticationSchemes = AuthenticationConstants.AllAuthScheme)]
        [MyAuthorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpirySchemeByProductId request, CancellationToken cancellationToken)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var UserName = identity.FindFirst("UserName")?.Value;
            }
            return Ok(1);
        }
    }
}
