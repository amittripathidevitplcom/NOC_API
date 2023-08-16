using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Newtonsoft.Json;
using System.Data;
using Azure.Core;
using Azure;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Headers;
using System.Configuration;
using SSOService;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class SSOAPI : UtilityBase, ISSOAPI
    {
        public SSOAPI(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<CommonDataModel_DataTable> Check_SSOIDWise_LegalEntity(string SSOID)
        {
            return UnitOfWork.SSOAPIRepository.Check_SSOIDWise_LegalEntity(SSOID);
        }
        public List<CommonDataModel_DataTable> GetUserRoleList(string SSOID)
        {
            return UnitOfWork.SSOAPIRepository.GetUserRoleList(SSOID);
        }

        public async Task<SSOUserDetailData> GetSSOUserLogionDetails(string SSOID, string LoginType, IConfiguration _configuration)
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
                    HttpResponseMessage Res = await client.GetAsync("/SSOREST/GetUserDetailJSON/" + SSOID + "/" + WebServiceUser + "/" + WebServicePwd);
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
    }

}
