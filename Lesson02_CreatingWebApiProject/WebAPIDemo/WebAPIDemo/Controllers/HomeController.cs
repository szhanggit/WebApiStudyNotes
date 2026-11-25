using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebAPIDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public void GetData()
        {
            try
            {
                string userAuthenticationURI = "http://localhost:14746/api/values";

                if (!string.IsNullOrEmpty(userAuthenticationURI))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(userAuthenticationURI);
                    request.Method = "GET";
                    request.ContentType = "application/json";
                    WebResponse response = request.GetResponse();
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var ApiStatus = reader.ReadToEnd();
                        JsonData data = JsonMapper.ToObject(ApiStatus);
                        //string status = data["Status"].ToString();
                        //if (status.ToLower() == "success")
                        //{
                        //    postOfficeResult = JsonMapper.ToObject<PostOfficeResult>(ApiStatus);

                        //}
                    }
                }
            }
            catch
            {
            }
        }
    }
}
