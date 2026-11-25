using AutoCompleteServer.AutoCompleteServer.Lib;
using AutoCompleteServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AutoCompleteServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientController : ApiController
    {
        public ClientController()
        {

        }

        /*
            Get:	http://localhost:56871/api/Client/Get?ClientName=C
            Headers
            Content-Type:application/json         
         */
        [HttpGet]
        public IHttpActionResult Get(string ClientName)
        {
            IEnumerable<Client> _clientList = new List<Client>();

            string author = HttpContext.Current.Request.Headers["Author"];
            string pb = HttpContext.Current.Request.Headers["Powered-By"];

            if (!string.IsNullOrEmpty(ClientName))
            {
                _clientList = DataProvider.QueryClient(ClientName);
            }
            

            return Ok(_clientList);
        }

        /*
            Get:	http://localhost:56871/api/cqlist
            Headers
            Content-Type:application/json         
         */
        [HttpGet]
        [Route("api/cqlist")]
        public IHttpActionResult GetCQList()
        {
            IEnumerable<ClientQuotation> _clientQuotationList = new List<ClientQuotation>();
            _clientQuotationList = DataProvider.QueryClientQuotation();
            return Ok(_clientQuotationList);
        }

        /*
            Get:	http://localhost:56871/api/diclist
            Headers
            Content-Type:application/json         
         */
        [HttpGet]
        [Route("api/diclist")]
        public IHttpActionResult GetDicList()
        {
            IEnumerable<Dictionary> _dictionaryList = new List<Dictionary>();
            _dictionaryList = DataProvider.QueryDictionary();
            return Ok(_dictionaryList);
        }

        /*
            Get:	http://localhost:56871/api/merchantlist
            Headers
            Content-Type:application/json         
         */
        [HttpGet]
        [Route("api/merchantlist")]
        public IHttpActionResult GetMerList()
        {
            IEnumerable<Merchant> _merchantList = new List<Merchant>();
            _merchantList = DataProvider.QueryMerchant();
            return Ok(_merchantList);
        }

        /*
            Get:	http://localhost:56871/api/eventlist
            Headers
            Content-Type:application/json         
         */
        [HttpGet]
        [Route("api/eventlist")]
        public IHttpActionResult GetEventList()
        {
            Event e = new Event();
            List<Event> _eventList = new List<Event>();
            _eventList = e.QueryEventList();
            return Ok(_eventList);
        }
    }
}
