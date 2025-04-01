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
        List<CommonDataModel_DataTable> DraftApplicationList(string LoginSSOID,int SessionYear);
        List<CommonDataModel_DataTable> StatisticsCollegeList(string LoginSSOID,int SessionYear);
        List<CommonDataModel_DataTable> CollegeDetails(string LoginSSOID, string Type, int SessionYear);
        CollegeMasterDataModel GetCollegeById(int collegeId);
        bool DeleteData(int CollegeId, int modifiedBy);
        bool LOIFinalSubmit_OTPVerification(int CollegeID);
        bool MapSSOIDInCollege(int CollegeId, int modifiedBy, string ssoId);
        List<CommonDataModel_DataSet> ViewTotalCollegeDataByID(int CollegeID);
        List<CommonDataModel_DataTable> RevertedApplicationList(string LoginSSOID, int SessionYear);
        List<CommonDataModel_DataTable> RejectedApplicationList(string LoginSSOID,int SessionYear);
        List<CommonDataModel_DataTable> LOIApplicationList(string LoginSSOID);
       
        bool IfExists(int DepartmentID,int CollegeID, string MobileNo, string Email);
        bool SaveLOIWorkFlow(DocumentScrutinySave_DataModel request);
        List<DataTable> GetCollegesByDepartmentID(int DepartmentID);
        List<CommonDataModel_DataTable> TotalCollegeDetailsByDepartment(TotalCollegeReportSearchFilter request);
        
        List<CommonDataModel_DataTable> CollegesReport(DCECollegesReportSearchFilter request);
        bool IfExistsDefaulterCollege(int DepartmentID,int CollegeID, string SSOID);
        bool IfExistsDefaulterCollegePenalty(int DepartmentID,int CollegeID, string SSOID);
        bool CompareDefaulterCollegeName(int DepartmentID, string CurrentCollegeName, string SSOID, int DivisionID, int DistrictID);
        bool IfExistAffiliationType(int DTEAffiliationID,int DepartmentID, string CurrentCollegeName,int AffiliationTypeID);
        CollegeMasterDataModel GetDataAffiliation(int DTEAffiliationID);
        List<CommonDataModel_FilterCollegesByBTER> FilterAffiliationCourseStatusBter(int DTEAffiliationID);
        List<CommonDataModel_DataSet> ViewBTERTotalCollegeDataByID(int SelectedDteAffiliationRegId);
        List<CommonDataModel_DataTable> TotalBTERCollegeDetailsByDepartment(TotalCollegeReportSearchFilter request, int SessionID,string ApplicationStatus);
        List<CommonDataModel_DataTable> GetGenerateorderList(string ApplicationStatus, string GenOrderNumber);
    }
}