using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class EmployeeListInfo4
    {
        public EmployeeListInfo4()
        {

        }

        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Dictionary<string, string>> data { get; set; }
    }
}