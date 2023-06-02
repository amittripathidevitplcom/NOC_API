using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Xml.Linq;
using System.Data;

namespace FIH_EPR_Utility.CustomerDomain
{
    public class CommonFuncation : UtilityBase, ICommonFuncation
    {
        public CommonFuncation(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public string UploadFilePath()
        {
            return UnitOfWork.CommonFuncationRepository.UploadFilePath();
        }

      

        public List<CommonDataModel_DepartmentMasterList> GetDepartmentList()
        {
            return UnitOfWork.CommonFuncationRepository.GetDepartmentList();
        }
        public List<CommonDataModel_SchemeListByDepartment> GetSchemeListByDepartment(int DepatmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetSchemeListByDepartment(DepatmentID);
        }
        public List<CommonDataModel_ModuleMasterList> GetModuleList()
        {
            return UnitOfWork.CommonFuncationRepository.GetModuleList();
        }
        public List<CommonDataModel_SubModuleListByModule> GetSubModuleListByModule(int ModuleID)
        {
            return UnitOfWork.CommonFuncationRepository.GetSubModuleListByModule(ModuleID);
        }
        public List<CommonDataModel_LevelMasterList> GetLevelList()
        {
            return UnitOfWork.CommonFuncationRepository.GetLevelList();
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleListByLevel(int LevelID)
        {
            return UnitOfWork.CommonFuncationRepository.GetRoleListByLevel(LevelID);
        }
        public List<CommonDataModel_ActionHeadList> GetActionHeadList()
        {
            return UnitOfWork.CommonFuncationRepository.GetActionHeadList();
        }
        public List<CommonDataModel_ActionListByActionHead> GetActionListByActionHead(int ActionHeadID)
        {
            return UnitOfWork.CommonFuncationRepository.GetActionListByActionHead(ActionHeadID);
        }
    }
}
