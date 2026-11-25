using TXC.Common.Domain.Models.Pagination;

namespace TXCMediatR.Models
{
    public class GetMerchantListResponse : IPaginationTotal
    {
        public IList<MerchantDetailsModel> MerchantDetails { get; set; }
        public int TotalCount { get; set; }
    }
}
