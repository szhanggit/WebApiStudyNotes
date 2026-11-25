using jwtex0.Entities;
using jwtex0.Helpers;
using jwtex0.Models;
using jwtex0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwtex0.Controllers
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
        [HttpGet]
        public IActionResult GetAll()
        {
            var _user = (User)_httpContextAccessor.HttpContext.Items["User"];
            string _authToken = _httpContextAccessor.HttpContext?.Request?.Headers["AuthToken"];
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
