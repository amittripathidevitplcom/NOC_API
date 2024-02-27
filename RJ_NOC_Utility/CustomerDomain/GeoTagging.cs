using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Azure.Core;
using SSOService;
using System.Security.Cryptography;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class GeoTagging : UtilityBase, IGeoTagging
    {
        public GeoTagging(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        List<CommonDataModel_DataTable> IGeoTagging.AppCollegeSSOLogin(string LoginSSOID)
        {
            return UnitOfWork.GeoTaggingRepository.AppCollegeSSOLogin(LoginSSOID);
        }
        List<CommonDataModel_DataTable> IGeoTagging.GetAPPApplicationCollegeList(string LoginSSOID, string Type)
        {
            return UnitOfWork.GeoTaggingRepository.GetAPPApplicationCollegeList(LoginSSOID, Type);
        }
        List<CommonDataModel_DataTable> IGeoTagging.GetAPPApplicationCollege_DashboardCount(string LoginSSOID, string Type)
        {
            return UnitOfWork.GeoTaggingRepository.GetAPPApplicationCollege_DashboardCount(LoginSSOID, Type);
        }
        public bool SaveData(GeoTaggingDataModel request)
        {
            return UnitOfWork.GeoTaggingRepository.SaveData(request);
        }


        //public Boolean SSOAuthenticationMobileNew(string SSOID,string Password)
        //{
        //  //string  ServiceReq = "{\"Application\":\"rajkisan\",\"UserName\":\"" + this.SSOID + "\",\"Password\":\"" + objAES.Encrypt(this.Password, EncKey) + "\"}";
        //  //  string response = WebRequestinJson(serviceURL + "SSOREST/SSOAuthenticationMobileNew", ServiceReq);
        //  //  ServiceRes = (new JavaScriptSerializer()).Deserialize<SSOResponce>(response);
        //  //  return ServiceRes.valid;
        //}


        public async Task<bool> SSOAuthentication(SSOLandingDataDataModel sSOLandingDataDataModel)
        {
            bool strResult = false; 
            try
            {
                    SSOWSSoapClient sSOService = new SSOWSSoapClient(SSOWSSoapClient.EndpointConfiguration.SSOWSSoap);
                    strResult = await sSOService.SSOAuthenticationAsync(sSOLandingDataDataModel.Username.ToString(), sSOLandingDataDataModel.Password.ToString());
            }
            catch (Exception ex)
            {
                return strResult;
            }
            return strResult;
        }


        public async Task<SSOUserDetailData> AppLogin(SSOLandingDataDataModel sSOLandingDataDataModel, IConfiguration _configuration)
        {
            SSOUserDetailData ssoInfo = new SSOUserDetailData();
            string BaseUrl = _configuration["SSOLoginDetils:SSOBaseUrl"].ToString();
            string AppName = _configuration["SSOLoginDetils:AppName"].ToString();
            string WebServiceUser = _configuration["SSOLoginDetils:WebServiceUser"].ToString();
            string WebServicePwd = _configuration["SSOLoginDetils:WebServicePwd"].ToString();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("/SSOREST/GetUserDetailJSON/" + sSOLandingDataDataModel.Username + "/" + WebServiceUser + "/" + WebServicePwd);
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        ssoInfo = JsonConvert.DeserializeObject<SSOUserDetailData>(EmpResponse);
                    }
                    else
                    { }
                }
            }
            catch (Exception ex)
            {
                //return new ServiceResponse() { data = "", IsSuccess = false, Message = "Success" };
            }
            return ssoInfo;
        }
        public bool ReadNotification(NotificationDataModel request)
        {
            return UnitOfWork.GeoTaggingRepository.ReadNotification(request);
        }
        public List<CommonDataModel_DataTable> AppNotificationList(string LoginSSOID)
        {
            return UnitOfWork.GeoTaggingRepository.AppNotificationList(LoginSSOID);
        }
    }
}
