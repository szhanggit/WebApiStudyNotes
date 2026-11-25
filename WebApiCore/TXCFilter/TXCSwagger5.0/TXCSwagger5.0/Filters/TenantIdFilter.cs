using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TXCSwagger5._0.Models;

namespace TXCSwagger5._0.Filters
{
    public class TenantIdFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var TenantId = context.HttpContext?.Request?.Headers["TenantBasicInfoId"];

            if (string.IsNullOrEmpty(TenantId) || string.IsNullOrWhiteSpace(TenantId))

            {
                var response = Response.Fail<int>("TenantBasicInfoId header required", (int)HttpStatusCode.BadRequest);
                context.Result = new BadRequestObjectResult(response);
                return;
            }
        }
    }
}
