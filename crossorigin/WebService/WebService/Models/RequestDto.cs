using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class RequestDto
    {
        public RequestDto()
        {

        }

        public string country { get; set; }
        public string state { get; set; }
    }
}