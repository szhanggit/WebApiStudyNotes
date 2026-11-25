using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSClient.Models
{
    public class CheckAccountExistsViewModel
    {
        public bool IsSuccess { get; set; }
        public string ErrorMsg { get; set; }
    }
}