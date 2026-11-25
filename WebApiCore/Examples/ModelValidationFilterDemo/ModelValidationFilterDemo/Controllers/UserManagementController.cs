using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelValidationFilterDemo.Infrastructure;
using ModelValidationFilterDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModelValidationFilterDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ApiBaseController
    {
        private readonly ITelemetryLogTrace<UserManagementController> telemetryTrace;
        public UserManagementController(ITelemetryLogTrace<UserManagementController> telemetryTrace)
        {
            this.telemetryTrace = telemetryTrace;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo info, CancellationToken cancellationToken)
        {
            telemetryTrace.LogTrace("Rename image started", "RequestBody", info, SeverityLevel.Information);
            bool result = true;

            if (result)
            {
                telemetryTrace.LogTrace("Rename image finished successfully", "ResponseBody", result, SeverityLevel.Information);
                return Ok(result);
            }
            else
            {
                telemetryTrace.LogTrace("Rename image finished with errors", "ResponseBody", result, SeverityLevel.Information);
                return BadRequest(result);
            }
        }
    }
}
