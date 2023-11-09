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
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri(BaseUrl);
                //    client.DefaultRequestHeaders.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //    HttpResponseMessage Res = await client.GetAsync("/SSOREST/GetUserDetailJSON/" + SSOID + "/" + WebServiceUser + "/" + WebServicePwd);
                //    if (Res.IsSuccessStatusCode)
                //    {
                //        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //        ssoInfo = JsonConvert.DeserializeObject<SSOUserDetailData>(EmpResponse);
                //    }
                //    else
                //    { }
                //}

                ssoInfo = new SSOUserDetailData()
                {
                    SSOID = "nerusingh111",
                    AadhaarId = "557975711583",
                    BhamashahId = "45454",
                    BhamashahMemberId = "454654",
                    DisplayName = "Naresh",
                    DateOfBirth = "19/01/1991",
                    Gender = "Male",
                    MobileNo = "7742860212",
                    TelephoneNumber = "014145454",
                    IpPhone = "014145454",
                    MailPersonal = "rishikapoordelhi@gmail.com",
                    PostalAddress = "Jaiupr",
                    PostalCode = "302023",
                    City = "Jaiupr",
                    State = "Rajasthan",
                    Photo = "",
                    Designation = "Citizan",
                    Department = "College",
                    MailOfficial = "rishikapoordelhi@gmail.com",
                    EmployeeNumber = "1212",
                    DepartmentId = "0",
                    FirstName = "Naresh",
                    LastName = "Rawat",
                    JanaadhaarId = "23232",
                    ManaadhaarMemberId = "1212",
                    UserType = "0",
                    Mfa = "454"
                };

            }
            catch (Exception ex)
            {
                //return new ServiceResponse() { data = "", IsSuccess = false, Message = "Success" };
            } 
            return ssoInfo;

        }
    }

}
