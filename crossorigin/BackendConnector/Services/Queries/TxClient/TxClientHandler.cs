using Common.Domain;
using Common.Services.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Queries.TxClient
{
    public class GetTxClientListQueryHandler : IRequestHandlerWrapper<GetTxClientListQuery, GetTxClientListResponse>
    {
        private readonly string _tenantName;
        private readonly string _tenantId;

        public GetTxClientListQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
        }

        public async Task<Response<GetTxClientListResponse>> Handle(GetTxClientListQuery request, CancellationToken cancellationToken)
        {

            var result = new GetTxClientListResponse();

            try
            {
                GetTxClientListResponse getTxClientListResponse = new GetTxClientListResponse();
                return Response.Fail("fail", getTxClientListResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class GetTxClientByIdQueryHandler : IRequestHandlerWrapper<GetTxClientByIdQuery, ClientDto>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        public GetTxClientByIdQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
        }

        public async Task<Response<ClientDto>> Handle(GetTxClientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {


                return new Response<ClientDto>(null, "", false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class GetTxClientByIdentityCodeQueryHandler : IRequestHandlerWrapper<GetTxClientByIdentityCodeQuery, ClientDto>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        public GetTxClientByIdentityCodeQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
        }

        public async Task<Response<ClientDto>> Handle(GetTxClientByIdentityCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {


                return new Response<ClientDto>(null, "", false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class CreateTxClientRequestHandler : IRequestHandlerWrapper<CreateTxClientRequest, int>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        private readonly string _TX2UserName;

        public CreateTxClientRequestHandler(IHttpContextAccessor httpContextAccessor)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
        }

        public async Task<Response<int>> Handle(CreateTxClientRequest request, CancellationToken cancellationToken)
        {
            try
            {


                return Response.Fail("", 1);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class UpdateTxClientRequestHandler : IRequestHandlerWrapper<UpdateTxClientRequest, int>
    {
        private readonly string _tenantId;
        private readonly string _tenantName;
        private readonly string _TX2UserName;

        public UpdateTxClientRequestHandler(IHttpContextAccessor httpContextAccessor)
        {
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _TX2UserName = httpContextAccessor.HttpContext?.Request?.Headers["TX2UserName"];
        }

        public async Task<Response<int>> Handle(UpdateTxClientRequest request, CancellationToken cancellationToken)
        {
            try
            {
                

                return Response.Fail("", 1);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
