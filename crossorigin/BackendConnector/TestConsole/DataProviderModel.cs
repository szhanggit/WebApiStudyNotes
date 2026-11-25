using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class ProductExternalPropertyModel
    {
        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public string description { get; set; }
        public int productExternalPropertyId { get; set; }
        public int productExternalPropertySetId { get; set; }
    }

    public class CreateExternalPropertyListCommand
    {
        public int ProductId { get; set; }
        public List<ProductExternalPropertyModel> ProductExternalPropertyList { get; set; }
    }

    public class TXCApiUpdateResult
    {
        public object data { get; set; }
        public string message { get; set; }
        public bool Success { get; set; }
    }
}
