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
        bool DTEAffilitionOtherDetailsSaveData(DTEAffiliationOtherDetailsDataModel request);
        List<DTEAffiliationAddCoursePreviewDataModel> GetDTEAffiliationCoursePreviewData(int DepatmentID);
        List<DTEAffiliationAddOtherDetailsPreviewDataModel> GetDTEAffiliationOtherDetailsPreviewData(int DepatmentID);
        List<DTEAffiliationRegistrationDataModel> Edit_OnClick(int DTE_ARId);
    }
}