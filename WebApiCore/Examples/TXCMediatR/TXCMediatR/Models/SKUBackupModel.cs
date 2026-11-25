namespace TXCMediatR.Models
{
    public class SKUBackupModel
    {
        public int SKUId { get; set; }
        public int MerchantId { get; set; }
        public string SKUCode { get; set; }
        public string SKUName { get; set; }
        public string Description { get; set; }
        public int? VoucherNumberRuleId { get; set; }
        public int BrandType { get; set; }
        public int FaceValueWithTaxCent { get; set; }
        public int FaceValueWithoutTaxCent { get; set; }
        public int? SmartBookletMultiplier { get; set; }
        public int BackupSequence { get; set; }
    }
}
