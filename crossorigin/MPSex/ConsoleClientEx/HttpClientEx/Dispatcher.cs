using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientEx
{
    public class Dispatcher
    {
        public Dispatcher()
        {

        }

        public void Send()
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
                //client.Timeout = new TimeSpan(0, 0, 23);
                client.DefaultRequestHeaders.Add("X-Client-id", "asdf");
                client.DefaultRequestHeaders.Add("X-Client-secret", "asdfasdf");
                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Send Request");
                using (var responseMessage = client.PostAsJsonAsync("Student", model).Result)
                {
                    var rawJson = responseMessage.Content.ReadAsStringAsync().Result;
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Callback Triggered");
                        Console.WriteLine($"{rawJson}");
                    }
                }                
            }
        }
        
        public async void SendAsyc()
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
                //client.Timeout = new TimeSpan(0, 0, 23);
                client.DefaultRequestHeaders.Add("X-Client-id", "asdf");
                client.DefaultRequestHeaders.Add("X-Client-secret", "asdfasdf");
                client.BaseAddress = new Uri("http://localhost/MPSServer2/api/");
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Send Request");
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PostAsync("Student", stringContent);
                if (result.IsSuccessStatusCode)
                {
                    var rawJson = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Callback Triggered");
                    Console.WriteLine($"{rawJson}");
                }
            }
        }
    }
}
