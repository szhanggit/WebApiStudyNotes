using Common.Domain;
using Common.Domain.Dto;
using Common.Services.HttpService;
using Common.Services.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Queries
{
    public class GetMediaQueryHandler : IRequestHandlerWrapper<GetMediaQuery, MediaDto>
    {
        private readonly string _authHeader;
        private readonly string _tenantName;
        private readonly string _tenantId;
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        public GetMediaQueryHandler(IHttpContextAccessor httpContextAccessor
                                        , IHttpService httpService
                                        , IConfiguration configuration)
        {
            _authHeader = httpContextAccessor.HttpContext?.Request?.Headers["Authorization"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<Response<MediaDto>> Handle(GetMediaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Uri uri = new Uri(@"http://localhost:8001/api/Media/GetById?MediaId=10");

                var headers = new Dictionary<string, string>()
                {

                };

                var response = await _httpService.GetAsync<Response<MediaDto>>(uri, headers, cancellationToken);

                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
