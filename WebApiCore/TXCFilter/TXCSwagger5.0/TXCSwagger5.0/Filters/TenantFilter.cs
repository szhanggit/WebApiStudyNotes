using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TXCSwagger5._0.Models;

namespace TXCSwagger5._0.Filters
{
    public class TenantFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var TenantName = context.HttpContext?.Request?.Headers["TenantName"];
            var TenantId = context.HttpContext?.Request?.Headers["TenantBasicInfoId"];

            if (string.IsNullOrEmpty(TenantId)
                || string.IsNullOrWhiteSpace(TenantId)
               )

            {
                var response = Response.Fail<int>("TenantBasicInfoId header required", (int)HttpStatusCode.BadRequest);
                context.Result = new BadRequestObjectResult(response);
                return;
            }

            if (string.IsNullOrEmpty(TenantName)
                || string.IsNullOrWhiteSpace(TenantName)
               )

            {
                var response = Response.Fail<int>("TenantName header required", (int)HttpStatusCode.BadRequest);
                context.Result = new BadRequestObjectResult(response);
                return;
            }
        }
    }
}
