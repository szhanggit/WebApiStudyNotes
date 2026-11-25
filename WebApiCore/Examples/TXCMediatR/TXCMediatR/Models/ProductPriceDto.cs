namespace TXCMediatR.Models
{
    public class ProductPriceDto
    {
        public int ProductPriceId { get; set; }
        public decimal? SellingPricePrepaid { get; set; }
        public decimal? SellingPricePrepaidWithTax { get; set; }
        public decimal? SellingPricePostpaid { get; set; }
        public decimal? SellingPricePostpaidWithTax { get; set; }
        public decimal? CustomerFeePrepaid { get; set; }
        public decimal? CustomerFeePrepaidWithTax { get; set; }
        public decimal? CustomerFeePostpaid { get; set; }
        public decimal? CustomerFeePostpaidWithTax { get; set; }
    }
}
