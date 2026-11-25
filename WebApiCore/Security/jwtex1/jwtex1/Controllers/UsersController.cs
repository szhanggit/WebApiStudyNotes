using jwtex1.Entities;
using jwtex1.Helpers;
using jwtex1.Models;
using jwtex1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = jwtex1.Helpers.AuthorizeAttribute;

namespace jwtex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this._userService = userService;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetUsers")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
