using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class Merchant
    {
        public Merchant()
        {

        }

        public string IdentityCode { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public string InvoiceRegisterNumber { get; set; }
        public string ContactName1 { get; set; }
        public string ContactPhone1 { get; set; }
        public string SecurityKey { get; set; }
        public string Modifier { get; set; }
        public string MAMEmail { get; set; }
        public string MerchantEmail { get; set; }
    }
}