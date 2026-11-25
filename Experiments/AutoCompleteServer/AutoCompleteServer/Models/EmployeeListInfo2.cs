using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class EmployeeListInfo2
    {
        public EmployeeListInfo2()
        {

        }
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Employee> data { get; set; }
    }
}