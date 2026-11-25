using AutoMapper;
using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;

namespace TXCMediatR.Commands
{
    public class InsertSKUBackupCommandHandler : IRequestHandlerWrapper<InsertSKUBackupCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly string _TX2UserName;
        private readonly string _TenantName;
        private readonly int _TenantId;

        public InsertSKUBackupCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
            _TenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            Int32.TryParse(httpContextAccessor.HttpContext?.Request?.Headers["TenantId"], out _TenantId);
        }

        public async Task<Response<int>> Handle(InsertSKUBackupCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool Success = true;

                if (Success)
                {
                    return Response.Success("Success", 1);
                }

                return Response.Fail("Failed", 0);
            }
            catch (Exception exception)
            {
                return Response.Fail(exception.Message, 0);
            }
        }
    }
}
