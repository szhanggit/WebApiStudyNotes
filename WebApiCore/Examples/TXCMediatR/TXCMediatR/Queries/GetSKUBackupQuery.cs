using System.ComponentModel.DataAnnotations;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetSKUBackupQuery : IRequestWrapper<List<SKUBackupModel>>
    {
        [Required(ErrorMessage = "ProductId parameter required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int ProductId { get; set; }
    }
}
