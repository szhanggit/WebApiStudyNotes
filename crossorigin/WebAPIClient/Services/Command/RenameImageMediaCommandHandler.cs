using Common.Domain;
using Common.Services.HttpService;
using Common.Services.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Command
{
    public class RenameImageMediaCommandHandler : IRequestHandlerWrapper<RenameImageMediaCommand, int>
    {
        private readonly string _authHeader;
        private readonly string _tenantName;
        private readonly string _tenantId;
        private readonly IHttpService _httpService;
        private readonly IConfiguration _configuration;
        public RenameImageMediaCommandHandler(IHttpContextAccessor httpContextAccessor
                                        , IHttpService httpService
                                        , IConfiguration configuration)
        {
            _authHeader = httpContextAccessor.HttpContext?.Request?.Headers["Authorization"];
            _tenantName = httpContextAccessor.HttpContext?.Request?.Headers["TenantName"];
            _tenantId = httpContextAccessor.HttpContext?.Request?.Headers["TenantBasicInfoId"];
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<Response<int>> Handle(RenameImageMediaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Uri uri = new Uri(@"http://localhost:8001/api/Media");

                var serializeData = JsonConvert.SerializeObject(request);

                StringContent content = new StringContent(serializeData, Encoding.UTF8, "application/json");

                var headers = new Dictionary<string, string>()
                {

                };
                var response = await _httpService.PutAsync<Response<int>>(uri, content, headers, cancellationToken);

                return response;


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
