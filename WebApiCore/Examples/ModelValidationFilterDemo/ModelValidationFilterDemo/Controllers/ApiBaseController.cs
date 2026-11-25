using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelValidationFilterDemo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidationFilterDemo.Controllers
{
    [ServiceFilter(typeof(ModelValidationResultFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        public ApiBaseController()
        {

        }

        internal string FlattenModelStateErrorMessage()
        {
            return string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
        }


    }
}
