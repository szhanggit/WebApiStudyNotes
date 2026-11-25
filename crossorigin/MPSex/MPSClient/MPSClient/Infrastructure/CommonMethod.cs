using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPSClient.Infrastructure
{
    public class CommonMethod
    {
        public static string FormatHtmlImage(string source)
        {
            return string.Format("<img src={0} />", source);
        }
    }
}