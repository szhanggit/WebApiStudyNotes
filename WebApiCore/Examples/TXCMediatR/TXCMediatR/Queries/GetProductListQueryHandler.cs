using AutoMapper;
using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetProductListQueryHandler : IRequestListHandlerWrapper<GetProductListQuery, GetProductListResponse>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        private readonly string _txc2UserName;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _txc2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
            _mapper = mapper;
        }

        public async Task<Response<GetProductListResponse>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Status == null)
                {
                    return new Response<GetProductListResponse>()
                    {
                        Success = false,
                        Message = "Status required"
                    };
                }
                if (request.RowCount == null)
                {
                    return new Response<GetProductListResponse>()
                    {
                        Success = false,
                        Message = "RowCount required"
                    };
                }
                if (request.PageNumber == null)
                {
                    return new Response<GetProductListResponse>()
                    {
                        Success = false,
                        Message = "PageNumber required"
                    };
                }



                return new Response<GetProductListResponse>()
                {
                    Success = true,
                    Message = "Message",
                };
            }
            catch (Exception ex)
            {
                var result = new Response<GetProductListResponse>()
                {
                    Success = false,
                    Message = ex.Message,
                };
                return result;

            }



        }

    }
}
