using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.AutoCompleteServer.Lib
{
    public class ScriptManager
    {
        public static string GetClients()
        {
            string sql = @"SELECT [Name]
                            ,IdentityCode
                            ,InvoiceRegisterNumber
                            ,CRMReference
                            ,FinanceReference
                            ,Department
                            ,[Status]
                            ,[Description]
                            ,Modifier
                            ,VersionTime
                            ,SecurityKey
                            ,Title
                            ,EmailSenderName
                            ,EmailSenderAddress 
                            FROM Client WITH (NOLOCK) WHERE [Name] like @ClientSearchingName";
            return sql;
        }

        public static string GetQuotationList()
        {
            string sql = @"SELECT ClientId, QuotationNumber, ValidFrom, validTo, ProjectCode, ProjectName
                            FROM ClientQuotation WITH (NOLOCK)";
            return sql;
        }

        public static string GetDictionaryList()
        {
            string sql = @"select Id, Category, [Name], DisplayName from Dictionary with(nolock)";
            return sql;
        }

        public static string GetMerchantList()
        {
            string sql = @"select IdentityCode, [Name], 
            ExternalCode, InvoiceRegisterNumber, ContactName1, ContactPhone1, SecurityKey,
            Modifier, MAMEmail, MerchantEmail from Merchant with(nolock)";
            return sql;
        }

        public static string GetEventList()
        {
            string sql = @"select * from [Event] with(nolock)";
            return sql;
        }
    }
}