using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebService.Models;

namespace WebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdOrderController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody] List<Flo> flolist)
        {
            int sum = 0;
            Flower fs = new Flower();

            foreach (var item in flolist) {
                sum += item.value;        
            }

            fs.total = sum;

            return Ok(fs);
        }
    }
}
