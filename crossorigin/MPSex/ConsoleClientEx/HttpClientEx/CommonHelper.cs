using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientEx
{
    public static class CommonHelper
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync<TModel>(this HttpClient client, string requestUrl, TModel model)
        {
            var json = SerializeToJson(model);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(requestUrl, stringContent);
        }

        public static string SerializeToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
