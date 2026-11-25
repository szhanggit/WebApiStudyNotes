using MPSServer2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace MPSServer2.Controllers
{
    public class AccountInfoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(int? i)
        {
            try
            {
                IEnumerable<string> AuthCode = null;                
                Request.Headers.TryGetValues("Authorization", out AuthCode);
                string value = HttpContext.Current.Request.Headers["Authorization"];
                KeyValuePair<string,IEnumerable<string>> header = Request.Headers.FirstOrDefault(h => h.Key.Equals("Authorization"));

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

                //_logger.Info(response == null ? string.Empty : JsonConvert.SerializeObject(response));

                return Json(response);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }


        [HttpPost]
        public IHttpActionResult Post(MPSAccountRequest accountInfo)
        {
            try
            {
                IEnumerable<string> AuthCode = null;                
                Request.Headers.TryGetValues("Authorization", out AuthCode);
                string value = HttpContext.Current.Request.Headers["Authorization"];
                Thread.Sleep(5000);
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

                //_logger.Info(response == null ? string.Empty : JsonConvert.SerializeObject(response));

                return Json(response);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }        

        /*
            Post:	http://localhost:65232/api/AccountInfo/
            Body	->	raw	(JSON)
            {"AccountName":"stzhang","AccountPwd":"WelcomeMar2021"}
            Headers
            Content-Type:application/json         
         */


        [HttpDelete]
        public IHttpActionResult Delete(MPSAccountRequest accountInfo)
        {
            try
            {
                //_logger.Info(accountInfo == null ? string.Empty : JsonConvert.SerializeObject(accountInfo));

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

                //_logger.Info(response == null ? string.Empty : JsonConvert.SerializeObject(response));

                return Json(response);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        /*
            Delete:	http://localhost:65232/api/AccountInfo/
            Body	->	raw	(JSON)
            {"AccountName":"stzhang","AccountPwd":"WelcomeMar2021"}
            Headers
            Content-Type:application/json         
         */
    }
}
