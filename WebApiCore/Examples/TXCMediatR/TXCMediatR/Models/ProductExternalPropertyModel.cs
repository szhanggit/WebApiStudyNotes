namespace TXCMediatR.Models
{
    public class ProductExternalPropertyModel
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string Description { get; set; }
        public int ProductExternalPropertyId { get; set; }
        public int ProductExternalPropertySetId { get; set; }
    }
}
