using Common.Domain;
using Common.Domain.Models;
using Common.Domain.Models.Pagination;
using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.ImageMedia
{
    public class GetImageMediaListQuery : Pagination, IRequestListWrapper<GetImageMediaListResponse>
    {
        public string SearchKeyword { get; set; }
        public ImageCategory Type { get; set; }
    }
}
