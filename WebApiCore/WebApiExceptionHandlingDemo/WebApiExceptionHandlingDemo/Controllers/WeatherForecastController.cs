using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebApiExceptionHandlingDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        /// <summary>
        /// This is simple method where resourse cleanup activities such as DB or file closing not required.
        /// </summary>
        /// <param name="throwException">Set true to throw exception</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWithoutTry")]
        public IEnumerable<WeatherForecast> Get(bool throwException)
        {
            if (throwException)
            {
                throw new Exception("This is dummy exception to test ExceptionHandlerMiddleware");
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

        /// <summary>
        /// For resource cleaning activity like DB connection closing, 
        /// we wrap the related code in try-catch block and in finally block cleaning 
        /// part can be accomplished.
        /// In catch block, we can simply cascade the exception details to global exception handler.
        /// </summary>
        /// <param name="throwException">Set true to throw exception</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWithTry")]
        public IEnumerable<WeatherForecast> Get2(bool throwException)
        {
            var rng = new Random();
            IEnumerable<WeatherForecast> response;
            try 
            {
                if (throwException)
                { 
                    throw new XmlException("This is dummy exception to test ExceptionHandlerMiddleware");
                }

                response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
            catch(Exception ex) 
            {
                throw;
            }
            finally
            { 
                //DO CLEANUP TASKS HERE
            }
            return response;
        }
    }
}
