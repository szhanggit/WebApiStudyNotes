using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WebClientEx
{
    public class Dispatcher
    {
        private JavaScriptSerializer jsSerializer = null;

        public Dispatcher()
        {
            jsSerializer = new JavaScriptSerializer();//System.Web.Extension
        }

        public void Send()
        {
            string HtmlResult = string.Empty;
            //string url = "http://localhost:65232/api/AccountInfo";
            string url = "http://localhost/MPSServer2/api/AccountInfo";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += TrustSelfCerticate;
            Uri address = new Uri(url);

            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };            
            string content = jsSerializer.Serialize(model);

            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Send Request");
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                wc.Headers.Add("Authorization", "o38uar4ou3oeuoae");
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.UploadStringCompleted += wc_UploadComplete;

                wc.UploadStringAsync(address, "POST", content);                
            }
        }

        private static bool TrustSelfCerticate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private static void wc_UploadComplete(object sender, UploadStringCompletedEventArgs e)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Callback Triggered");
            dynamic checkResult = jsSerializer.Deserialize<dynamic>(e.Result);
            string result = checkResult["ErrorMsg"];
            Console.WriteLine($"Message: {result}");
        }
    }
}
