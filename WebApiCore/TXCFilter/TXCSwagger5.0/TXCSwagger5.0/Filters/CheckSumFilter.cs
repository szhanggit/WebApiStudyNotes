using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using TXC.Common.Security;
using TXCSwagger5._0.Models;

namespace TXCSwagger5._0.Filters
{
    public class CheckSumFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string checkSum = context.HttpContext?.Request?.Headers["checksum"];

                if (string.IsNullOrEmpty(checkSum) || string.IsNullOrWhiteSpace(checkSum))
                {
                    var response = Response.Fail<int>("Check sum header not found", (int)HttpStatusCode.BadRequest);
                    context.Result = new BadRequestObjectResult(response);
                    return;
                }

                if (!checkSum.Contains('-'))
                {
                    var response = Response.Fail<int>("Invalid check sum format", (int)HttpStatusCode.BadRequest);
                    context.Result = new BadRequestObjectResult(response);
                    return;
                }

                string[] splitChecksum = checkSum.Split('-', 3);

                if (string.IsNullOrEmpty(splitChecksum[0]) ||
                     string.IsNullOrWhiteSpace(splitChecksum[0]) ||
                     string.IsNullOrEmpty(splitChecksum[1]) ||
                     string.IsNullOrWhiteSpace(splitChecksum[1]) ||
                     string.IsNullOrEmpty(splitChecksum[2]) ||
                     string.IsNullOrWhiteSpace(splitChecksum[2])
                  )
                {
                    var response = Response.Fail<int>("Invalid check sum format", (int)HttpStatusCode.BadRequest);
                    context.Result = new BadRequestObjectResult(response);
                    return;
                }

                var hashedChecsum = Hash.ComputeSha256Hash($"{splitChecksum[0]}{splitChecksum[1]}");

                if (!hashedChecsum.Equals(splitChecksum[2]))
                {
                    var response = Response.Fail<int>("Invalid check sum", (int)HttpStatusCode.BadRequest);
                    context.Result = new BadRequestObjectResult(response);
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
