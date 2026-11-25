using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiExceptionHandlingDemo.Models;

namespace WebApiExceptionHandlingDemo.Middleware
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _hostingEnv;
        private readonly ILogger<GlobalErrorHandlerMiddleware> _logger;
        public GlobalErrorHandlerMiddleware(RequestDelegate next, IHostEnvironment hostingEnv, ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            _next = next;
            _hostingEnv = hostingEnv;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                var errMessage = "Internal Server Error";
                response.ContentType = "application/json";

                _logger.LogError(error, "Unhandled Error");

                switch (error)
                {
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                if (!_hostingEnv.EnvironmentName.Equals("Production"))
                    errMessage = error.Message;

                var result = JsonSerializer.Serialize(new Response<string>() { Success = false, Message = errMessage });
                await response.WriteAsync(result);
            }
        }
    }
}
