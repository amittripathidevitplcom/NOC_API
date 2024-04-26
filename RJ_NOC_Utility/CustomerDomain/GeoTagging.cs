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
        List<CommonDataModel_DataTable> IGeoTagging.GetAPPApplicationCollegeList(string LoginSSOID, string Type, string ViewType)
        {
            return UnitOfWork.GeoTaggingRepository.GetAPPApplicationCollegeList(LoginSSOID, Type,ViewType);
        }
        List<CommonDataModel_DataTable> IGeoTagging.GetAPPApplicationCollege_DashboardCount(string LoginSSOID, string Type)
        {
            return UnitOfWork.GeoTaggingRepository.GetAPPApplicationCollege_DashboardCount(LoginSSOID, Type);
        }
        List<CommonDataModel_DataTable> IGeoTagging.AppNotGetCollegeWiseAllDocumnetsificationList(int CollegeID)
        {
            return UnitOfWork.GeoTaggingRepository.AppNotGetCollegeWiseAllDocumnetsificationList(  CollegeID);
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
        public bool SaveInspectionGeoTagging(InspectionGeoTaggingDataModel request)
        {
            return UnitOfWork.GeoTaggingRepository.SaveInspectionGeoTagging(request);
        }
        public string DecryptStringAES(string cipherText)
        {
            var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
            var iv = Encoding.UTF8.GetBytes("8080808080808080");

            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return string.Format(decriptedFromJavascript);
        }
        public string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;
                rijAlg.Key = key;
                rijAlg.IV = iv;
                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                try
                {
                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }
            return plaintext;
        }
    }
}
