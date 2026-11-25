using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class EventResponse
    {
        List<Event> _eventList = null;
        public EventResponse()
        {
            _eventList = new List<Event>();
        }

        public List<Event> EventList { get { return _eventList; } }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}