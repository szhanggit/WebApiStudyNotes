using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class FlowerSum
    {
        public int total { get; set; }
        public Dictionary<string, int> flowers {get; set;}
        public FlowerSum() { }
    }
}