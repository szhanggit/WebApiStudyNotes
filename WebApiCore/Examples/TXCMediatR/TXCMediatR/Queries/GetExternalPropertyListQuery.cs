using System.ComponentModel.DataAnnotations;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetExternalPropertyListQuery : IRequestWrapper<IEnumerable<ProductExternalPropertyModel>>
    {
        [Required(ErrorMessage = "ProductId required")]
        public int ProductId { get; set; }
    }
}
