using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IGeoTagging
    {
        Task<SSOUserDetailData> AppLogin(SSOLandingDataDataModel sSOLandingDataDataModel, IConfiguration _configuration);
        Task<SSOUserAuthentication> SSOAuthentication(SSOLandingDataDataModel sSOLandingDataDataModel, IConfiguration _configuration);
        Task<bool> SSOAuthentication(SSOLandingDataDataModel sSOLandingDataDataModel);
        List<CommonDataModel_DataTable> AppCollegeSSOLogin(string LoginSSOID);
        List<CommonDataModel_DataTable> GetAPPApplicationCollegeList(string LoginSSOID, string Type, string ViewType);
        List<CommonDataModel_DataTable> GetAPPApplicationCollege_DashboardCount(string LoginSSOID, string Type);
        List<CommonDataModel_DataTable> AppNotGetCollegeWiseAllDocumnetsificationList(int CollegeID);
        bool SaveData(GeoTaggingDataModel request);
        bool ReadNotification(NotificationDataModel request);
        List<CommonDataModel_DataTable> AppNotificationList(string LoginSSOID);
        bool SaveInspectionGeoTagging(InspectionGeoTaggingDataModel request);
        string DecryptStringAES(string cipherText);
    }
}
