using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientConsole
{
    public class CommonService
    {
        public async Task<HttpResponseMessage> SendRequestAsync(HttpClient _httpClient)
        {
            Uri uri = new Uri("http://localhost:5123/weatherforecast");
            var response = await _httpClient.GetAsync(uri);
            return response;
        }

        public async Task ProcessRequest()
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            HttpClient _httpClient = new HttpClient();

            HttpResponseMessage response = await SendRequestAsync(_httpClient);
        }
    }
}
