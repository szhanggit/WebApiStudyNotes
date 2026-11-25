using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSClient.Models
{
    public class LoginModelRequest
    {
        public string AccountName { get; set; }
        public string AccountPwd { get; set; }
    }
}