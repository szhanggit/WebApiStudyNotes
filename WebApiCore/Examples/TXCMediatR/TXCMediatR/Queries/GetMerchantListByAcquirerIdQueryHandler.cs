using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetMerchantListByAcquirerIdQueryHandler : IRequestListHandlerWrapper<GetMerchantListByAcquirerIdQuery, GetMerchantListResponse>
    {
        private readonly string _tenantName;
        private readonly string _tenantId;

        public GetMerchantListByAcquirerIdQueryHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantId"];
        }
        public async Task<Response<GetMerchantListResponse>> Handle(GetMerchantListByAcquirerIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int TenantId = 0;
                if (!int.TryParse(_tenantId, out TenantId))
                {
                    return new Response<GetMerchantListResponse>()
                    {
                        Success = false,
                        Message = "Invalid TenantId",
                        Data = null
                    };
                }

                return new Response<GetMerchantListResponse>()
                {
                    Success = true,
                    Message = "Message",
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
