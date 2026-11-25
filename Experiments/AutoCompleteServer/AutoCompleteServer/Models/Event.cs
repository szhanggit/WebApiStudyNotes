using AutoCompleteServer.AutoCompleteServer.Lib;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class Event
    {
        List<Event> _eventList = null;
        public Event()
        {

        }

        public int Id { set; get; }
        public string eventName { set; get; }
        public DateTime startDateTime { set; get; }
        public DateTime endDateTime { set; get; }
        public Decimal fee { set; get; }
        public int Status { set; get; }

        public List<Event> GetTestingData() {
            _eventList = new List<Event> {
                new Event(){ Id = 1, eventName="Badminton", startDateTime = new DateTime(2021,1,4), endDateTime = new DateTime(2021,2,6), fee = 23.23m, Status = 1 },
                new Event(){ Id = 2, eventName="Boxing", startDateTime = new DateTime(2021,1,5), endDateTime = new DateTime(2021,2,7), fee = 23.23m, Status = 0 },
            };

            return _eventList;
        }

        public List<Event> QueryEventList()
        {
            IEnumerable<Event> _eventList = new List<Event>();
            _eventList = DataProvider.QueryEvent();

            return _eventList.ToList();
        }

        public bool EditEvents(List<Event> EventList, out string Message)
        {
            if (EventList.Count() == 0)
            {
                Message = string.Empty;
                return true;
            }
            var TypeEventListParameter = new List<SqlDataRecord>();
            var myMetaData = new SqlMetaData[] {
                    new SqlMetaData("Id", SqlDbType.Int),
                    new SqlMetaData("EventName", SqlDbType.NVarChar,100),
                    new SqlMetaData("StartDateTime", SqlDbType.DateTime),
                    new SqlMetaData("EndDateTime", SqlDbType.DateTime),
                    new SqlMetaData("Fee", SqlDbType.Decimal),
                    new SqlMetaData("Status", SqlDbType.Int)
                };

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
            Message = message;
            return (result == 1) ? true : false;
        }

        public bool DeleteEvents(List<int> EventIdList, out string Message)
        {
            if (EventIdList.Count() == 0)
            {
                Message = string.Empty;
                return true;
            }
            var TypeEventIdListParameter = new List<SqlDataRecord>();
            var myMetaData = new SqlMetaData[] {
                    new SqlMetaData("Id", SqlDbType.Int)
                };
            
            foreach (int ev in EventIdList)
            {
                var record = new SqlDataRecord(myMetaData);
                record.SetValue(0, ev);
                TypeEventIdListParameter.Add(record);
            }
            string innerMessage = string.Empty;
            int result = DataProvider.DeleteEventList(TypeEventIdListParameter, out innerMessage);
            Message = innerMessage;
            return (result == 1) ? true : false;
        }

        public bool AddEvents(List<Event> EventList, out string Message)
        {
            var TypeEventListParameter = new List<SqlDataRecord>();
            var myMetaData = new SqlMetaData[] {
                    new SqlMetaData("Id", SqlDbType.Int),
                    new SqlMetaData("EventName", SqlDbType.NVarChar,100),
                    new SqlMetaData("StartDateTime", SqlDbType.DateTime),
                    new SqlMetaData("EndDateTime", SqlDbType.DateTime),
                    new SqlMetaData("Fee", SqlDbType.Decimal),
                    new SqlMetaData("Status", SqlDbType.Int)
                };

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
            Message = message;
            return (result == 1) ? true : false;
        }
    }
}