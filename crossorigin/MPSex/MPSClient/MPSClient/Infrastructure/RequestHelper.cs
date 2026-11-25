using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace MPSClient.Infrastructure
{
    public class RequestHelper
    {
        public static T MakeRequest<T>(object model, string baseUrl, string method, string target, Dictionary<string, string> headers = null, string contentType = "application/json", bool keepAlive = true, bool ignoreSsl = false, SecurityProtocolType? protocolType = null)
        {
            try
            {
                var result = MakeRequestString(model, baseUrl, method, target, headers, contentType, keepAlive, ignoreSsl, protocolType);
                if (result != null)
                {
                    var obj = JsonConvert.DeserializeObject<T>(result);
                    if (obj != null)
                    {
                        return obj;
                    }
                }
            }
            catch (Exception ex)
            {
                //LogExtention.Error("RequestHelper", new { RequestModel = JsonConvert.SerializeObject(model) }, ex);
            }
            return default(T);
        }

        public static string MakeRequestString(object model, string baseUrl, string method, string target, Dictionary<string, string> headers = null, string contentType = "application/json", bool keepAlive = true, bool ignoreSsl = false, SecurityProtocolType? protocolType = null)
        {
            try
            {
                var request = GetHttpWebRequest(model, baseUrl, method, target, headers, contentType, keepAlive, ignoreSsl, protocolType);
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response != null)
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8")))
                            {
                                string msg = reader.ReadToEnd();
                                return msg;
                            }
                        }
                    }
                    else
                    {
                        return "null response";
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            string msg = reader.ReadToEnd();
                            return msg;
                        }
                    }
                }
                else
                {
                    return ex.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static HttpWebRequest GetHttpWebRequest(object model, string baseUrl, string method, string target, Dictionary<string, string> headers = null, string contentType = "application/json", bool keepAlive = true, bool ignoreSsl = false, SecurityProtocolType? protocolType = null)
        {
            var bytes = new byte[] { };
            if (model != null)
            {
                if (model.GetType() == typeof(string))
                {
                    bytes = Encoding.UTF8.GetBytes((string)model);
                }
                else if (model.GetType() == typeof(byte[]))
                {
                    bytes = (byte[])model;
                }
                else
                {
                    var b = JsonConvert.SerializeObject(model);
                    bytes = Encoding.UTF8.GetBytes(b);
                }
            }
            return GetHttpWebRequestWithByte(bytes, baseUrl, method, target, headers, contentType, keepAlive, ignoreSsl, protocolType);
        }

        public static HttpWebRequest GetHttpWebRequestWithByte(byte[] bytes, string baseUrl, string method, string target, Dictionary<string, string> headers = null, string contentType = "application/json", bool keepAlive = true, bool ignoreSsl = false, SecurityProtocolType? protocolType = null)
        {
            Uri uri = new Uri(string.Format("{0}/{1}", baseUrl.TrimEnd('/'), target.TrimStart('/')));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.KeepAlive = keepAlive;
            request.ContentType = contentType;

            if (protocolType != null)
            {
                ServicePointManager.SecurityProtocol = protocolType.Value;
            }

            if (ignoreSsl)
            {
                request.ServerCertificateValidationCallback = delegate { return true; };
            }

            if (headers != null)
            {
                foreach (var item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            if (bytes.Length > 0)
            {               
                //using (Stream postStream = request.GetRequestStream())
                //{
                //    postStream.Write(bytes, 0, bytes.Length);
                //    postStream.Close();
                //}

                if (method.ToLower() == "get")
                {

                }
                else
                {
                    request.ContentLength = bytes.Length;
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(bytes, 0, bytes.Length);
                    reqStream.Close();
                }

            }
            else
            {
                request.ContentLength = 0;
            }
            return request;
        }

        public static HttpResponseMessage MakeDownLoadFileRequest<T>(object model, string baseUrl, string method, string target, string fileName)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"{baseUrl}/{target}");
                var m = (T)model;
                var b = JsonConvert.SerializeObject(m);
                var data = Encoding.UTF8.GetBytes(b);

                request.Method = method;
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                return DOWNLOAD_FILE((HttpWebResponse)request.GetResponse(), fileName);
            }
            catch (Exception ex)
            {
                throw ex;
                // logger
            }
        }

        private static HttpResponseMessage DOWNLOAD_FILE(HttpWebResponse response, string fileName)
        {
            byte[] buffer = new byte[4096];

            Stream stream = response.GetResponseStream();

            // processing the stream.
            var result = new HttpResponseMessage();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int count = 0;
                do
                {
                    count = stream.Read(buffer, 0, buffer.Length);
                    memoryStream.Write(buffer, 0, count);
                    result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(memoryStream.ToArray())
                    };
                } while (count != 0);
            }
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return result;
        }
    }
}