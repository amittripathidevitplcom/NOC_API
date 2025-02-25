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

        public bool IfExists(int WorkFlowMasterID,  int RoleID, int DepartmentID, string NOCType, string CollegeType)
        {
            return UnitOfWork.WorkFlowMasterRepository.IfExists(WorkFlowMasterID,RoleID, DepartmentID, NOCType,CollegeType);
        }

        public bool SaveData(WorkFlowMasterDataModel request)
        {
            return UnitOfWork.WorkFlowMasterRepository.SaveData(request);
        }
        public List<WorkFlowMasterDataModel> GetWorkFlowMasterList(int WorkFlowMasterID)
        {
            return UnitOfWork.WorkFlowMasterRepository.GetWorkFlowMasterList(WorkFlowMasterID);
        }
        public List<DataTable> GetWorkFlowformat3(int DepartmentID, string ReportType)
        {
            return UnitOfWork.WorkFlowMasterRepository.GetWorkFlowformat3(DepartmentID,ReportType);
        }


        
    }
}
