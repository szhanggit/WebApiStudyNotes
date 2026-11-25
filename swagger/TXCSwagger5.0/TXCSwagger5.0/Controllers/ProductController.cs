using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using TXCSwagger5._0.Models;
using TXCSwagger5._0.Filters;
using System;

/*
 https://stackoverflow.com/questions/41493130/web-api-how-to-add-a-header-parameter-for-all-api-in-swagger
 */
namespace TXCSwagger5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiBaseController
    {
        private readonly int _tenantId;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        [ServiceFilter(typeof(TenantFilter))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpirySchemeByProductIdQuery request, CancellationToken cancellationToken)
        {
            int _TenantId = default(int);
            string _TX2UserName = _httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
            string _TenantName = _httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            Int32.TryParse(_httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"], out _TenantId);
            return Ok(1);
        }
    }
}
