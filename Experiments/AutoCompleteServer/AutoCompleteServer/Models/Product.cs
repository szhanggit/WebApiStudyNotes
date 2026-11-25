using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class Product
    {
        public Product()
        {

        }

        public int Id { get; set; } 
        public int ProgramId { get; set; } 
        public string ProductCode { get; set; } 
        public string ExternalProductCode { get; set; } 
        public string ProductName { get; set; } 
        public string Description { get; set; } 
        public string Note { get; set; } 
        public int MinRedeemQuantity { get; set; } 
        public int MaxIssuingQuantity { get; set; } 
        public int Status { get; set; } 
        public string CreatedBy { get; set; } 
        public DateTime CreatedOn { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}