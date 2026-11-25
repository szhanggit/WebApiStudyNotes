using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSClient.Models
{
    public class AccountInfoResponse : CheckAccountExistsViewModel
    {
        public int UserRoleValue { get; set; }
        public List<AccountRoleViewModel> FeatureList { get; set; }
        public List<ShopAccountByMerchantViewModel> Merchants { get; set; }
    }
}