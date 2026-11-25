using TXC.Common.Domain.Models.Pagination;

namespace TXCMediatR.Models
{
    public class GetProductListResponse : IPaginationTotal
    {
        public IList<ProductDTO> ProductDtos { get; set; }
        public int TotalCount { get; set; }
    }
}
