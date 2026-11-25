using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class Dictionary
    {
        public Dictionary()
        {

        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}