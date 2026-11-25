using AutoMapper;
using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetExternalPropertyListQueryHandler : IRequestHandlerWrapper<GetExternalPropertyListQuery, IEnumerable<ProductExternalPropertyModel>>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        private readonly string _TX2UserName;
        private readonly IMapper _mapper;

        public GetExternalPropertyListQueryHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
        }

        public async Task<Response<IEnumerable<ProductExternalPropertyModel>>> Handle(GetExternalPropertyListQuery request, CancellationToken cancellationToken)
        {
            bool success = true;
            IEnumerable<ProductExternalPropertyModel> result = new List<ProductExternalPropertyModel>();

            try
            {
                if (request.ProductId == 0)
                {
                    return Response.Fail("ProductId parameter required", result);
                }

                if (success)
                {
                    return Response.Success("success", result);
                }

                return new Response<IEnumerable<ProductExternalPropertyModel>>(null, "Message", false);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<ProductExternalPropertyModel>>() { Success = false, Message = ex.Message, Data = null };
            }
        }
    }
}
