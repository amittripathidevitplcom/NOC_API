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
    }
}