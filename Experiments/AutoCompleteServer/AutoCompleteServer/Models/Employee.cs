using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class Employee
    {
        public Employee()
        {

        }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string position { get; set; }
        public string office { get; set; }
        public DateTime start_date { get; set; }
        public int salary { get; set; }
    }
}