using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestClientEx
{
    public class Dispatcher
    {
        public Dispatcher()
        {
            
        }

        public void Send()
        {
            /*
             D:\Study\WebApiStudyNotes\crossorigin\MPSex\MPSServer2\MPSServer2\Controllers\AccountInfoController.cs
             Post
             */
            RestClient client = new RestClient("http://localhost/MPSServer2/api/");

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
            createInstance.Timeout = 6000;
            createInstance.RequestFormat = DataFormat.Json;
            createInstance.AddParameter("application/json; charset=utf-8", content, ParameterType.RequestBody);
            var tcs = new TaskCompletionSource<IRestResponse>();

            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Send Request");
            var restResponse = client.Execute(createInstance);
            client.ExecuteAsync(createInstance, response =>
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Callback Triggered");
                Console.WriteLine($"Response: {response.Content}");
            });
        }
    }
}
