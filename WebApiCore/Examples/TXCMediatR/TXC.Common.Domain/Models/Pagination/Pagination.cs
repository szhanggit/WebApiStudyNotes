using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXC.Common.Domain.Models.Pagination
{
    public abstract class Pagination
    {
        private int _rowCount;
        private int _pageNumber;
        public int PageNumber { get { return _pageNumber > 0 ? _pageNumber : 1; } set { _pageNumber = (value > 0) ? value : 1; } }
        public int RowCount { get { return _rowCount > 0 ? _rowCount : 20; } set { _rowCount = (value > 0) ? value : 20; } }
        public int GetPageOffset()
        {

            return (PageNumber >= 1) ? (PageNumber - 1) * RowCount : RowCount;

        }
    }
}
