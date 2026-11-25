using System.ComponentModel.DataAnnotations;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Dto;

namespace TXCMediatR.Commands
{
    public class InsertSKUBackupCommand : IRequestWrapper<int>
    {
        [Required(ErrorMessage = "ProductId parameter required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int ProductId { get; set; }
        public List<SKUBackupDto> SkuBackupList { get; set; }
    }
}
