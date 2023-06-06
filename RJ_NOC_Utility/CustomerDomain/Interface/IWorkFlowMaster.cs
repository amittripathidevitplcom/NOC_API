using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IWorkFlowMaster
    {
        bool SaveData(WorkFlowMasterDataModel request);
        bool IfExists(int WorkFlowMasterID, int SubModuleID, int RoleID);
        List<WorkFlowMasterDataModel> GetWorkFlowMasterList(int WorkFlowMasterID);
    }
}