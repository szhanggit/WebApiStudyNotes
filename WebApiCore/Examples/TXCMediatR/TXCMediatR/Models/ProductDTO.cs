namespace TXCMediatR.Models
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string MerchantSKU { get; set; }
        public int ProductType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Status { get; set; }
    }
}
