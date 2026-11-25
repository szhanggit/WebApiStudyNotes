using System.ComponentModel.DataAnnotations;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetTxProductPriceQuery : IRequestWrapper<ProductPriceDto>
    {
        [Required]
        public int ProductId { get; set; }
    }
}
