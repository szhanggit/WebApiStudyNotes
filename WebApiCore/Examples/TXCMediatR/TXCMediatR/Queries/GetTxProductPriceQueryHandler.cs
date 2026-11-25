using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetTxProductPriceQueryHandler : IRequestHandlerWrapper<GetTxProductPriceQuery, ProductPriceDto>
    {
        private readonly string _TX2UserName;
        private readonly string _TenantName;
        private readonly int _TenantId;

        public GetTxProductPriceQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
            _TenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            Int32.TryParse(httpContextAccessor.HttpContext?.Request?.Headers["TenantId"], out _TenantId);
        }

        public async Task<Response<ProductPriceDto>> Handle(GetTxProductPriceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new Response<ProductPriceDto> { Success = true, Message = "Message" };
                bool success = true;
                if (success)
                {
                    response.Data = new ProductPriceDto()
                    {
                        ProductPriceId = 1,
                        SellingPricePrepaid = 1,
                        SellingPricePrepaidWithTax = 1,
                        SellingPricePostpaid = 1,
                        SellingPricePostpaidWithTax = 1,
                        CustomerFeePrepaid = 1,
                        CustomerFeePrepaidWithTax = 1,
                        CustomerFeePostpaid = 1,
                        CustomerFeePostpaidWithTax = 1
                    };
      
                    return response;
                }
                else
                {
                    return new Response<ProductPriceDto> { Success = false, Message = "Message" };
                }
      

                return new Response<ProductPriceDto>() { Success = false, Message = "response is null" };
            }
            catch (Exception ex)
            {
                return new Response<ProductPriceDto>() { Success = false, Message = ex.Message, Data = null };
            }
        }
    }
}
