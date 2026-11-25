using Common.Domain;
using Common.Domain.Models;
using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Services.HttpService;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Services.Queries
{
    public class GetImageMediaListQueryHandler : IRequestListHandlerWrapper<GetImageMediaListQuery, GetImageMediaListResponse>
    {
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        private readonly string _authHeader;
        private readonly string _tenantName;
        private readonly string _tenantId;
        public GetImageMediaListQueryHandler(IHttpContextAccessor httpContextAccessor
                                        , IHttpService httpService
                                        , IConfiguration configuration)
        {
            _authHeader = httpContextAccessor.HttpContext?.Request?.Headers["Authorization"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<Response<GetImageMediaListResponse>> Handle(GetImageMediaListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var queryParam = new Dictionary<string, string>()
                {
                    {"SearchKeyword",request.SearchKeyword},
                    {"Type",request.Type.ToString()},
                    {"PageNumber",request.PageNumber.ToString()},
                    {"RowCount",request.RowCount.ToString()},

                };

                string url = QueryHelpers.AddQueryString("http://localhost:8001/api/Media", queryParam);

                Uri uri = new Uri(url);

                var headers = new Dictionary<string, string>()
                {

                };

                var response = await _httpService.GetAsync<Response<GetImageMediaListResponse>>(uri, headers, cancellationToken);

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
