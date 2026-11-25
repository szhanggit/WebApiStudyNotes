using Common.Domain;
using Common.Services.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Command.TxProduct
{
    public class CreateExternalPropertyListCommandHandler : IRequestHandlerWrapper<CreateExternalPropertyListCommand, int>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        private readonly string _TX2UserName;
        public CreateExternalPropertyListCommandHandler(IHttpContextAccessor httpContextAccessor)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
        }

        public async Task<Response<int>> Handle(CreateExternalPropertyListCommand request, CancellationToken cancellationToken)
        {
            try
            {


                return Response.Fail("", 0);
            }
            catch (Exception exception)
            {
                return Response.Fail(exception.Message, 0);
            }
        }
    }
}
