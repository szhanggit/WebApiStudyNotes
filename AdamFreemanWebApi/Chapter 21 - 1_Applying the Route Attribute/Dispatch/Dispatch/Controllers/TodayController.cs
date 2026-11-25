using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dispatch.Controllers
{
    [RoutePrefix("api/today")]
    public class TodayController : ApiController
    {
        [HttpGet]
        //[Route("api/today/dayofweek")]
        [Route("dayofweek")]
        public string DayOfWeek()
        {
            return DateTime.Now.ToString("dddd");
        }

        /*
         Get http://localhost:49412/api/Today/DayOfWeek
         Content-Type       application/json
         */


        [HttpGet]
        //[Route("api/today/dayofweek/{day}")]
        [Route("dayofweek/{day}")]
        public string DayOfWeek(int day)
        {
            return Enum.GetValues(typeof(DayOfWeek)).GetValue(day).ToString();
        }

        /*
         Get http://localhost:49412/api/Today/DayOfWeek/2
         Content-Type       application/json
         */

        [HttpGet]
        //[Route("getdaynumber")]
        //To prevent the prefix from being applied, I have updated the route template so that it begins with ~/, like this:
        [Route("~/getdaynumber")]
        public int DayNumber()
        {
            return DateTime.Now.Day;
        }

        /*
         Get http://localhost:49412/getdaynumber
         Content-Type       application/json
         */
    }
}
