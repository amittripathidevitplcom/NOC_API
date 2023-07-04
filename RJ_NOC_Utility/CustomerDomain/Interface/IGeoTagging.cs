using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IGeoTagging
    {
        List<GeoTaggingDataModels> AppCollegeSSOLogin(string LoginSSOID);
        List<GeoTaggingDataModels> GetAPPApplicationCollegeList(string LoginSSOID, string Type);
        List<GeoTaggingDataModels> GetAPPApplicationCollege_DashboardCount(string LoginSSOID);
        bool SaveData(GeoTaggingDataModel request);
    }
}
