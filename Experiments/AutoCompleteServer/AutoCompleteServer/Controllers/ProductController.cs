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
    public class ProductController : ApiController
    {
        public ProductController()
        {

        }

        /*
            Get:	http://localhost:56871/api/ProductPaging?Page=2&size=100&Column=Id&SortDirection=asc&VoucherNumberGenerateWay
            Headers
            Content-Type:application/json  
             */
        [HttpGet]
        [Route("api/ProductPaging")]
        public IHttpActionResult GetProduct(int Page, int Size, string Column, string SortDirection, int VoucherNumberGenerateWay)
        {
            PagingResult pr = new PagingResult();
            int _page = Page;
            int _size = Size;
            int? _voucherNumberGenerateWay = null;
            string _column = Column;
            string _sortDirection = SortDirection;
            string message = string.Empty;
            int totalRow = default(int);

            if (VoucherNumberGenerateWay != 0)
            {
                _voucherNumberGenerateWay = VoucherNumberGenerateWay;
            }

            pr = DataProvider.QueryProductInPage(_page, _size, _column, _sortDirection, out message, out totalRow, _voucherNumberGenerateWay);
            if (string.IsNullOrEmpty(message))
            {
                pr.ResponseCode = "0000";
            }
            else
            {
                pr.ResponseCode = "9999";
                pr.ResponseMessage = message;
            }

            return Json(pr);
        }
    }
}
