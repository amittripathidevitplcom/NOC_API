using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IApplyNocParameterMasterRepository
    {
        DataTable GetApplyNocApplicationList();
        DataSet GetApplyNocForByParameter(int CollegeID, string ApplyNocFor);
        DataTable GetApplyNocParameterMaster(int CollegeID);
        bool SaveApplyNocApplication(string query);
    }
}