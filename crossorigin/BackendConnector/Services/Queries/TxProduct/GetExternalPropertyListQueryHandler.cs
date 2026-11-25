using Common.Domain;
using Common.Services.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Queries.TxProduct
{
    public class GetExternalPropertyListQueryHandler : IRequestHandlerWrapper<GetExternalPropertyListQuery, IEnumerable<ProductExternalPropertyModel>>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        private readonly string _TX2UserName;
        public GetExternalPropertyListQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
        }

        public async Task<Response<IEnumerable<ProductExternalPropertyModel>>> Handle(GetExternalPropertyListQuery request, CancellationToken cancellationToken)
        {

            IEnumerable<ProductExternalPropertyModel> result = new List<ProductExternalPropertyModel>();

            try
            {
                if (request.ProductId == 0)
                {
                    return Response.Fail("ProductId parameter required", result);
                }

                IEnumerable<ProductExternalPropertyModel> _list = new List<ProductExternalPropertyModel> { 
                    new ProductExternalPropertyModel{ PropertyName = "A1", PropertyValue = "A2", Description = "A3", ProductExternalPropertyId = 1, ProductExternalPropertySetId = 2 },
                    new ProductExternalPropertyModel{ PropertyName = "B1", PropertyValue = "B2", Description = "B3", ProductExternalPropertyId = 3, ProductExternalPropertySetId = 4 }
                };

                return Response.Success("success", _list);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<ProductExternalPropertyModel>>() { Success = false, Message = ex.Message, Data = null };
            }
        }
    }
}
