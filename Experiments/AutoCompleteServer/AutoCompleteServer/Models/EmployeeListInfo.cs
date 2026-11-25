using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class EmployeeListInfo
    {
        public EmployeeListInfo()
        {

        }

        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<string[]> data { get; set; }
    }
}