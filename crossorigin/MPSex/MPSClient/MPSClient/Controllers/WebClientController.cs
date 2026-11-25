using MPSClient.Infrastructure;
using MPSClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MPSClient.Controllers
{
    public class WebClientController : Controller
    {
        // GET: WebClient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostMethod()
        {
            string HtmlResult = string.Empty;
            //string url = "http://localhost:65232/api/AccountInfo";
            string url = "http://localhost/MPSServer2/api/AccountInfo";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback += TrustSelfCerticate;

            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };
            var jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();//System.Web.Extension
            string content = jsSerializer.Serialize(model);
            //string content = JsonConvert.SerializeObject(model);            

            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                wc.Headers.Add("Authorization", "o38uar4ou3oeuoae");
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                
                HtmlResult = wc.UploadString(url, "POST", content);
                dynamic checkResult = jsSerializer.Deserialize<dynamic>(HtmlResult);
                string result = checkResult["ErrorMsg"];
            }


            return View("Index");
        }

        private static bool TrustSelfCerticate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /*
         https://stackoverflow.com/questions/5401501/how-to-post-data-to-specific-url-using-webclient-in-c-sharp
            string URI = "site.com/mail.php";
            using (WebClient client = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection postData = 
                    new System.Collections.Specialized.NameValueCollection()
                   {
                          { "to", emailTo },  
                          { "subject", currentSubject },
                          { "body", currentBody }
                   };
                string pagesource = Encoding.UTF8.GetString(client.UploadValues(URI, postData));
            }
             */


        /*
         https://www.c-sharpcorner.com/blogs/consume-webapi-using-webclient-in-c-sharp
             */
        public ActionResult GetMethod()
        {
            string HtmlResult = string.Empty;
            //string url = "http://localhost:65232/api/AccountInfo?i=5";
            string url = "http://localhost/MPSServer2/api/AccountInfo?i=5";
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };
            string content = JsonConvert.SerializeObject(model);

            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                HtmlResult = wc.DownloadString(url);
            }


            return View("Index");
        }

        public ActionResult DeleteMethod()
        {
            string HtmlResult = string.Empty;
            string url = "http://localhost:65232/api/AccountInfo";
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };
            string content = JsonConvert.SerializeObject(model);

            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                HtmlResult = wc.UploadString(url, "DELETE", content);
            }


            return View("Index");
        }

        public ActionResult SecondPostMethod()
        {
            string HtmlResult = string.Empty;
            //string url = "http://localhost:65232/api/AccountInfo";
            string url = "http://localhost/MPSServer2/api/AccountInfo";
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };

            AccountInfoResponse response = ApiInvokeHelper.MakePostRequest<LoginModelRequest, AccountInfoResponse>(model, url, GetHeaderDic());

            return View("Index");
        }

        private Dictionary<string, string> GetHeaderDic()
        {
            Dictionary<string, string> result = null;
            try
            {
                string timeStamp = DateTimeOffset.UtcNow.UtcTicks.ToString();
                result = new Dictionary<string, string>();
                result.Add("Time", timeStamp);
                result.Add("Authorization", "adkjshflaksflaj");
            }
            catch (Exception ex)
            {
                //ErrorLogManager.LogError(ex);
            }
            return result;
        }

        public ActionResult QRCodePostMethod()
        {
            string HtmlResult = string.Empty;
            //string url = "http://localhost:65232/api/QRCode";
            string url = "http://localhost/MPSServer2/api/QRCode";
            double scale = 5;
            string shortUrl = "ladksflkjsdlfj";

            string QrCodeGenerator = CommonHelper.Append(
                                    url,
                                    CommonConsts.Question,
                                    CommonConsts.SCALE,
                                    CommonConsts.Equal,
                                    Math.Round(scale, MidpointRounding.AwayFromZero),
                                    CommonConsts.And,
                                    CommonConsts.CODE,
                                    CommonConsts.Equal,
                                    shortUrl);

            byte[] image = null;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            using (WebClient client = new WebClient())
            {
                image = client.DownloadData(QrCodeGenerator);
            }
            if (image != null)
            {
                var base64 = Convert.ToBase64String(image);
                var imgSrc = $"data:image/png;base64,{base64}";
                HtmlResult = CommonMethod.FormatHtmlImage(imgSrc);
            }

            QRCode code = new QRCode {
                Code = HtmlResult
            };
            return View(code);
        }
    }
}