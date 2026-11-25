using Common.Domain;
using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Services.Command.TxProduct
{
    public class UpdateTxProductStatusCommandHandler : IRequestHandlerWrapper<UpdateTxProductStatusCommand, int>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        private readonly string _TX2UserName;
        public UpdateTxProductStatusCommandHandler(IHttpContextAccessor httpContextAccessor)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
        }

        public async Task<Response<int>> Handle(UpdateTxProductStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.ProductId == 0)
                {
                    return Response.Fail("ProductId parameter required", 0);
                }

                return Response.Fail("", 0);
            }
            catch (Exception exception)
            {
                return Response.Fail(exception.Message, 0);
            }
        }
    }
}
