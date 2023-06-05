using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IWorkFlowMasterRepository
    {
        bool SaveData(WorkFlowMasterDataModel request);
        bool IfExists(int WorkFlowMasterID, int SubModuleID,int RoleID);
        List<WorkFlowMasterDataModel> GetWorkFlowMasterList(int WorkFlowMasterID);
    }

}

