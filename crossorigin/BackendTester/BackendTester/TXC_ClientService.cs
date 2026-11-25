using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackendTester
{
    public class TXC_ClientService : TXC_BaseService
    {
        public TXC_ClientService()
        {
            BaseUrl = "TXCServiceURL".ConfigStringValue();
            Url = "/api/TxClient";
        }

        public List<Client> GetList(Dictionary<string, object> requestDic, int pageNumber)
        {
            var invokeUrl = BaseUrl + Url;
            if (pageNumber > 0)
            {
                invokeUrl = BaseUrl + Url + "?PageNumber=" + pageNumber;
            }

            var result = QueryAPI<TXC_ClientDto_List>(requestDic, invokeUrl);

            if (result == null)
            {
                return null;
            }

            List<Client> clientList = new List<Client>();
            return clientList;
        }

        public TXC_ClientDto GetEntity(int id = 0, string identityCode = null)
        {
            string url = BaseUrl + Url;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (id > 0)
            {
                url = url + "/GetById";
                dic["ClientId"] = id;
            }
            else if (!string.IsNullOrEmpty(identityCode))
            {
                url = url + "/GetByIdentityCode";
                dic["IdentityCode"] = identityCode;
            }

            var txc_client = QueryAPI<TXC_ClientDto>(dic, url);

            if (txc_client == null)
            {
                return null;
            }

            return txc_client;
        }

        protected int ModifyAPI(TXC_ClientDto request, string url, string method = "POST")
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback += TrustSelfCerticate;

                IRestClient restClient = new RestClient(BaseUrl);
                IRestRequest restRequest = new RestRequest("api/TxClient", method == "POST" ? Method.POST : Method.PUT);

                restRequest.AddHeader("TenantBasicInfoId", "TXCTenantId".ConfigStringValue());
                restRequest.AddHeader("TenantName", "TXCTenantName".ConfigStringValue());
                restRequest.AddHeader("TX2UserName", string.IsNullOrWhiteSpace(request.Modifier) ? "TXC" : request.Modifier);

                restRequest.AlwaysMultipartFormData = true;
                restRequest.AddParameter("NeedNotification", request.needNotification);
                restRequest.AddParameter("VoucherIssuerId", request.voucherIssuerId);
                restRequest.AddParameter("EmailSenderAddress", request.emailSenderAddress);
                restRequest.AddParameter("NotificationProviderCodeId", request.notificationProviderCodeId);
                restRequest.AddParameter("EmailFooterMediaId", request.emailFooterMediaId);
                restRequest.AddParameter("CanIssue", request.canIssue);
                restRequest.AddParameter("ContactName", request.contactName);
                restRequest.AddParameter("InvoiceTitle", request.invoiceTitle);
                restRequest.AddParameter("IdentityCode", request.identityCode);
                restRequest.AddParameter("ContactPhone", request.contactPhone);
                restRequest.AddParameter("SecurityAlgorithm", request.securityAlgorithm);
                restRequest.AddParameter("SubURL", request.subURL);
                restRequest.AddParameter("SalesEmail", request.salesEmail);
                restRequest.AddParameter("Status", request.status);
                restRequest.AddParameter("MandatoryAutoBilling", request.mandatoryAutoBilling);
                restRequest.AddParameter("BannerMediaId", request.bannerMediaId);
                restRequest.AddParameter("LogoMediaId", request.logoMediaId);
                restRequest.AddParameter("BusinessTypeId", request.businessTypeId);
                restRequest.AddParameter("ClientName", request.clientName);
                restRequest.AddParameter("EmailHeaderMediaId", request.emailHeaderMediaId);
                restRequest.AddParameter("SmsEntityId", request.smsEntityId);
                restRequest.AddParameter("SMSProviderCode", request.smsProviderCode);
                restRequest.AddParameter("InvoiceRegisterNumber", request.invoiceRegisterNumber);
                restRequest.AddParameter("SMSSenderName", request.smsSenderName);
                restRequest.AddParameter("EmailProviderCode", request.emailProviderCode);
                restRequest.AddParameter("Memo", request.memo);
                restRequest.AddParameter("EmailSenderName", request.emailSenderName);
                restRequest.AddParameter("ContactEmail", request.contactEmail);
                restRequest.AddParameter("ApplyEmailSubject", request.applyEmailSubject);
                restRequest.AddParameter("SecurityKey", request.securityKey);
                restRequest.AddParameter("Description", request.description);
                restRequest.AddParameter("DetailAddressLine", request.detailAddressLine);
                restRequest.AddParameter("District", request.district);
                restRequest.AddParameter("CityId", request.cityId);
                restRequest.AddParameter("StateOrProvinceId", request.stateOrProvinceId);
                restRequest.AddParameter("Postcode", request.postcode);
                restRequest.AddParameter("CountryId", request.countryId);
                restRequest.AddParameter("Longitude", request.longitude);
                restRequest.AddParameter("Latitude", request.latitude);
                restRequest.AddParameter("AddressStatus", request.addressStatus);

                if (method == "PUT")
                {
                    restRequest.AddParameter("ClientId", request.clientId);
                }

                var restResponse = restClient.Execute<object>(restRequest);

                if (restResponse != null && restResponse.StatusCode == HttpStatusCode.OK)
                {
                    if (method == "POST")
                    {
                        TXC_Response<int> parsedResponse = CommonMethod.DeserializeFromJson<TXC_Response<int>>(restResponse.Content);
                        return parsedResponse.data;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

            return 0;
        }
    }

    public class TXC_ClientDto_List
    {
        public List<TXC_ClientDto> clientDtos { get; set; }
    }
    public class TXC_ClientDto
    {
        public int clientId { get; set; }
        public string clientName { get; set; }
        public string identityCode { get; set; }
        public string invoiceRegisterNumber { get; set; }
        public int? voucherIssuerId { get; set; }
        public int? businessTypeId { get; set; }
        public int status { get; set; }
        public int securityAlgorithm { get; set; }
        public string securityKey { get; set; }
        public bool needNotification { get; set; }
        public int? notificationProviderCodeId { get; set; }
        public int? logoMediaId { get; set; }
        public int? bannerMediaId { get; set; }
        public int? emailHeaderMediaId { get; set; }
        public int? emailFooterMediaId { get; set; }
        public bool canIssue { get; set; }
        public bool? mandatoryAutoBilling { get; set; }
        public string invoiceTitle { get; set; }
        public string subURL { get; set; }
        public string emailProviderCode { get; set; }
        public string emailSenderName { get; set; }
        public string emailSenderAddress { get; set; }
        public bool? applyEmailSubject { get; set; }
        public string smsProviderCode { get; set; }
        public string smsSenderName { get; set; }
        public string smsEntityId { get; set; }
        public string salesEmail { get; set; }
        public string contactName { get; set; }
        public string contactEmail { get; set; }
        public string contactPhone { get; set; }
        public string memo { get; set; }
        public string description { get; set; }
        public string Modifier { get; set; }
        public string detailAddressLine { get; set; }
        public string district { get; set; }
        public int cityId { get; set; }
        public int stateOrProvinceId { get; set; }
        public string postcode { get; set; }
        public int countryId { get; set; }
        public double? longitude { get; set; }
        public double? latitude { get; set; }
        public int addressStatus { get; set; }
    }
}
