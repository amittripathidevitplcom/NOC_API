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
        List<DTEAffiliationAddCoursePreviewDataModel> GetDTEAffiliationCoursePreviewData(int DepatmentID);
        List<DTEAffiliationAddOtherDetailsPreviewDataModel> GetDTEAffiliationOtherDetailsPreviewData(int DepatmentID);
        List<DTEAffiliationRegistrationDataModel> Edit_OnClick(int DTE_ARId);
    }

}

