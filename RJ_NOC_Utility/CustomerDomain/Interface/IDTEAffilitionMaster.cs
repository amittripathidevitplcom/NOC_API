using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEAffilitionMaster
    {
        bool SaveData(DTEAffiliationRegistrationDataModel request);
        bool DTEAffilitionCourseSaveData(DTEAffiliationCourseDataModel request);
        bool IfExists(int BTERRegID, int BTERCourseID,int CourseTypeId, int CourseId);
        bool DTEAffilitionOtherDetailsSaveData(DTEAffiliationOtherDetailsDataModel request);
        List<DTEAffiliationAddCoursePreviewDataModel> GetDTEAffiliationCoursePreviewData(int DepatmentID);
        List<DTEAffiliationAddOtherDetailsPreviewDataModel> GetDTEAffiliationOtherDetailsPreviewData(int BTERRegID);        
        List<DTEAffiliationRegistrationDataModel> Edit_OnClick(int DTE_ARId);
        List<DTEAffiliationCommonDataModel_DataTable> GetAllDTEAffiliationCourseList(int BTERRegID);
        List<BTERCourseAffiliationDataModel> GetDTEAffiliationWiseCourseIDWise(int BTERCourseID, string LoginSSOID);
        bool DeleteData(int AffiliationCourseID);
        List<BTERAffiliationfeesdeposited> generateYears(int YearofstartingID);        
        List<BTEROtherDetailsDataModel> GetOtherinformation(int BTERRegID);     
        List<BTERFeeDetailsDataModel> GetAllBTERAffiliationCourseFeeList(int BTERRegID);
        List<BTERFeeDetailsDataModel> GetDeficiencyHistoryApplicationID(int BTERRegID,string ApplicationStatus);
        bool RevertnocSaveData(NOCRevertOtherDetailsDataModel request,string ActionName);
        bool RevertEOALOASaveData(EOALOARevertOtherDetailsDataModel request,string ActionName);
        bool RevertApplicationSaveData(ApplicationRevertOtherDetailsDataModel request,string ActionName);
        List<BTEROtherDetailsDataModel> ApplicationSubmit(int BTERRegID,string ActionName);
        bool Generateorder_SaveData(Generateorderforbter request);
    }
}