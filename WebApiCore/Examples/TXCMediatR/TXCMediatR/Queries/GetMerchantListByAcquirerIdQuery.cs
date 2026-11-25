using TXC.Common.Domain.Models.Pagination;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetMerchantListByAcquirerIdQuery : Pagination, IRequestListWrapper<GetMerchantListResponse>
    {
        public string SearchKeyword { get; set; }
        public int MerchantAcquirerId { get; set; }
    }
}
