using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientConsole
{
    public class Dispatcher
    {
        public Dispatcher()
        {

        }

        public async void SendAsyc()
        {
            try 
            {
                using (var client = new HttpClient())
                {
                    //client.Timeout = new TimeSpan(0, 0, 23);
                    client.BaseAddress = new Uri("http://localhost:52617/");
                    HttpResponseMessage result = await client.GetAsync("weatherforecast");
                    if (result.IsSuccessStatusCode)
                    {
                        var rawJson = await result.Content.ReadAsStringAsync();
                        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Callback Triggered");
                        Console.WriteLine($"{rawJson}");
                    }
                }
            } 
            catch (Exception ex) 
            { 
            
            }
        }
    }
}
