using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTester
{
    public class TXCProductConnector
    {
        public TXCProductConnector()
        {

        }

        public void CreateProductExternalPropertyList()
        {
            int ProductId = 1;
            CreateExternalPropertyListCommand request = new CreateExternalPropertyListCommand();
            List<ProductExternalPropertyModel> PropertyList = new List<ProductExternalPropertyModel> {
                new ProductExternalPropertyModel{ propertyName = "PB", propertyValue = "PA", description = "PA" },
                new ProductExternalPropertyModel{ propertyName = "PB", propertyValue = "PB", description = "PB" },
            };
            request.ProductExternalPropertyList = PropertyList;
            request.ProductId = ProductId;
            TXCApiUpdateResult updatingResult = null;
            TXC_ProductService service = new TXC_ProductService();
            service.CreateProductExternalPropertyList(request, out updatingResult);
        }

        public void CreateProductExternalPropertyListV2()
        {
            int ProductId = 1;
            CreateExternalPropertyListCommand request = new CreateExternalPropertyListCommand();
            List<ProductExternalPropertyModel> PropertyList = new List<ProductExternalPropertyModel> {
                new ProductExternalPropertyModel{ propertyName = "PB", propertyValue = "PA", description = "PA" },
                new ProductExternalPropertyModel{ propertyName = "PB", propertyValue = "PB", description = "PB" },
            };
            request.ProductExternalPropertyList = PropertyList;
            request.ProductId = ProductId;
            TXC_ProductService service = new TXC_ProductService();
            service.CreateProductExternalPropertyListV2(request);
        }

        public void UpdateProductStatus()
        {
            int ProductId = 10;
            int Status = 1;
            TXC_ProductService service = new TXC_ProductService();
            service.UpdateProductStatus(ProductId, Status);
        }

        public void GetProductPropertiesList()
        {
            int ProductId = 1;
            TXC_ProductService service = new TXC_ProductService();
            var list = service.GetProductExternalPropertyList(ProductId);
        }
    }
}
