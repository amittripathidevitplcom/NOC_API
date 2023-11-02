using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICollegeMaster
    {
        bool SaveData(CollegeMasterDataModel request);
        List<CommonDataModel_DataTable> DraftApplicationList(string LoginSSOID);
        List<CommonDataModel_DataTable> CollegeDetails(string LoginSSOID);
        CollegeMasterDataModel GetCollegeById(int collegeId);
        bool DeleteData(int CollegeId, int modifiedBy);
        bool LOIFinalSubmit_OTPVerification(int CollegeID);
        bool MapSSOIDInCollege(int CollegeId, int modifiedBy, string ssoId);
        List<CommonDataModel_DataSet> ViewTotalCollegeDataByID(int CollegeID);
        List<CommonDataModel_DataTable> RevertedApplicationList(string LoginSSOID);
        List<CommonDataModel_DataTable> LOIApplicationList(string LoginSSOID);
    }
}