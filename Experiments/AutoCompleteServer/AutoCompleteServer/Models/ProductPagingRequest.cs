using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class ProductPagingRequest
    {
        public ProductPagingRequest()
        {

        }

        public int Page { get; set; }
        public int Size { get; set; }
        public string Column { get; set; }
        public string SortDirection { get; set; }
    }
}