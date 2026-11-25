using Common.Data.Core;
using Common.Data.TenantDbConnection;
using Common.Domain;
using Common.Domain.Dto;
using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Queries.ImageMedia
{
    public class GetMediaQueryHandler : ServiceHandlerBase, IRequestHandlerWrapper<GetMediaQuery, MediaDto>
    {
        public GetMediaQueryHandler(ITenantDbConnection tenantDbConnection, IDapperOperation dapperOperation) : base(tenantDbConnection, dapperOperation)
        {

        }

        public async Task<Response<MediaDto>> Handle(GetMediaQuery request, CancellationToken cancellationToken)
        {

            return Response.Success("sucess", new MediaDto());
        }
    }
}
