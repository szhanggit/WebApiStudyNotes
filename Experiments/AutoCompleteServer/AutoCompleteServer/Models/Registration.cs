using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class Registration : PersonInfo
    {
        private List<Event> _list;
        public Registration()
        {
            _list = new List<Event>();
        }

        public List<Event> list {
            get { return _list; }
        }
    }
}