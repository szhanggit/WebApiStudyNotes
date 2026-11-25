using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Dispatch.Infrastructure
{
    public class CustomExceptionAttribute : Attribute, IExceptionFilter
    {
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext
        actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null
            && actionExecutedContext.Exception is ArgumentOutOfRangeException)
            {
                actionExecutedContext.Response =
                actionExecutedContext.Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, "No data item");
            }
            return Task.FromResult<object>(null);
        }
        public bool AllowMultiple
        {
            get { return true; }
        }
    }
}