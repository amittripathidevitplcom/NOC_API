using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IGeoTaggingRepository
    {
        //SSOUserDetailData AppLogin(SSOLandingDataDataModel sSOLandingDataDataModel);
        List<CommonDataModel_DataTable> AppCollegeSSOLogin(string LoginSSOID);
        List<CommonDataModel_DataTable> GetAPPApplicationCollegeList(string LoginSSOID, string Type,string ViewType);
        List<CommonDataModel_DataTable> GetAPPApplicationCollege_DashboardCount(string LoginSSOID, string Type);
        List<CommonDataModel_DataTable> AppNotGetCollegeWiseAllDocumnetsificationList(int CollegeID);
        bool SaveData(GeoTaggingDataModel request);
        bool ReadNotification(NotificationDataModel request);
        List<CommonDataModel_DataTable> AppNotificationList(string LoginSSOID);
        bool SaveInspectionGeoTagging(InspectionGeoTaggingDataModel request);
    }
}