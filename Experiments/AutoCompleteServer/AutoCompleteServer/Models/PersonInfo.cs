using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class PersonInfo
    {
        public PersonInfo()
        {

        }

        public string emailTextBox { get; set; }
        public string mobileTextBox { get; set; }
        public string homePhoneTextBox { get; set; }
        public string postCodeTextBox { get; set; }
        public string fav_language { get; set; }
        public List<string> vehicle { get; set; }
        public string colorPicker { get; set; }
        public string datePicker { get; set; }
        public int Mark { get; set; }
    }
}