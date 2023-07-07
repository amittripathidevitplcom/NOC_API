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
        DataTable GetApplyNocApplicationList();
        DataSet GetApplyNocForByParameter(int CollegeID, string ApplyNocFor);
        DataTable GetApplyNocParameterMaster(int CollegeID);
        bool SaveApplyNocApplication(string query);
        DataTable GetApplyNoc_FDRMasterByCollegeID(int CollegeID);
        bool SaveApplyNoc_FDRMasterDetail(ApplyNocFDRDetailsDataModel request);
        DataTable GetApplyNocFDRDetails(int ApplyNocFDRID,int ApplyNocID);
        bool FinalSubmitApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy, string IpAddress);
    }
}