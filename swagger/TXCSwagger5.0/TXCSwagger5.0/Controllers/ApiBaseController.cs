using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace TXCSwagger5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly int _tenantId;
        public ApiBaseController(IHttpContextAccessor httpContextAccessor)
        {
            //var tenantIdStr = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            //_tenantId = string.IsNullOrWhiteSpace(tenantIdStr) ? 0 : int.Parse(tenantIdStr);
        }

        internal string FlattenModelStateErrorMessage()
        {
            return string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
        }

        internal int GetUserIdClaim()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userId = identity.FindFirst(ClaimTypes.Sid)?.Value;

                if (!string.IsNullOrEmpty(userId))
                    return int.Parse(userId);
            }

            return 0;
        }
    }
}
