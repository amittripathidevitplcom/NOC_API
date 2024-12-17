using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

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

        public bool DTEAffilitionOtherDetailsSaveData(DTEAffiliationOtherDetailsDataModel request)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.DTEAffilitionOtherDetailsSaveData(request);
        }       
        public List<DTEAffiliationAddCoursePreviewDataModel> GetDTEAffiliationCoursePreviewData(int DepatmentID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetDTEAffiliationCoursePreviewData(DepatmentID);
        }
        public List<DTEAffiliationAddOtherDetailsPreviewDataModel> GetDTEAffiliationOtherDetailsPreviewData(int DepatmentID)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.GetDTEAffiliationOtherDetailsPreviewData(DepatmentID);
        }
       
        public List<DTEAffiliationRegistrationDataModel> Edit_OnClick(int DTE_ARId)
        {
            return UnitOfWork.DTEAllifitionMasterRepository.Edit_OnClick(DTE_ARId);
        }
    }
}
