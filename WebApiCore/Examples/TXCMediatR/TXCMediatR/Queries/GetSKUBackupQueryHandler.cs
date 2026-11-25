using AutoMapper;
using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetSKUBackupQueryHandler : IRequestHandlerWrapper<GetSKUBackupQuery, List<SKUBackupModel>>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        private readonly string _TX2UserName;
        private readonly IMapper _mapper;
        public GetSKUBackupQueryHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
        }

        public async Task<Response<List<SKUBackupModel>>> Handle(GetSKUBackupQuery request, CancellationToken cancellationToken)
        {

            List<SKUBackupModel> result = new List<SKUBackupModel>();

            try
            {
                bool success = true;

                if (success)
                {
                    return Response.Success("success", result);
                }

                return new Response<List<SKUBackupModel>>(null, "message", false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
