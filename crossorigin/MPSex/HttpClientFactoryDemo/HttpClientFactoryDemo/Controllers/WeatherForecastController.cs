using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFactoryDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _serviceUri;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _serviceUri = "http://localhost/MPSServer2/api/";
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };
            HttpContent httpContent = new StringContent(
                JsonConvert.SerializeObject(model)
                , Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient("StudentInfo");//It needs to match with the name in Startup.cs.
            HttpResponseMessage result = await client.PostAsync("api/Student", httpContent);
            if (result.IsSuccessStatusCode)
            {
                var rawJson = await result.Content.ReadAsStringAsync();
            }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
