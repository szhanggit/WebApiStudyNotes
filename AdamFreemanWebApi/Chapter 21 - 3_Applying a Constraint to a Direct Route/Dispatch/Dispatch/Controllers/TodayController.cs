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
        //[HttpGet]
        //[Route("dayofweek/{day:int=-1}")]
        //public string DayOfWeek(int day)
        //{
        //    if (day != -1)
        //    {
        //        return Enum.GetValues(typeof(DayOfWeek)).GetValue(day).ToString();
        //    }
        //    else
        //    {
        //        return DateTime.Now.ToString("dddd");
        //    }
        //}

        [HttpGet]
        [Route("dayofweek")]
        public string DayOfWeek()
        {
            return DateTime.Now.ToString("dddd");
        }

        [HttpGet]
        [Route("dayofweek/{day:range(0, 6)}")]
        public string DayOfWeek(int day)
        {
            return Enum.GetValues(typeof(DayOfWeek)).GetValue(day).ToString();
        }

        /*
         Get http://localhost:49412/api/Today/dayofweek/6
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
