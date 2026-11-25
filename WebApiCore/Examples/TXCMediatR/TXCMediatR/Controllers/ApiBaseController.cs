using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TXCMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly int _tenantId;
        protected readonly IMediator mediator;
        public ApiBaseController(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            var tenantIdStr = httpContextAccessor.HttpContext?.Request?.Headers["TenantId"];
            _tenantId = string.IsNullOrWhiteSpace(tenantIdStr) ? 0 : int.Parse(tenantIdStr);
            this.mediator = mediator;
        }
    }
}
