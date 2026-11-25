using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MPSClient.Infrastructure
{
    public static class ApiInvokeHelper
    {
        public static TResponse MakePostRequest<TRequest, TResponse>(TRequest request, string uri, Dictionary<string, string> headerDic = null)
         where TResponse : class
        {
            try
            {
                string requestData = JsonHelper.SerializeObject(request);
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    if (headerDic != null && headerDic.Keys.Count > 0)
                    {
                        foreach (var item in headerDic)
                        {
                            if (string.IsNullOrWhiteSpace(item.Key)) continue;
                            client.Headers[item.Key] = item.Value;
                        }
                    }
                    string result = client.UploadString(uri, "POST", requestData);
                    TResponse response = JsonHelper.DeserializeAnonymousType(result, Activator.CreateInstance<TResponse>());
                    return response;
                }
            }
            catch (Exception ex)
            {
                //ErrorLogManager.LogError(ex);
                return Activator.CreateInstance<TResponse>();
                throw ex;
            }
        }
    }
}