using MPSServer2.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MPSServer2.Controllers
{
    public class FormController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get(string code)
        {



            var response = new MPSAccountInfoResponse()
            {
                IsSuccess = true,
                ErrorMsg = "Everything is good",
                UserRoleValue = 2,
                FeatureList = new List<AccountRoleViewModel> {
                        new AccountRoleViewModel{ Id= 2, RoleName = "Admin", RoleValue = 3 }
                    },
                Merchants = new List<ShopAccountByMerchantViewModel> {
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000023", MerchantName = "McDonald" },
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000024", MerchantName = "KFC" },
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000025", MerchantName = "BubbleTea" },
                    }
            };


            return Ok(response);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            string fileName = string.Empty;
            // Check if the request contains multipart/form-data.  
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
            //access form data  
            NameValueCollection formData = provider.FormData;
            string AccountName = formData["AccountName"];
            string AccountPwd = formData["AccountPwd"];
            //access files  
            IList<HttpContent> files = provider.Files;
            Stream sc = files.FirstOrDefault().ReadAsStreamAsync().Result;            
            string StrHeader = files.FirstOrDefault().Headers.ToString();
            var HeaderArr = StrHeader.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (string item in HeaderArr)
            {
                var ItemArr = item.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string tempItem = ItemArr[0].Trim();
                if (tempItem.Equals("filename", StringComparison.InvariantCultureIgnoreCase))
                {
                    fileName = ItemArr[1];
                    using (Stream file = File.Create(Path.Combine(@"D:\Study\WebApiStudyNotes\crossorigin\MPSex\MPSServer2\", fileName)))
                    {
                        CommonMethod.CopyStream(sc, file);
                    }
                }
            }

            var content = Request.Content;
            string value = HttpContext.Current.Request.Headers["Authorization"];


            var response = new MPSAccountInfoResponse()
            {
                IsSuccess = true,
                ErrorMsg = "Everything is good",
                UserRoleValue = 2,
                FeatureList = new List<AccountRoleViewModel> {
                        new AccountRoleViewModel{ Id= 2, RoleName = "Admin", RoleValue = 3 }
                    },
                Merchants = new List<ShopAccountByMerchantViewModel> {
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000023", MerchantName = "McDonald" },
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000024", MerchantName = "KFC" },
                        new ShopAccountByMerchantViewModel{ MerchantCode = "000000000025", MerchantName = "BubbleTea" },
                    }
            };


            return Ok(response);
        }
    }
}
