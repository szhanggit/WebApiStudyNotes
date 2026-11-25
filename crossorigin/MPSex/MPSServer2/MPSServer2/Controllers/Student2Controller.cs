using MPSServer2.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MPSServer2.Controllers
{
    public class Student2Controller : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Post(MPSAccountRequest accountInfo)
        {
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
