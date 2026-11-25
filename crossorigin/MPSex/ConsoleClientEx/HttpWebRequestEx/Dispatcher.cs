using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebRequestEx
{
    public class Dispatcher
    {
        public Dispatcher()
        {

        }

        public void Send()
        {
            string url = "http://localhost/MPSServer2/api/AccountInfo";
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
                req.ContentType = "application/json";
                req.ContentLength = bs.Length;
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Send Request");

                //提交请求数据
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
                //接收返回的页面，必须的，不能省略
                WebResponse wr = req.GetResponse();
                System.IO.Stream respStream = wr.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("utf-8"));
                string result = reader.ReadToEnd();
                Console.WriteLine($"Response: {result}");
                wr.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        public async void SendAsync()
        {
            string url = "http://localhost/MPSServer2/api/AccountInfo";
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
                req.ContentType = "application/json";
                req.ContentLength = bs.Length;
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Send Request");

                //提交请求数据
                Stream reqStream = await req.GetRequestStreamAsync();
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
                //接收返回的页面，必须的，不能省略
                WebResponse wr = await req.GetResponseAsync();   
                Stream respStream = wr.GetResponseStream();   
                StreamReader reader = new StreamReader(respStream, Encoding.GetEncoding("utf-8"));
                string result = await reader.ReadToEndAsync();                  
                Console.WriteLine($"Response: {result}");
                wr.Close();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
