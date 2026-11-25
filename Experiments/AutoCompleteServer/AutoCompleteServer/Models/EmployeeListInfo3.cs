using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class EmployeeListInfo3
    {
        public EmployeeListInfo3()
        {

        }

        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Employee2> data { get; set; }
    }
}