using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ICommonFuncationRepository
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
        List<CommonDataModel_DistrictList> GetDistrictList();
        List<CommonDataModel_StateList> GetStateList();
        List<CommonDataModel_DistrictList> GetDistrictListByStateID(int StateID);

        List<CommonDataModel_DocumentMasterDepartmentAndTypeWise> GetDocumentMasterList_DepartmentAndTypeWise(int DepartmentID, string Type);
        List<CommonDataModel_LandAreaMasterList_DepartmentWise> GetLandAreaMasterList_DepartmentWise(int DepartmentID);
        List<CommonDataModel_LandTypeMasterList_DepartmentWise> GetLandTypeMasterList_DepartmentWise(int DepartmentID);
        List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise> GetLandDoucmentTypeMasterList_DepartmentWise(int DepartmentID);
        List<CommonDataModel_CollegeWiseCourseList> GetCourseList_CollegeWise(int CollegID);
        List<CommonDataModel_CourseRoomSize> GetCourseRoomSize(int CourseID);
        List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> OtherInformationList_DepartmentAndTypeWise(int DepartmentID, string Type);
        List<CommonDataModel_OtherInformationSize> OtherInformationSize(int OtherInformationID);

        List<CommonDataModel_QualificationMasterDepartmentAndTypeWise> GetQualificationMasterList_DepartmentAndTypeWise(int DepartmentID, string Type);
    }
}

