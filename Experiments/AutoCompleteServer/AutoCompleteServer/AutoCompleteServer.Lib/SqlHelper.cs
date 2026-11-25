using System.Configuration;

namespace AutoCompleteServer.AutoCompleteServer.Lib
{
    public class SqlHelper
    {
        private static string _connectionStringName = "MODB";

        public static string MOConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString;
            }
        }
    }
}