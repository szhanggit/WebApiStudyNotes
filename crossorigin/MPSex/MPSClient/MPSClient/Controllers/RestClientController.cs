using MPSClient.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MPSClient.Controllers
{
    public class RestClientController : Controller
    {
        // GET: RestClient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMethod()
        {
            var client = new RestClient("http://localhost/MPSServer2/api/");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;
            var request = new RestRequest("AccountInfo", Method.GET);
            request.AddParameter("i", 5);
            request.Timeout = 5000;
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = JsonConvert.DeserializeObject<AccountInfoResponse>(response.Content);
            }
            

            return View("Index");
        }

        public ActionResult PostMethod()
        {
            AccountInfoResponse result = null;
            RestClient client = new RestClient("http://localhost/MPSServer2/api/");
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;
            //NetworkCredential nCredential = new NetworkCredential("user", "password", "domain");
            //client.Authenticator = new NtlmAuthenticator(nCredential);

            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };
            string content = JsonConvert.SerializeObject(model);

            RestRequest createInstance = new RestRequest("AccountInfo", Method.POST);
            createInstance.AddHeader("cache-control", "no-cache,no-cache");
            createInstance.AddHeader("content-type", "application/json");
            createInstance.AddHeader("Accept", "application/json;odata=verbose");
            createInstance.AddHeader("Body", "");
            createInstance.AddHeader("Authorization", "aleiju;lakjsdfldfkjs");
            createInstance.Timeout = 5000;
            createInstance.RequestFormat = DataFormat.Json;
            createInstance.AddParameter("application/json; charset=utf-8", content, ParameterType.RequestBody);

            var restResponse = client.Execute(createInstance);
 
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<AccountInfoResponse>(restResponse.Content);
            }
            
            return View("Index");
        }
    }
}