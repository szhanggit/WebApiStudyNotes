using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public static class ConfigureHelper
    {
        public static string ConfigStringValue(this string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
