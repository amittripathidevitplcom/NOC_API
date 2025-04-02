using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;
using RJ_NOC_DataAccess.Common;
namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEAffilitionMaster : UtilityBase, IDTEAffilitionMaster
    {
        public DTEAffilitionMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public bool SaveData(DTEAffiliationRegistrationDataModel request)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.SaveData(request);
        }      
        public bool DTEAffilitionCourseSaveData(DTEAffiliationCourseDataModel request)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.DTEAffilitionCourseSaveData(request);
        }
        
        public bool IfExists(int BTERRegID, int BTERCourseID, int CourseTypeId, int CourseId)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.IfExists(BTERRegID,BTERCourseID, CourseTypeId, CourseId);
        }
        public bool DTEAffilitionOtherDetailsSaveData(DTEAffiliationOtherDetailsDataModel request)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.DTEAffilitionOtherDetailsSaveData(request);
        }       
        public List<DTEAffiliationAddCoursePreviewDataModel> GetDTEAffiliationCoursePreviewData(int DepatmentID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetDTEAffiliationCoursePreviewData(DepatmentID);
        }
        public List<DTEAffiliationAddOtherDetailsPreviewDataModel> GetDTEAffiliationOtherDetailsPreviewData(int BTERRegID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetDTEAffiliationOtherDetailsPreviewData(BTERRegID);
        }
        public List<DTEAffiliationRegistrationDataModel> Edit_OnClick(int DTE_ARId)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.Edit_OnClick(DTE_ARId);
        }
        public List<DTEAffiliationCommonDataModel_DataTable> GetAllDTEAffiliationCourseList(int BTERRegID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetAllDTEAffiliationCourseList(BTERRegID);
        }
        public List<BTERCourseAffiliationDataModel> GetDTEAffiliationWiseCourseIDWise(int BTERCourseID, string LoginSSOID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetDTEAffiliationWiseCourseIDWise(BTERCourseID, LoginSSOID);
        }
        public bool DeleteData(int AffiliationCourseID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.DeleteData(AffiliationCourseID);
        }
        public List<BTERAffiliationfeesdeposited> generateYears(int YearofstartingID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.generateYears(YearofstartingID);
        }        
        public List<BTEROtherDetailsDataModel> GetOtherinformation(int BTERRegID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetOtherinformation(BTERRegID);
        }        
        public List<BTERFeeDetailsDataModel> GetAllBTERAffiliationCourseFeeList(int BTERRegID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetAllBTERAffiliationCourseFeeList(BTERRegID);
        }
        public List<BTERFeeDetailsDataModel> GetDeficiencyHistoryApplicationID(int BTERRegID,string ApplicationStatus)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetDeficiencyHistoryApplicationID(BTERRegID,ApplicationStatus);
        }
        public bool RevertnocSaveData(NOCRevertOtherDetailsDataModel request, string ActionName)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.RevertnocSaveData(request,ActionName);
        }
        public bool RevertEOALOASaveData(EOALOARevertOtherDetailsDataModel request, string ActionName)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.RevertEOALOASaveData(request,ActionName);
        }       
        public bool RevertApplicationSaveData(ApplicationRevertOtherDetailsDataModel request, string ActionName)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.RevertApplicationSaveData(request,ActionName);
        }
        public List<BTEROtherDetailsDataModel> ApplicationSubmit(int BTERRegID,string ActionName)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.ApplicationSubmit(BTERRegID, ActionName);
        }
        public bool Generateorder_SaveData(Generateorderforbter request)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.Generateorder_SaveData(request);
        }
        public List<CommonDataModel_DataTable> GetAllBTERFeeList()
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetAllBTERFeeList();
        }
        public List<BTERFeeMasterDataModel> GetBTERFeeByID(int FeeID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetBTERFeeByID(FeeID);
        }
        public bool SaveDataBTERFee(BTERFeeMasterDataModel request)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.SaveDataBTERFee(request);
        }
        public bool DeleteDataBter(int FeeID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.DeleteDataBter(FeeID);
        }

        public bool IfExists(int FeeID, int DepartmentID, string FeeType)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.IfExists(FeeID, DepartmentID, FeeType);
        }
    }
}
