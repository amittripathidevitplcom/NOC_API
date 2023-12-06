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

        public List<CommonDataModel_DataTable> DraftApplicationList(string LoginSSOID)
        {
            return UnitOfWork.CollegeMasterRepository.DraftApplicationList(LoginSSOID);
        }
        public List<CommonDataModel_DataTable> CollegeDetails(string LoginSSOID)
        {
            return UnitOfWork.CollegeMasterRepository.CollegeDetails(LoginSSOID);
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
        public List<CommonDataModel_DataTable> RevertedApplicationList(string LoginSSOID)
        {
            return UnitOfWork.CollegeMasterRepository.RevertedApplicationList(LoginSSOID);
        }
        public List<CommonDataModel_DataTable> RejectedApplicationList(string LoginSSOID)
        {
            return UnitOfWork.CollegeMasterRepository.RejectedApplicationList(LoginSSOID);
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
    }
}
