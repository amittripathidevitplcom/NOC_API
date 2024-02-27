using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IApplyNocParameterMasterRepository
    {
        bool DeleteApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy, string IpAddress);
        DataSet GetApplyNocApplicationByApplicationID(int ApplyNocApplicationID);
        DataTable GetApplyNocApplicationList(string SSOID);
        DataSet GetApplyNocForByParameter(int CollegeID, string ApplyNocFor);
        DataTable GetApplyNocParameterMaster(int CollegeID);
        bool SaveApplyNocApplication(string query);
        DataTable GetApplyNoc_FDRMasterByCollegeID(int CollegeID);
        bool SaveApplyNoc_FDRMasterDetail(ApplyNocFDRDetailsDataModel request);
        bool SaveOfflinePaymnetDetail(ApplyNocOfflinePaymentModal request);
        DataTable GetApplyNocFDRDetails(int ApplyNocFDRID,int ApplyNocID);
        bool FinalSubmitApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy, string IpAddress);
        List<CommonDataModel_DataTable> GetApplyNocPaymentHistoryApplicationID(int ApplyNocApplicationID);
        List<ApplyNocParameterFeesDataModel> GetDCECourseSubjectFees(int ApplyNOCParameterID);
        List<CommonDataModel_DataTable> GetApplicationPaymentHistoryApplicationID(int ApplyNocApplicationID);

        List<CommonDataModel_DataTable> GetOfflinePaymentDetails(int ApplyNocApplicationID, int PaymentOfflineID, string ActionName);
        DataTable GetApplyNocApplicationLists(int SelectedCollageID, int SelectedDepartmentID);
        DataTable ViewApplyNocFDRDetailsByCollegeID(int CollegeID);
        DataTable GetCourseSubjectByApplyNOCID(int ApplyNOCID,int ParameterID);
        bool SaveApplyNocMinisterFile(ApplyNoc_MinisterFile request);
    }
}