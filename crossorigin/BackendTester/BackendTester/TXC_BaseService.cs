using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BackendTester
{
    public abstract class TXC_BaseService
    {
        protected string BaseUrl;
        protected string Url;



        protected T QueryAPI<T>(Dictionary<string, object> requestDic, string baseUrl)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback += TrustSelfCerticate;

                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";

                    client.Headers["TenantBasicInfoId"] = "TXCTenantId".ConfigStringValue();
                    client.Headers["TenantName"] = "TXCTenantName".ConfigStringValue();

                    string url = baseUrl;
                    foreach (var item in requestDic)
                    {
                        if (url.Contains("?"))
                        {
                            url = url + $"&{item.Key}={item.Value}";
                        }
                        else
                        {
                            url = url + $"?{item.Key}={item.Value}";
                        }
                    }
                    string result = client.DownloadString(url);
                    TXC_Response<T> checkResult = CommonMethod.DeserializeFromJson<TXC_Response<T>>(result);

                    if (checkResult.success)
                    {
                        return checkResult.data;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return default(T);
        }

        protected T QueryAPIV2<T>(Dictionary<string, object> requestDic, string baseUrl)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback += TrustSelfCerticate;

                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers["TenantBasicInfoId"] = "TXCTenantId".ConfigStringValue();
                    client.Headers["TenantName"] = "TXCTenantName".ConfigStringValue();

                    string url = baseUrl;
                    foreach (var item in requestDic)
                    {
                        if (url.Contains("?"))
                        {
                            url = url + $"&{item.Key}={item.Value}";
                        }
                        else
                        {
                            url = url + $"?{item.Key}={item.Value}";
                        }
                    }
                    string result = client.DownloadString(url);
                    TXC_Response<T> checkResult = JsonHelper.FromJson<TXC_Response<T>>(result);

                    if (checkResult.success)
                    {
                        return checkResult.data;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return default(T);
        }

        protected static bool TrustSelfCerticate(object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }

    public class TXC_Response<T>
    {
        public T data { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
    }
}
