using System.Web.Http;
using ExampleApp.Models;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ExampleApp.Controllers {
    public class BindingsController : ApiController {
        private IRepository repo;

        public BindingsController(IRepository repoArg) {
            repo = repoArg;
        }

        [HttpGet]
        [HttpPost]
        public IHttpActionResult SumNumbers()
        {
            Dictionary<string, string> jqData = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);

            int firstValue, secondValue;
            if (TryGetValues(jqData, "first", "second", out firstValue, out secondValue))
            {
                return Ok(firstValue + secondValue);
            }
            else if (TryGetValues(jqData, "value1", "value2", out firstValue, out secondValue))
            {
                return Ok(firstValue - secondValue);
            }
            else
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        private bool TryGetValues(Dictionary<string, string> data, string key1, string key2, out int val1, out int val2)
        {
            val1 = val2 = 0;
            return data.ContainsKey(key1) && data.ContainsKey(key2) && int.TryParse(data[key1], out val1) && int.TryParse(data[key2], out val2);
        }
    }
}
