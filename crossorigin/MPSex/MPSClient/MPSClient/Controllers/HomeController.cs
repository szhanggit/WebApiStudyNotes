using LitJson;
using MPSClient.Infrastructure;
using MPSClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MPSClient.Controllers
{
    public class HomeController : Controller
    {
        readonly string AccountRequstUrl = @"http://localhost:65232/";
        readonly string BackEndAccountTarget = @"api/AccountInfo";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            LoginModelRequest model = new LoginModelRequest {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };

            UserRoleResponse response = RequestHelper.MakeRequest<UserRoleResponse>(model, AccountRequstUrl,
                       "GET", BackEndAccountTarget, null, "application/json", true, true);
            //UserRoleResponse response = RequestHelper.MakeRequest<UserRoleResponse>(model, AccountRequstUrl,
            //        "POST", BackEndAccountTarget, null, "application/json", true, true);
            //UserRoleResponse response = RequestHelper.MakeRequest<UserRoleResponse>(model, AccountRequstUrl,
            //          "DELETE", BackEndAccountTarget, null, "application/json", true, true);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            string userAuthenticationURI = @"http://localhost:65232/api/AccountInfo";
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
                    string status = data["IsSuccess"].ToString();
                    if (status.ToLower() == "true")
                    {
                        UserRoleResponse result = JsonMapper.ToObject<UserRoleResponse>(ApiStatus);
                    }
                }
            }

            return View();
        }

        public ActionResult Start()
        {
            /*
             https://www.cnblogs.com/shiningrise/p/10912362.html
             */
            //string AccountName = "stzhang";
            //string AccountPwd = "WelcomeMar2021";
            //string content = "AccountName=" + AccountName + "&AccountPwd=" + AccountPwd;
            string url = "http://localhost:65232/api/AccountInfo";
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };
            string content = JsonConvert.SerializeObject(model);

            try
            {
                //获取提交的字节
                byte[] bs = Encoding.UTF8.GetBytes(content);
                //设置提交的相关参数
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "POST";
                //req.ContentType = "application/x-www-form-urlencoded";
                req.ContentType = "application/json";
                req.ContentLength = bs.Length;
                //提交请求数据
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
                //接收返回的页面，必须的，不能省略
                WebResponse wr = req.GetResponse();
                System.IO.Stream respStream = wr.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("utf-8"));
                string result = reader.ReadToEnd();
                UserRoleResponse obj = JsonConvert.DeserializeObject<UserRoleResponse>(result);
                wr.Close();
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("异常在getPostRespone:" + ex.Source + ":" + ex.Message);
            }



            return View();
        }

        public ActionResult Delete()
        {
            /*
             https://www.cnblogs.com/shiningrise/p/10912362.html
             */
            //string AccountName = "stzhang";
            //string AccountPwd = "WelcomeMar2021";
            //string content = "AccountName=" + AccountName + "&AccountPwd=" + AccountPwd;
            string url = "http://localhost:65232/api/AccountInfo";
            LoginModelRequest model = new LoginModelRequest
            {
                AccountName = "stzhang",
                AccountPwd = "WelcomeMar2021"
            };
            string content = JsonConvert.SerializeObject(model);

            try
            {
                //获取提交的字节
                byte[] bs = Encoding.UTF8.GetBytes(content);
                //设置提交的相关参数
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "DELETE";
                //req.ContentType = "application/x-www-form-urlencoded";
                req.ContentType = "application/json";
                req.ContentLength = bs.Length;
                //提交请求数据
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
                //接收返回的页面，必须的，不能省略
                WebResponse wr = req.GetResponse();
                System.IO.Stream respStream = wr.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("utf-8"));
                string result = reader.ReadToEnd();
                UserRoleResponse obj = JsonConvert.DeserializeObject<UserRoleResponse>(result);
                wr.Close();
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("异常在getPostRespone:" + ex.Source + ":" + ex.Message);
            }



            return View();
        }
    }
}