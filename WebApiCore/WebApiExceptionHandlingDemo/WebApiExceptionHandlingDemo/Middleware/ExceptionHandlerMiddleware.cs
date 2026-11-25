using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using WebApiExceptionHandlingDemo.Models;

namespace WebApiExceptionHandlingDemo.Middleware
{
    ///***
    /// <summary>
    /// This middleware created is created to intercepts the requests 
    /// and to handle the exceptions occurred while processing the request. 
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestProcessor;

        public ExceptionHandlerMiddleware(RequestDelegate requestProcessor)
        {
            _requestProcessor = requestProcessor;
        }

        ///***
        /// <summary>
        /// This method invokes the request depegate. 
        /// Request delegate is wrapped inside try-catch block to handle exceptions.
        /// </summary>
        /// <param name="httpContext">It is httpContext instance.</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestProcessor(httpContext);
            }
            catch (Exception ex)
            {
                ///***
                ///This is the place where exception logs can be written.
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        ///***
        /// <summary>
        /// This method writes exception details in response.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var exMessage = exception switch
            {
                XmlException => "XmlException occurred while processing request.",
                _ => "Internal server error occurred while processing request."
            };

            await context.Response.WriteAsync(new ErrorInfo()
            {
                StatusCode = context.Response.StatusCode,
                Message = exMessage,
                ExceptionDetails = exception.ToString()
            }.ToString()); ;
        }

    }
}
