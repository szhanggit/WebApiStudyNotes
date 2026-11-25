using jwttxc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace jwttxc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayKeyValidateController : ControllerBase
    {
        private IJwtAuth _jwtAuth;
        public GatewayKeyValidateController(IJwtAuth jwtAuth)
        {
            _jwtAuth = jwtAuth;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GatewayValidateKey command, CancellationToken cancellationToken)
        {            
            string StrToken = _jwtAuth.Authentication();
            if (!string.IsNullOrEmpty(StrToken))
            {
                return Ok(StrToken);
            }
            else
            {
                return Unauthorized(StrToken);
            }
        }

        [HttpPost("GetAsymmetricToken")]
        public async Task<IActionResult> AT(GatewayValidateKey command, CancellationToken cancellationToken)
        {
            string StrToken = _jwtAuth.AuthenticationV2();
            if (!string.IsNullOrEmpty(StrToken))
            {
                return Ok(StrToken);
            }
            else
            {
                return Unauthorized(StrToken);
            }
        }
    }
}
