using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AutoCompleteServer.Models;
using Dapper;
using Microsoft.SqlServer.Server;

namespace AutoCompleteServer.AutoCompleteServer.Lib
{
    public class DataProvider
    {
        public static IEnumerable<Client> QueryClient(string ClientSearchingName)
        {
            IEnumerable<Client> _list = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                connection.Open();
                _list = DapperHelper.MO_Query<Client>(connection
                    , ScriptManager.GetClients()
                    , new { ClientSearchingName = $"{ClientSearchingName}%" });
                connection.Close();
            }

            return _list;
        }

        public static IEnumerable<ClientQuotation> QueryClientQuotation()
        {
            IEnumerable<ClientQuotation> _list = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                connection.Open();
                _list = DapperHelper.MO_Query<ClientQuotation>(connection
                    , ScriptManager.GetQuotationList());
                connection.Close();
            }

            return _list;
        }

        public static IEnumerable<Dictionary> QueryDictionary()
        {
            IEnumerable<Dictionary> _list = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                connection.Open();
                _list = DapperHelper.MO_Query<Dictionary>(connection
                    , ScriptManager.GetDictionaryList());
                connection.Close();
            }

            return _list;
        }

        public static IEnumerable<Merchant> QueryMerchant()
        {
            IEnumerable<Merchant> _list = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                connection.Open();
                _list = DapperHelper.MO_Query<Merchant>(connection
                    , ScriptManager.GetMerchantList());
                connection.Close();
            }

            return _list;
        }

        public static IEnumerable<Event> QueryEvent()
        {
            IEnumerable<Event> _list = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                connection.Open();
                _list = DapperHelper.MO_Query<Event>(connection
                    , ScriptManager.GetEventList());
                connection.Close();
            }

            return _list;
        }

        public static int EditEventList(List<SqlDataRecord> TypeEventListParameter, out string message)
        {
            int result = default(int);
            string errorMessage = string.Empty;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("@ErrorMessage", errorMessage, direction: ParameterDirection.Output);
                    p.Add("@Events", TypeEventListParameter.AsTableValuedParameter("Event_Input"));
                    p.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    connection.MO_QueryFirstOrDefault<int>("spEditEvents", p, 
                        commandType: CommandType.StoredProcedure);

                    errorMessage = p.Get<string>("@ErrorMessage");
                    result = p.Get<int>("@RESULT");
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                message = errorMessage;
                return result;
            }
        }

        public static int DeleteEventList(List<SqlDataRecord> TypeEventIdListParameter, out string message)
        {
            int result = default(int);
            string errorMessage = string.Empty;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("@ErrorMessage", errorMessage, direction: ParameterDirection.Output);
                    p.Add("@Events", TypeEventIdListParameter.AsTableValuedParameter("EventIdList_Input"));
                    p.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    connection.MO_QueryFirstOrDefault<int>("spDeleteEvents", p,
                        commandType: CommandType.StoredProcedure);

                    errorMessage = p.Get<string>("@ErrorMessage");
                    result = p.Get<int>("@RESULT");
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                message = errorMessage;
                return result;
            }
        }

        public static int AddEvents(List<SqlDataRecord> TypeEventListParameter, out string message)
        {
            int result = default(int);
            string errorMessage = string.Empty;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("@ErrorMessage", errorMessage, direction: ParameterDirection.Output);
                    p.Add("@Events", TypeEventListParameter.AsTableValuedParameter("Event_Input"));
                    p.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    connection.MO_QueryFirstOrDefault<int>("spAddEvents", p,
                        commandType: CommandType.StoredProcedure);

                    errorMessage = p.Get<string>("@ErrorMessage");
                    result = p.Get<int>("@RESULT");
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                message = errorMessage;
                return result;
            }
        }

        public static PagingResult QueryProductInPage(int page, int size, string Column, string SortDirection, out string message, out int row, int? VoucherNumberGenerateWay = null)
        {
            int result = default(int);
            int totalRow = default(int);
            PagingResult pr = new PagingResult();
            pr.PageNumber = page;
            pr.PageSize = size;            
            string errorMessage = string.Empty;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MODB"].ConnectionString))
            {
                try
                {
                    var p = new DynamicParameters();

                    if (VoucherNumberGenerateWay.HasValue)
                    {
                        p.Add("@VoucherNumberGenerateWay", VoucherNumberGenerateWay.Value, DbType.Int32);
                    }

                    p.Add("@page", page, DbType.Int32);
                    p.Add("@size", size, DbType.Int32);
                    p.Add("@sort", Column, DbType.String);
                    p.Add("@sortdirection", SortDirection, DbType.String);
                    p.Add("@ErrorMessage", errorMessage, direction: ParameterDirection.Output);
                    p.Add("@totalrow", totalRow, direction: ParameterDirection.Output);
                    p.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var list = connection.MO_Query<Product>("sp_Product", p, commandType: CommandType.StoredProcedure);
                    foreach (Product product in list)
                    {
                        pr.ProductList.Add(product);
                    }

                    errorMessage = p.Get<string>("@ErrorMessage");
                    totalRow = p.Get<int>("@totalrow");
                    result = p.Get<int>("@RESULT");
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

                pr.TotalRows = totalRow;
                pr.TotalPage = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalRow) / Convert.ToDecimal(size)));
                row = totalRow;
                message = errorMessage;
                return pr;
            }
        }
    }
}