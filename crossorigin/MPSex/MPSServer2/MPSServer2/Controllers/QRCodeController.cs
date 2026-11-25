using MPSServer2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using ThoughtWorks.QRCode.Codec;

namespace MPSServer2.Controllers
{
    public class QRCodeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string code, int scale)
        {
            string sCode = string.Empty;  
            MemoryStream oStream = new MemoryStream();
            try
            {
                Image oImg = GetQRCode(code, scale);
                oImg.Save(oStream, System.Drawing.Imaging.ImageFormat.Png);
                oImg.Dispose();

                byte[] bytes = oStream.ToArray();
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(bytes);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/Png");

                return result;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            }
            finally
            {
                oStream.Dispose();
            }
        }

        public Image GetQRCode(string text, int scale)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeVersion = 0;

            qrCodeEncoder.QRCodeScale = scale;
            Image image = qrCodeEncoder.Encode(text);

            return image;
        }
    }
}
