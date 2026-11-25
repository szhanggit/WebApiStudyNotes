using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using TXCSwagger5._0.Models;

namespace TXCSwagger5._0.Filters
{
    public class ModelValidationResultFilter : IActionFilter
    {
        //private readonly ITelemetryLogTrace<ModelValidationResultFilter> _telemetry;

        public ModelValidationResultFilter(
            //ITelemetryLogTrace<ModelValidationResultFilter> telemetry
            )
        {
            //_telemetry = telemetry;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState.Values
                    .Where(x => x.ValidationState == ModelValidationState.Invalid)
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage.Replace("'", ""))
                    .ToList();

                var response = Response.Fail("Invalid model", messages);
                context.Result = new BadRequestObjectResult(response);

                //var otherProperties = new Dictionary<string, string>()
                //{
                //    { "Method",context.ActionDescriptor.DisplayName}
                //};

                //var dic = new Dictionary<string, object>();
                //dic.Add("Error", response);
                //_telemetry.LogTrace("Invalid Model", 0, dic);
                return;
            }
        }
    }
}
