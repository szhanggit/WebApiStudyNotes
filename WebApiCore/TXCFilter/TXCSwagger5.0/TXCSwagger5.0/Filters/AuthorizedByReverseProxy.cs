using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using TXCSwagger5._0.Models;

namespace TXCSwagger5._0.Filters
{
    public class AuthorizedByReverseProxy : IAuthorizationFilter
    {
        private readonly string _key;
        private readonly string _key2;
        private readonly ITokenDecoder _tokenDecoder;
        public AuthorizedByReverseProxy(string key, string key2, ITokenDecoder tokenDecoder)
        {
            _key = key;
            _key2 = key2;
            _tokenDecoder = tokenDecoder;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string TheAcceptedKey = _key;
                var token = context.HttpContext.Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"];

                if (string.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token))
                {
                    context.Result = CreateFailedResult("Not Authenticated");
                    return;
                }

                string oid = _tokenDecoder.GetOid(token);

                if (string.IsNullOrEmpty(oid) || string.IsNullOrWhiteSpace(oid))
                {
                    context.Result = CreateFailedResult("Invalid Token");
                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Result = CreateFailedResult(ex.Message);
            }
        }

        private UnauthorizedObjectResult CreateFailedResult(string message)
        {
            var mess = message ?? "Unauthorized";
            var data = Response.Fail<string>(mess, null);
            var unAuthresponse = JsonConvert.SerializeObject(data);
            UnauthorizedObjectResult result = new UnauthorizedObjectResult(unAuthresponse);
            return result;
        }
    }

    public class CheckRoleInEndpoint : TypeFilterAttribute
    {
        public CheckRoleInEndpoint(string key, string key2)
            : base(typeof(AuthorizedByReverseProxy))
        {
            Arguments = new object[] { key, key2 };

        }
    }
}
