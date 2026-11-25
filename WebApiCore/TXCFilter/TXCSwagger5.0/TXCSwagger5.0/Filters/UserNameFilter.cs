using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TXCSwagger5._0.Models;

namespace TXCSwagger5._0.Filters
{
    public class UserNameFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userName = context.HttpContext?.Request?.Headers["TX2UserName"];

            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))

            {
                var response = Response.Fail<int>("Username not found", (int)HttpStatusCode.BadRequest);
                context.Result = new BadRequestObjectResult(response);
                return;
            }
        }
    }
}
