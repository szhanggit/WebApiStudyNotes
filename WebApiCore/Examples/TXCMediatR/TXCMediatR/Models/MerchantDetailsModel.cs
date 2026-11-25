namespace TXCMediatR.Models
{
    public class MerchantDetailsModel
    {
        public int MerchantId { get; set; }
        public int ProgramId { get; set; }
        public string ProgramCode { get; set; }
        public string ProgramName { get; set; }
        public string IdentityCode { get; set; }
        public string MerchantName { get; set; }
        public string ExternalCode { get; set; }
        public string InvoiceRegisterNumber { get; set; }
        public string SecurityKey { get; set; }
        public int Status { get; set; }
        public string TX1MerchantUID { get; set; }
        public bool IsAutoCreateReimbursement { get; set; }
        public byte AutoCreateReimbursementIntervalType { get; set; }
        public byte ReimbursementTaxType { get; set; }
        public byte ReimbursementType { get; set; }
        public string ReimbursementReceivers { get; set; }
        public bool SameKeyWithShop { get; set; }
        public string MamEmail { get; set; }
        public byte MerchantAutoType { get; set; }
        public string NotificationMerchantCode { get; set; }
        public string MerchantEmail { get; set; }
        public int MerchantAcquireId { get; set; }
        public string MerchantAcquireName { get; set; }
        public bool NeedConsumerScan { get; set; }
        public string Memo { get; set; }
        public byte IssuerType { get; set; }
        public int WorkKeyId { get; set; }
        public string WorkKey { get; set; }
        public DateTime WorkKeyExpireTime { get; set; }
        public DateTime WorkKeyCreatedTime { get; set; }
        public bool IsLegacyMerchant { get; set; }
        public string MainContact { get; set; }
        public string MainPhone { get; set; }
        public int AutoCreateReimbursementDay { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<String> MerchantContactEmailList { get; set; }
        public List<String> EdenredContactEmailList { get; set; }
    }
}
