using MPSClient.Infrastructure;
using MPSClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MPSClient.Controllers
{
    public class HttpClientController : Controller
    {
        // GET: HttpClient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMethod()
        {
            string userName = "user7";
            string passwd = "passwd";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                //client.DefaultRequestHeaders.Add("Authorization", "hgfkjghjg");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var responseTask = client.GetAsync("AccountInfo?i=5");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();                    
                    AccountInfoResponse response = JsonHelper.FromJson<AccountInfoResponse>(readTask.Result);
                    readTask.Wait();
                }
            }


            return View("Index");
        }

        public ActionResult GetSecondMethod()
        {
            string userName = "user7";
            string passwd = "passwd";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var response = client.GetAsync("Form?code=ajdshfkjasdhf").Result;
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    dynamic responseObj = new JavaScriptSerializer().Deserialize<dynamic>(responseString);
                }
            }


            return View("Index");
        }

        public ActionResult GetQRCodeMethod()
        {
            string HtmlResult = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetByteArrayAsync("QRCode?code=klsdjlhfdfs&scale=5");
                responseTask.Wait();
                byte[] imageBytes = responseTask.Result;
                if (imageBytes != null)
                {
                    var base64 = Convert.ToBase64String(imageBytes);
                    var imgSrc = $"data:image/png;base64,{base64}";
                    HtmlResult = CommonMethod.FormatHtmlImage(imgSrc);
                }

            }

            return View("Index");
        }

        public ActionResult PostMethod()
        {
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                var postTask = client.PostAsync("AccountInfo", data);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    AccountInfoResponse response = JsonHelper.FromJson<AccountInfoResponse>(readTask.Result);
                    readTask.Wait();
                }
            }


            return View();
        }

        /*
        https://www.c-sharpcorner.com/article/upload-and-save-multipartform-data-in-webapi-2/
            */
        public ActionResult PostFormMethod()
        {
            string AccountName = "stzhang";
            string AccountPwd = "WelcomeMar2021";
            string FilePath = @"D:\ApplyToOrder_15.xls";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var client = new HttpClient())
            {
                string section = GetType().Namespace;
                string username = "stzhang";
                string password = "WelcomeMar2021";
                byte[] headers = System.Text.Encoding.ASCII.GetBytes(username + ":" + password);

                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));//application/json
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(headers));

                using (var request = new MultipartFormDataContent())
                {
                    request.Add(new StringContent(AccountName), "AccountName");
                    request.Add(new StringContent(AccountPwd), "AccountPwd");
                    request.Add(new StreamContent(System.IO.File.OpenRead(FilePath)), "attachment", Path.GetFileName(FilePath));

                    var response = client.PostAsync("Form", request).Result;
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        dynamic responseObj = new JavaScriptSerializer().Deserialize<dynamic>(responseString);
                    }
                }
            }


            return View("Index");
        }

        public ActionResult SecondPostMethod()
        {
            AccountInfoResponse invokeUpdateResponse = null;
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                //client.Timeout = new TimeSpan(0, 0, 23);
                client.DefaultRequestHeaders.Add("X-Client-id", "asdf");
                client.DefaultRequestHeaders.Add("X-Client-secret", "asdfasdf");
                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                using (var responseMessage = client.PostAsJsonAsync("Student2", model).Result)
                {
                    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;                    
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        invokeUpdateResponse = CommonHelper.DeserializeFromJson<AccountInfoResponse>(rawJson);
                    }
                }
            }


            return View();
        }


        public ActionResult DeleteMethod()
        {
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                var postTask = client.DeleteAsync("Student?i=5");
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    AccountInfoResponse response = JsonHelper.FromJson<AccountInfoResponse>(readTask.Result);
                    readTask.Wait();
                }
            }


            return View();
        }
    }
}