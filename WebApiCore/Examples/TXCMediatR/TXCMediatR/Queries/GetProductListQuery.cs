using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetProductListQuery : IRequestListWrapper<GetProductListResponse>
    {
        public string Keyword { get; set; }
        public int Type { get; set; }
        public int MerchantAcquirerId { get; set; }
        public bool? Status { get; set; }
        public int? RowCount { get; set; }
        public int? PageNumber { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }

    }
}
