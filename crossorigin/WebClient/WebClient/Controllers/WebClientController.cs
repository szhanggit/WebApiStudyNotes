using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace WebClient.Controllers
{
    public class WebClientController : Controller
    {
        // GET: WebClient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostMethod()
        {
            string URI = "http://www.myurl.com/post.php";
            string myParameters = "param1=value1&param2=value2&param3=value3";

            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                string HtmlResult = wc.UploadString(URI, myParameters);
            }


            return View("Index");
        }
    }
}