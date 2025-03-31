using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class CollegeMaster : UtilityBase, ICollegeMaster
    {
        public CollegeMaster(IRepositories unitOfWork) : base(unitOfWork)
        {

        } 
        public bool SaveData(CollegeMasterDataModel request)
        {
            return UnitOfWork.CollegeMasterRepository.SaveData(request);
        }

        public List<CommonDataModel_DataTable> DraftApplicationList(string LoginSSOID, int SessionYear)
        {
            return UnitOfWork.CollegeMasterRepository.DraftApplicationList(LoginSSOID, SessionYear);
        }
        public List<CommonDataModel_DataTable> StatisticsCollegeList(string LoginSSOID, int SessionYear)
        {
            return UnitOfWork.CollegeMasterRepository.StatisticsCollegeList(LoginSSOID, SessionYear);
        }
        public List<CommonDataModel_DataTable> CollegeDetails(string LoginSSOID, string Type, int SessionYear)
        {
            return UnitOfWork.CollegeMasterRepository.CollegeDetails(LoginSSOID,Type, SessionYear);
        }
        public CollegeMasterDataModel GetCollegeById(int collegeId)
        {
            return UnitOfWork.CollegeMasterRepository.GetCollegeById(collegeId);
        }
        public bool DeleteData(int CollegeId, int modifiedBy)
        {
            return UnitOfWork.CollegeMasterRepository.DeleteData(CollegeId, modifiedBy);
        }
        public bool MapSSOIDInCollege(int CollegeId, int modifiedBy, string ssoId)
        {
            return UnitOfWork.CollegeMasterRepository.MapSSOIDInCollege(CollegeId, modifiedBy, ssoId);
        }
        public List<CommonDataModel_DataSet> ViewTotalCollegeDataByID(int CollegeID)
        {
            return UnitOfWork.CollegeMasterRepository.ViewTotalCollegeDataByID(CollegeID);
        }
        
        public List<CommonDataModel_DataTable> RevertedApplicationList(string LoginSSOID, int SessionYear)
        {
            return UnitOfWork.CollegeMasterRepository.RevertedApplicationList(LoginSSOID, SessionYear);
        }
        public List<CommonDataModel_DataTable> RejectedApplicationList(string LoginSSOID, int SessionYear)
        {
            return UnitOfWork.CollegeMasterRepository.RejectedApplicationList(LoginSSOID,SessionYear);
        }       
        public List<CommonDataModel_DataTable> LOIApplicationList(string LoginSSOID)
        {
            return UnitOfWork.CollegeMasterRepository.LOIApplicationList(LoginSSOID);
        }

        public bool LOIFinalSubmit_OTPVerification(int CollegeID)
        {
            return UnitOfWork.CollegeMasterRepository.LOIFinalSubmit_OTPVerification(CollegeID);
        }     
        public bool IfExists(int DepartmentID,int CollegeID, string MobileNo, string Email)
        {
            return UnitOfWork.CollegeMasterRepository.IfExists(DepartmentID,CollegeID, MobileNo,Email);
        }
        public bool SaveLOIWorkFlow(DocumentScrutinySave_DataModel request)
        {
            return UnitOfWork.CollegeMasterRepository.SaveLOIWorkFlow(request);
        }
        public List<DataTable> GetCollegesByDepartmentID(int DepartmentID)
        {
            return UnitOfWork.CollegeMasterRepository.GetCollegesByDepartmentID(DepartmentID);
        }
        public List<CommonDataModel_DataTable> TotalCollegeDetailsByDepartment(TotalCollegeReportSearchFilter request)
        {
            return UnitOfWork.CollegeMasterRepository.TotalCollegeDetailsByDepartment(request);
        }
       
        
        public List<CommonDataModel_DataTable> CollegesReport(DCECollegesReportSearchFilter request)
        {
            return UnitOfWork.CollegeMasterRepository.CollegesReport(request);
        }
        public bool IfExistsDefaulterCollege(int DepartmentID, int CollegeID, string SSOID)
        {
            return UnitOfWork.CollegeMasterRepository.IfExistsDefaulterCollege(DepartmentID,CollegeID,SSOID);
        }      
        public bool IfExistsDefaulterCollegePenalty(int DepartmentID, int CollegeID, string SSOID)
        {
            return UnitOfWork.CollegeMasterRepository.IfExistsDefaulterCollegePenalty(DepartmentID,CollegeID,SSOID);
        }
        public bool CompareDefaulterCollegeName(int DepartmentID, string CurrentCollegeName, string SSOID, int DivisionID, int DistrictID)
        {
            return UnitOfWork.CollegeMasterRepository.CompareDefaulterCollegeName(DepartmentID, CurrentCollegeName, SSOID, DivisionID, DistrictID);
        }
       
        public bool IfExistAffiliationType(int DTEAffiliationID,int DepartmentID, string CurrentCollegeName, int AffiliationTypeID)
        {
            return UnitOfWork.CollegeMasterRepository.IfExistAffiliationType(DTEAffiliationID,DepartmentID, CurrentCollegeName, AffiliationTypeID);
        }
        public CollegeMasterDataModel GetDataAffiliation(int DTEAffiliationID)
        {
            return UnitOfWork.CollegeMasterRepository.GetDataAffiliation(DTEAffiliationID);
        }
        public List<CommonDataModel_FilterCollegesByBTER> FilterAffiliationCourseStatusBter(int DTEAffiliationID)
        {
            return UnitOfWork.CollegeMasterRepository.FilterAffiliationCourseStatusBter(DTEAffiliationID);
        }
        
        public List<CommonDataModel_DataSet> ViewBTERTotalCollegeDataByID(int SelectedDteAffiliationRegId)
        {
            return UnitOfWork.CollegeMasterRepository.ViewBTERTotalCollegeDataByID(SelectedDteAffiliationRegId);
        }      
        
        public List<CommonDataModel_DataTable> TotalBTERCollegeDetailsByDepartment(TotalCollegeReportSearchFilter request, int SessionID, string ApplicationStatus)
        {
            return UnitOfWork.CollegeMasterRepository.TotalBTERCollegeDetailsByDepartment(request, SessionID, ApplicationStatus);
        }
        
        public List<CommonDataModel_DataTable> GetGenerateorderList(string ApplicationStatus,string GenOrderNumber)
        {
            return UnitOfWork.CollegeMasterRepository.GetGenerateorderList(ApplicationStatus,GenOrderNumber);
        }
    }
}
