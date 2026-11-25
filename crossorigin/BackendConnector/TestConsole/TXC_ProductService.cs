using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class TXC_ProductService : TXC_BaseService
    {
        public TXC_ProductService()
        {
            BaseUrl = "TXCServiceURL".ConfigStringValue();
        }

        public IEnumerable<ProductExternalPropertyModel> GetProductExternalPropertyList(int ProductId)
        {
            IEnumerable<ProductExternalPropertyModel> _productExternalProperty = new List<ProductExternalPropertyModel>();
            string url = $"{BaseUrl}/api/TxProduct/ExternalProperty";
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (ProductId > 0)
            {
                dic["ProductId"] = ProductId;
            }

            _productExternalProperty = QueryAPI<IEnumerable<ProductExternalPropertyModel>>(dic, url);

            return _productExternalProperty;
        }

        public int CreateProductExternalPropertyListV2(CreateExternalPropertyListCommand request)
        {
            Uri baseUrl = new Uri(BaseUrl);
            IRestClient restClient = new RestClient(baseUrl);
            IRestRequest restRequest = new RestRequest("api/TxProduct/ExternalProperty", Method.POST);
            restRequest.AddHeader("TenantName", "TXCTenantName".ConfigStringValue());
            restRequest.AddHeader("TenantBasicInfoId", "TXCTenantId".ConfigStringValue());
            restRequest.AddHeader("TX2UserName", "TXC");
            restRequest.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), ParameterType.RequestBody);
            restRequest.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse<TXCApiUpdateResult> restResponse = restClient.Execute<TXCApiUpdateResult>(restRequest);
                if (restResponse != null && restResponse.StatusCode == HttpStatusCode.OK)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected int CreateProductExternalPropertyListAPI(CreateExternalPropertyListCommand request, out TXCApiUpdateResult updatingResult)
        {
            updatingResult = new TXCApiUpdateResult();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback += TrustSelfCerticate;

                IRestClient restClient = new RestClient(BaseUrl);
                IRestRequest restRequest = new RestRequest("api/TxProduct/ExternalProperty", Method.POST);

                restRequest.AddHeader("TenantBasicInfoId", "TXCTenantId".ConfigStringValue());
                restRequest.AddHeader("TenantName", "TXCTenantName".ConfigStringValue());
                restRequest.AddHeader("TX2UserName", "TXC");


                restRequest.AddParameter("ProductId", request.ProductId);
                if (request.ProductExternalPropertyList != null && request.ProductExternalPropertyList.Count > 0)
                {
                    for (int i = 0; i < request.ProductExternalPropertyList.Count; i++)
                    {
                        restRequest.AddParameter($"ProductExternalPropertyList[{i}].PropertyName", request.ProductExternalPropertyList[i].propertyName);
                        restRequest.AddParameter($"ProductExternalPropertyList[{i}].PropertyValue", request.ProductExternalPropertyList[i].propertyValue);
                        restRequest.AddParameter($"ProductExternalPropertyList[{i}].Description", request.ProductExternalPropertyList[i].description);
                    }
                }

                var restResponse = restClient.Execute<object>(restRequest);

                if (restResponse != null && restResponse.StatusCode == HttpStatusCode.OK)
                {
                    updatingResult = JsonHelper.FromJson<TXCApiUpdateResult>(restResponse.Content);
                    return 1;
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
}
