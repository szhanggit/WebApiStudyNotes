using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebService.Models;
using System.Text;

namespace WebService.Controllers { 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {

        [HttpPost]
        [Route("api/loadwithparams")]
        public HttpResponseMessage LoadWithParams([FromBody] Pair item)
        {
            switch (item.name) {
                case "1":
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("必需的 URL 参数规定您希望加载的 URL。")
                    };
                case "2":
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("可选的 data 参数规定与请求一同发送的查询字符串键/值对集合。")
                    };
                case "3":
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("可选的 callback 参数是 load() 方法完成后所执行的函数名称。")
                    };
                default:
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("Nothing")
                    };
            }

        }

        [HttpPost]
        [Route("api/adelete")]
        public IHttpActionResult AjaxDelete([FromBody] Pair item)
        {
            return Ok(item.name);
        }

        [HttpPost]
        [Route("api/validateuser")]
        public IHttpActionResult ValidateUser([FromBody] Account acc)
        {
            if (acc.UserName == "admin" && acc.Password == "123")
                return Ok(1);
            else
                return Ok(2);
        }

        /*
            Post:	http://localhost:17190/api/order/
            Body	->	raw	(JSON)
            {"astor":"3","daffodil":"2","rose":"2","peony":"1","primula":"1","snowdrop":"1","total":"10"}
            Headers
            Content-Type:application/json         
         */
        [HttpPost]
        public IHttpActionResult Post([FromBody] Flower flolist)
        {
            int sum = 0;
            //Flower fs = new Flower();

            foreach (var item in System.Web.HttpContext.Current.Request.Form.AllKeys)
            {
                //fs.flowers[item.ToString()] = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form[item.ToString()].ToString());
                sum += Convert.ToInt32(System.Web.HttpContext.Current.Request.Form[item.ToString()].ToString());
            }

            flolist.total = sum;

            return Json(flolist);
        }

        [HttpGet]
        public IHttpActionResult Get([FromBody] Flower flolist)
        {
            int sum = 0;
            Flower fs = new Flower();

            foreach (var item in System.Web.HttpContext.Current.Request.Form.AllKeys)
            {
                switch (item)
                {
                    case "astor": fs.astor = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form[item.ToString()].ToString()); break;
                }
                //fs.flowers[item.ToString()] = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form[item.ToString()].ToString());
                sum += Convert.ToInt32(System.Web.HttpContext.Current.Request.Form[item.ToString()].ToString());
            }

            fs.total = sum;

            return Ok(fs);
        }

        [HttpGet]
        [Route("api/list")]
        public IHttpActionResult GetList(string term)
        {
            string[] list = { "Aster", "Daffodil", "Rose", "Peony", "Primula", "Snowdrop",
                           "Poppy", "Primrose", "Petuna", "Pansy" };
            List<string> filtered = new List<string>();

            foreach (var item in list)
            {
                if (((string)item).ToLower().Contains(term.ToLower()))
                {
                    filtered.Add((string)item);
                }
            }


            return Ok(filtered);
        }

        [HttpGet]
        [Route("api/load")]
        public IHttpActionResult Load(int start)
        {
            int maxval = start;
            StringBuilder sb = new StringBuilder();
            int i = 1;
            while (i <= 50)                                     //循环向客户端输出数据
            {
                sb.AppendLine("行数 #" + maxval.ToString() + ": 当滚动到页面的底部时，将会自动的从服务器端加载其他的记录行信息，在很多网站中都可以看到这个应用。<br/>");
                i++;
                maxval++;
            }



            return Ok(sb.ToString());
        }

        [HttpGet]
        [Route("api/getformdata")]
        public IHttpActionResult GetFormData(string name, string email, string website, string comment)
        {
            return Ok(1);
        }

        [HttpGet]
        [Route("api/getdata")]
        public IHttpActionResult GetData(string country, string state)
        {
            return Ok(1);
        }

        [HttpGet]
        [Route("api/getwineinfo")]
        public IHttpActionResult GetWineInfo(string button)
        {
            //读取红酒和白酒数据
            List<string> red = new List<string>{ "基安蒂酒", "巴罗罗", "原产法国勃艮第" };
            List<string> white = new List<string> { "霞多丽", "卡瓦酒", "夏布利" };
            List<string> winetable = new List<string>();
            winetable.AddRange(red);
            winetable.AddRange(white);

            if (button == "red") {
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(red));    //使用json_encode转换JSON数据
            }
            else if (button == "white") {
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(white));
            }
            else {
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(winetable));
            }
        }
    }
}
