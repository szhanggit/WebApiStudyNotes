using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTester
{
    class Program
    {
        static void Main(string[] args)
        {
            TXCProductConnector _tXCProductConnector = new TXCProductConnector();
            //_tXCProductConnector.CreateProductExternalPropertyList();
            //_tXCProductConnector.CreateProductExternalPropertyListV2();
            //_tXCProductConnector.UpdateProductStatus();
            _tXCProductConnector.GetProductPropertiesList();
        }
    }
}
