using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace HttpClientFactoryEx
{
    public class Dispatcher
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _serviceUri;
        public Dispatcher()
        {
            _serviceUri = "http://localhost/MPSServer2/api/";
            _httpClientFactory = new HttpClientFactoryExtensions();
        }

        public void Send()
        {
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };
            HttpContent httpContent = new StringContent(
                JsonConvert.SerializeObject(model)
                , Encoding.UTF8, "application/json");
            var httpClient = _httpClientFactory.CreateClient();
            Task<HttpResponseMessage> response = httpClient.PostAsync(_serviceUri, httpContent);
        }
    }
}
