using System.ComponentModel.DataAnnotations;

namespace TXCSwagger5._0.Models
{
    public class GetProductCondition
    {
        [Required(ErrorMessage = "ProductId parameter required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int ProductId { get; set; }
    }
}
