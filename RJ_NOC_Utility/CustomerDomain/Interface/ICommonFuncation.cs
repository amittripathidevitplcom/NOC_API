using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICommonFuncation
    {
        string UploadFilePath();
        

        List<CommonDataModel_DepartmentMasterList> GetDepartmentList();
        List<CommonDataModel_SchemeListByDepartment> GetSchemeListByDepartment(int DepatmentID);
        List<CommonDataModel_ModuleMasterList> GetModuleList();
        List<CommonDataModel_SubModuleListByModule> GetSubModuleListByModule(int ModuleID);
        List<CommonDataModel_LevelMasterList> GetLevelList();
        List<CommonDataModel_RoleListByLevel> GetRoleListByLevel(int LevelID);
        List<CommonDataModel_ActionHeadList> GetActionHeadList();
        List<CommonDataModel_ActionListByActionHead> GetActionListByActionHead(int ActionHeadID);


        List<CommonDataModel_DepartmentMaster> GetDepartmentMaster();
        List<CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster> GetCollageList_DepartmentAndSSOIDWise(int DepartmentID, string LoginSSOID, string Type);
        List<CommonDataModel_CourseMaster> GetCourseList_DepartmentIDWise(int DepartmentID);
        List<CommonDataModel_SubjectMaster> GetSubjectList_CourseIDWise(int CourseID);
        List<CommonDataModel_SeatInformationMaster> GetSeatInformation_CourseIDWise(int CourseID);
        List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetCommonMasterList_DepartmentAndTypeWise(int DepartmentID, string Type);
    }
}
