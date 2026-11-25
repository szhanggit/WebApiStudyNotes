using Common.Domain.Dto;
using Common.Domain.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Models
{
    public class GetImageMediaListResponse : IPaginationTotal
    {
        public IList<MediaDto> MediaDtos { get; set; }
        public int TotalCount { get; set; }
    }
}
