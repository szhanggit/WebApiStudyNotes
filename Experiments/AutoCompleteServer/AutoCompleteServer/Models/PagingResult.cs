using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteServer.Models
{
    public class PagingResult
    {
        private int _pageNumber = default(int);
        private int _totalRows = default(int);
        private int _pageSize = default(int);
        private int _totalPage = default(int);
        private List<Product> _productList;

        public PagingResult()
        {
            _productList = new List<Product>();
        }

        public int PageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        public int TotalRows { get { return _totalRows; } set { _totalRows = value; } }
        public int PageSize { get { return _pageSize;  } set { _pageSize = value; } }
        public int TotalPage { get { return _totalPage; } set { _totalPage = value; } }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<Product> ProductList { get { return _productList; } }
    }
}