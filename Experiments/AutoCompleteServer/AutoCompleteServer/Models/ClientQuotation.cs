using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class ClientQuotation
    {
        public ClientQuotation()
        {

        }

        public int ClientId { get; set; }
        public string QuotationNumber { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
    }
}