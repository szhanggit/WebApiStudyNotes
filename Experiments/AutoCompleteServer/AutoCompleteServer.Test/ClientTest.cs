using System;
using System.Linq;
using System.Collections.Generic;
using AutoCompleteServer.AutoCompleteServer.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.SqlServer.Server;
using AutoCompleteServer.Models;

namespace AutoCompleteServer.Test
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestGetClient()
        {
            string ClientSearchingName = "C";
            var list = DataProvider.QueryClient(ClientSearchingName);
            
        }

        [TestMethod]
        public void TestQueryEvent()
        {
            var list = DataProvider.QueryEvent();
        }

        [TestMethod]
        public void TestEditEvent()
        {
            List<Event> EventList = null;
            var TypeEventListParameter = new List<SqlDataRecord>();
            var myMetaData = new SqlMetaData[] {
                    new SqlMetaData("Id", SqlDbType.Int),
                    new SqlMetaData("EventName", SqlDbType.NVarChar,100),
                    new SqlMetaData("StartDateTime", SqlDbType.DateTime),
                    new SqlMetaData("EndDateTime", SqlDbType.DateTime),
                    new SqlMetaData("Fee", SqlDbType.Decimal),
                    new SqlMetaData("Status", SqlDbType.Int)
                };

            EventList = (new Event()).GetTestingData();

            foreach (Event ev in EventList)
            {
                var record = new SqlDataRecord(myMetaData);
                record.SetValue(0, ev.Id);
                record.SetValue(1, ev.eventName);
                record.SetValue(2, ev.startDateTime);
                record.SetValue(3, ev.endDateTime);
                record.SetValue(4, ev.fee);
                record.SetValue(5, ev.Status);
                TypeEventListParameter.Add(record);
            }
            string message = string.Empty;
            int result = DataProvider.EditEventList(TypeEventListParameter, out message);
        }

        [TestMethod]
        public void TestDeleteEvent()
        {
            List<int> EventIdList = null;
            var TypeEventIdListParameter = new List<SqlDataRecord>();
            var myMetaData = new SqlMetaData[] {
                    new SqlMetaData("Id", SqlDbType.Int)
                };

            EventIdList = new List<int> { 8, 9, 10 };

            foreach (int ev in EventIdList)
            {
                var record = new SqlDataRecord(myMetaData);
                record.SetValue(0, ev);
                TypeEventIdListParameter.Add(record);
            }
            string message = string.Empty;
            int result = DataProvider.DeleteEventList(TypeEventIdListParameter, out message);
        }

        [TestMethod]
        public void TestAddEvent()
        {
            List<Event> EventList = null;
            var TypeEventListParameter = new List<SqlDataRecord>();
            var myMetaData = new SqlMetaData[] {
                    new SqlMetaData("Id", SqlDbType.Int),
                    new SqlMetaData("EventName", SqlDbType.NVarChar,100),
                    new SqlMetaData("StartDateTime", SqlDbType.DateTime),
                    new SqlMetaData("EndDateTime", SqlDbType.DateTime),
                    new SqlMetaData("Fee", SqlDbType.Decimal),
                    new SqlMetaData("Status", SqlDbType.Int)
                };

            EventList = (new Event()).GetTestingData();

            foreach (Event ev in EventList)
            {
                var record = new SqlDataRecord(myMetaData);
                record.SetValue(0, ev.Id);
                record.SetValue(1, ev.eventName);
                record.SetValue(2, ev.startDateTime);
                record.SetValue(3, ev.endDateTime);
                record.SetValue(4, ev.fee);
                record.SetValue(5, ev.Status);
                TypeEventListParameter.Add(record);
            }
            string message = string.Empty;
            int result = DataProvider.AddEvents(TypeEventListParameter, out message);
        }

        [TestMethod]
        public void TestProductPage()
        {
            PagingResult pr = new PagingResult();
            int page = 2;
            int size = 100;
            string Column = "Id";
            string SortDirection = "desc";
            string message = string.Empty;
            int totalRow = default(int);

            pr = DataProvider.QueryProductInPage(page, size, Column, SortDirection, out message, out totalRow);
        }
    }
}
