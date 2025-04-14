using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEAffilitionMasterRepository
    {
        bool SaveData(DTEAffiliationRegistrationDataModel request);
        bool DTEAffilitionCourseSaveData(DTEAffiliationCourseDataModel request);
       
        bool DTEAffilitionOtherDetailsSaveData(DTEAffiliationOtherDetailsDataModel request);
       
        bool IfExists(int BTERRegID, int BTERCourseID,int CourseTypeId, int CourseId);
        List<DTEAffiliationAddCoursePreviewDataModel> GetDTEAffiliationCoursePreviewData(int DepatmentID);
        List<DTEAffiliationAddOtherDetailsPreviewDataModel> GetDTEAffiliationOtherDetailsPreviewData(int BTERRegID);
        List<DTEAffiliationRegistrationDataModel> Edit_OnClick(int DTE_ARId);
        List<DTEAffiliationCommonDataModel_DataTable> GetAllDTEAffiliationCourseList(int BTERRegID);
        List<BTERCourseAffiliationDataModel> GetDTEAffiliationWiseCourseIDWise(int BTERCourseID, string LoginSSOID);
        bool DeleteData(int CollegeWiseCourseID);
        List<BTERAffiliationfeesdeposited> generateYears(int YearofstartingID);
        List<BTEROtherDetailsDataModel> GetOtherinformation(int BTERRegID);       
        List<BTERFeeDetailsDataModel> GetAllBTERAffiliationCourseFeeList(int BTERRegID);
        List<BTERFeeDetailsDataModel> GetDeficiencyHistoryApplicationID(int BTERRegID,string ApplicationStatus);
        bool RevertnocSaveData(NOCRevertOtherDetailsDataModel request, string ActionName);
        bool RevertEOALOASaveData(EOALOARevertOtherDetailsDataModel request, string ActionName);
        bool RevertApplicationSaveData(ApplicationRevertOtherDetailsDataModel request, string ActionName);
        List<BTEROtherDetailsDataModel> ApplicationSubmit(int BTERRegID,string ActionName, decimal AMOUNT);
        bool Generateorder_SaveData(Generateorderforbter request);
        List<CommonDataModel_DataTable> GetAllBTERFeeList();
        List<BTERFeeMasterDataModel> GetBTERFeeByID(int FeeID);
        bool SaveDataBTERFee(BTERFeeMasterDataModel request);
        bool DeleteDataBter(int FeeID);
        bool IfExists(int FeeID, int DepartmentID, string FeeType);
        bool SaveDataBTERApplicationOpenSession(BTERApplicationOpensessionDataModel request);
        List<BTERApplicationOpensessionDataModel> GetAllOpenSessionApplicationList();
        List<BTERApplicationOpensessionDataModel> GetByIDOpenSessionApplicationList(int ID);
        bool DeleteDataOpenSessionApplicationList(int ID);
        
    }

}

