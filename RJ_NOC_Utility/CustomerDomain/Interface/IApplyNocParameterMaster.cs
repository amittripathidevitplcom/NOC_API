using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IApplyNocParameterMaster
    {
        ApplyNocParameterMaster_TNOCExtensionDataModel GetApplyNocFor_TNOCExtension(int CollegeID, string ApplyNocFor);
        ApplyNocParameterMaster_AdditionOfNewSeats60DataModel GetApplyNocFor_AdditionOfNewSeats60(int CollegeID, string ApplyNocFor);
        List<ApplyNocParameterMaster_ddl> GetApplyNocParameterMaster(int CollegeID);
        bool SaveApplyNocApplication(ApplyNocParameterDataModel request);
        List<ApplyNocApplicationDataModel> GetApplyNocApplicationList(string SSOID);  
        ApplyNocApplicationDataModel GetApplyNocApplicationByApplicationID(int ApplyNocApplicationID);
        bool DeleteApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy);
        List<ApplyNocFDRDetailsDataModel> GetApplyNoc_FDRMasterByCollegeID(int CollegeID);
        bool SaveApplyNoc_FDRMasterDetail(ApplyNocFDRDetailsDataModel request);
        List<ApplyNocFDRDetailsDataModel> GetApplyNocFDRDetails(int ApplyNocFDRID, int ApplyNocID);
        bool FinalSubmitApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy);
        List<CommonDataModel_DataTable> GetApplyNocPaymentHistoryApplicationID(int ApplyNocApplicationID);
        List<CommonDataModel_DataTable> GetApplicationPaymentHistoryApplicationID(int ApplyNocApplicationID);
    }
}