using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class Client
    {
        public string Name { get; set; }
        public string IdentityCode { get; set; }
        public string InvoiceRegisterNumber { get; set; }
        public string CRMReference { get; set; }
        public string FinanceReference { get; set; }
        public string Department { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string Modifier { get; set; }
        public DateTime VersionTime { get; set; }
        public string SecurityKey { get; set; }
        public string Title { get; set; }
        public string EmailSenderName { get; set; }
        public string EmailSenderAddress { get; set; }
    }
}