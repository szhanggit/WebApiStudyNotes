using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTester
{
    public class Client
    {
        public string Title{get;set;}

        public byte SecurityAlgorithm
        {
            get;
            set;
        }

        public string EmailSenderName
        {
            get;
            set;
        }

        public string EmailSenderAddress
        {
            get;
            set;
        }

        public Nullable<int> VoucherIssuerId
        {
            get;
            set;
        }

        public Nullable<int> MediaLibraryId
        {
            get;
            set;
        }

        public string SMSSenderName
        {
            get;
            set;
        }

        public Nullable<int> EmailHeaderMId
        {
            get;
            set;
        }

        public Nullable<int> EmailFooterMId
        {
            get;
            set;
        }

        public Nullable<bool> ApplyEmailSubject
        {
            get;
            set;
        }

        public bool CanIssue
        {
            get;
            set;
        }

        public Nullable<int> BannerMediaLibraryId
        {
            get;
            set;
        }

        public string SubURL
        {
            get;
            set;
        }

        public Nullable<bool> MandatoryAutoBilling
        {
            get;
            set;
        }

        public string SmsEntityId
        {
            get;
            set;
        }

        public string SmsProviderCode
        {
            get;
            set;
        }

        public string EmailProviderCode
        {
            get;
            set;
        }
        public string Memo
        {
            get;
            set;
        }

        public string SalesEmail
        {
            get;
            set;
        }

        public string ContactName
        {
            get;
            set;
        }

        public string ContactEmail
        {
            get;
            set;
        }

        public string ContactPhone
        {
            get;
            set;
        }

        public int BusinessTypeId { get; set; }

        public string InvoiceRegisterNumber
        {
            get;
            set;
        }

        public string CRMReference
        {
            get;
            set;
        }

        public string FinanceReference
        {
            get;
            set;
        }

        public string Department
        {
            get;
            set;
        }

        public byte Status
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Modifier
        {
            get;
            set;
        }

        public int Version
        {
            get;
            set;
        }

        public DateTime VersionTime
        {
            get;
            set;
        }

        public string SecurityKey
        {
            get;
            set;
        }

        public string IdentityCode
        {
            get;
            set;
        }

        public bool NeedNotification
        {
            get;
            set;
        }
    }
}
