using System;
using System.Web.Http;

namespace ExampleApp.Controllers {
    public class FormatsController : ApiController {

        public DataObject GetData() {
            return new DataObject {
                Time = DateTime.Now,
                Text = "Joe <b>Smith</b>",
                Count = 0
            };
        }
    }

    /*
     Get:   http://localhost:29844/api/Formats
     Headers:   
     Content-Type       application/json
     */

    public class DataObject {
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public int Count { get; set; }
    }
}
