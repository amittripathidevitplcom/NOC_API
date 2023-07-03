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
    public class WorkFlowMaster : UtilityBase, IWorkFlowMaster
    {
        public WorkFlowMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public bool IfExists(int WorkFlowMasterID,  int RoleID)
        {
            return UnitOfWork.WorkFlowMasterRepository.IfExists(WorkFlowMasterID,RoleID);
        }

        public bool SaveData(WorkFlowMasterDataModel request)
        {
            return UnitOfWork.WorkFlowMasterRepository.SaveData(request);
        }
        public List<WorkFlowMasterDataModel> GetWorkFlowMasterList(int WorkFlowMasterID)
        {
            return UnitOfWork.WorkFlowMasterRepository.GetWorkFlowMasterList(WorkFlowMasterID);
        }
}
}
