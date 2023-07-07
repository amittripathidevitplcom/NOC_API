using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IGeoTaggingRepository
    {
        List<CommonDataModel_DataTable> AppCollegeSSOLogin(string LoginSSOID);
        List<CommonDataModel_DataTable> GetAPPApplicationCollegeList(string LoginSSOID, string Type);
        List<CommonDataModel_DataTable> GetAPPApplicationCollege_DashboardCount(string LoginSSOID);
        bool SaveData(GeoTaggingDataModel request);
    }
}