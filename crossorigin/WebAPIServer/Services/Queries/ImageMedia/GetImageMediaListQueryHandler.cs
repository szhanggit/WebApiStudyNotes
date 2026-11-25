using Common.Data.Core;
using Common.Data.TenantDbConnection;
using Common.Domain;
using Common.Domain.Models;
using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Domain.Dto;

namespace Services.Queries.ImageMedia
{
    public class GetImageMediaListQueryHandler : ServiceHandlerBase, IRequestListHandlerWrapper<GetImageMediaListQuery, GetImageMediaListResponse>
    {
        public GetImageMediaListQueryHandler(ITenantDbConnection tenantDbConnection, IDapperOperation dapperOperation) : base(tenantDbConnection, dapperOperation)
        {

        }

        public async Task<Response<GetImageMediaListResponse>> Handle(GetImageMediaListQuery request, CancellationToken cancellationToken)
        {
            try
            {



                GetImageMediaListResponse response = new GetImageMediaListResponse
                {
                    TotalCount = 10
                };
                return Response.Success("sucess", response);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
