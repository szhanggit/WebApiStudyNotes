using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dispatch.Controllers
{
    public class TodayController : ApiController
    {
        [HttpGet]
        public string DayOfWeek()
        {
            var a = ControllerContext.RouteData.Values;
            return DateTime.Now.ToString("dddd");
        }

        [HttpGet]
        public string DayOfWeek(int day)
        {
            var a = ControllerContext.RouteData.Values;
            return Enum.GetValues(typeof(DayOfWeek)).GetValue(day).ToString();
        }
        /*
         Get    http://localhost:49412/api/today/dayofweek/4
         Content-Type       application/json
             */

        [HttpGet]
        public int DayNumber()
        {
            return DateTime.Now.Day;
        }
    }
}
