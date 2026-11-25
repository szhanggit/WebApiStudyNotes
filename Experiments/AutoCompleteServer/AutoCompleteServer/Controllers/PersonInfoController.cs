using AutoCompleteServer.AutoCompleteServer.Lib;
using AutoCompleteServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Text;

namespace AutoCompleteServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonInfoController : ApiController
    {
        public PersonInfoController()
        {

        }

        /*
            Post:	http://localhost:56871/api/PersonInfo/
            Body	->	raw	(JSON)
            {"emailTextBox":"137445443@qq.com","mobileTextBox":"13280119966","homePhoneTextBox":"62044902","postCodeTextBox":"200063"}
            {"emailTextBox":"137445443@qq.com","mobileTextBox":"13280119966","homePhoneTextBox":"62044902","postCodeTextBox":"200063","vehicle":["Bike","Car","Boat"]}
            Headers
            Content-Type:application/json         
         */
        // POST api/values
        public IHttpActionResult Post([FromBody]PersonInfo value)
        {
            Thread.Sleep(2000);
            return Json(value);
        }

        /*
            Post:	http://localhost:56871/api/p2/
            Body	->	raw	(JSON)
            {"emailTextBox":"137445443@qq.com","mobileTextBox":"13280119966","homePhoneTextBox":"62044902","postCodeTextBox":"200063"}
            {"emailTextBox":"137445443@qq.com","mobileTextBox":"13280119966","homePhoneTextBox":"62044902","postCodeTextBox":"200063","vehicle":["Bike","Car","Boat"]}
            Headers
            Content-Type:application/json         
         */
        [HttpPost]
        [Route("api/p2")]
        public IHttpActionResult MultiFormTest([FromBody]PersonInfo value)
        {
            Thread.Sleep(2000);
            return Json(value);
        }

        /*
            Post:	http://localhost:56871/api/Register/
            Body	->	raw	(JSON)
            {"emailTextBox":"137445443@qq.com","mobileTextBox":"13280119966","homePhoneTextBox":"62044902","postCodeTextBox":"200063","list":[{"Id":0,"eventName":"asdfadsf","startDateTime":"2021-01-05T10:09","endDateTime":"2021-01-06T10:09","fee":"23.34"},{"Id":1,"eventName":"wertwert","startDateTime":"2021-01-08T10:09","endDateTime":"2021-01-09T10:09","fee":"24.34"},{"Id":2,"eventName":"fhgfhg","startDateTime":"2021-01-08T10:09","endDateTime":"2021-01-09T10:09","fee":"25.34"},{"Id":3,"eventName":"yuoiyoi","startDateTime":"2021-01-08T10:09","endDateTime":"2021-01-09T10:09","fee":"26.34"}]}
            Headers
            Content-Type:application/json         
         */
        [HttpPost]
        [Route("api/Register")]
        public IHttpActionResult Register([FromBody]Registration value)
        {
            Thread.Sleep(2000);
            return Json(value);
        }

        [HttpPost]
        [Route("api/Register2")]
        public IHttpActionResult Register2([FromBody]Registration value)
        {
            StringBuilder ExceptionMessage = new StringBuilder();
            string EditException = string.Empty;
            string DeleteException = string.Empty;
            string AddException = string.Empty;
            EventResponse response = new EventResponse();
            response.ResponseCode = "9999";
            Event e = new Event();
            List<Event> EventList = new List<Event>();
            List<Event> DeleteList = new List<Event>();
            List<Event> EditList = new List<Event>();
            List<Event> AddList = new List<Event>();
            if (value.list.Count() > 0)
            {
                DeleteList = value.list.FindAll(item => item.Status == 4);
                if (DeleteList.Count() > 0)
                {
                    e.DeleteEvents(DeleteList.Select(t => t.Id).ToList(), out DeleteException);
                    if (!string.IsNullOrEmpty(DeleteException))
                    {
                        ExceptionMessage.AppendLine(DeleteException);
                    }
                }
                EditList = value.list.FindAll(item => item.Status == 2);
                if (EditList.Count() > 0)
                {
                    e.EditEvents(EditList, out EditException);
                    if (!string.IsNullOrEmpty(EditException))
                    {
                        ExceptionMessage.AppendLine(EditException);
                    }
                }
                AddList = value.list.FindAll(item => item.Status == 3);
                if (AddList.Count() > 0)
                {
                    e.AddEvents(AddList, out AddException);
                    if (!string.IsNullOrEmpty(AddException))
                    {
                        ExceptionMessage.AppendLine(AddException);
                    }
                }
                EventList = e.QueryEventList();
                response.EventList.AddRange(EventList);
                if (string.IsNullOrEmpty(ExceptionMessage.ToString()))
                {
                    response.ResponseCode = "0000";
                }
                else
                {
                    response.ResponseMessage = ExceptionMessage.ToString();
                }
            }
            return Json(response);
        }
    }
}
