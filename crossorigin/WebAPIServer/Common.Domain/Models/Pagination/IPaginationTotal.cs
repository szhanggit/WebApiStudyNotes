using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Models.Pagination
{
    public interface IPaginationTotal
    {
        public int TotalCount { get; set; }
    }
}
