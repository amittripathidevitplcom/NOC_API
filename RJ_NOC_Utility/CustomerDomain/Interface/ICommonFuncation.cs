using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;
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
        List<CommonDataModel_DistrictList> GetDistrictList();
        List<CommonDataModel_StateList> GetStateList();
        List<CommonDataModel_DistrictList> GetDistrictListByStateID(int StateID);
        List<CommonDataModel_DivisionDDL> GetAllDivision();
        List<CommonDataModel_DistrictList> GetDistrictByDivsionId(int divisionId);
        List<CommonDataModel_UniversityDDL> GetUniversityByDepartmentId(int departmentId);
        List<CommonDataModel_SuvdivisionDDL> GetSuvdivisionByDistrictId(int districtId);
        List<CommonDataModel_TehsilDDL> GetTehsilByDistrictId(int districtId);
        List<CommonDataModel_PanchyatSamitiDDL> GetPanchyatSamitiByDistrictId(int districtId);
        List<CommonDataModel_ParliamentAreaDDL> GetParliamentAreaByDistrictId(int districtId);
        List<CommonDataModel_AssemblyAreaDDL> GetAssembelyAreaByDistrictId(int districtId);
        List<CommonDataModel_FinancialYearDDL> GetAllFinancialYear();

        List<CommonDataModel_DocumentMasterDepartmentAndTypeWise> GetDocumentMasterList_DepartmentAndTypeWise(int DepartmentID, string Type);
        List<CommonDataModel_LandAreaMasterList_DepartmentWise> GetLandAreaMasterList_DepartmentWise(int DepartmentID);
        List<CommonDataModel_LandTypeMasterList_DepartmentWise> GetLandTypeMasterList_DepartmentAndLandConvertWise(int DepartmentID, string Type);
        List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise> GetLandDoucmentTypeMasterList_DepartmentWise(int DepartmentID);
        List<CommonDataModel_DesignationDDL> GetAllDesignation();
        List<CommonDataModel_OccupationDDL> GetAllOccupation();

        List<CommonDataModel_CollegeWiseCourseList> GetCourseList_CollegeWise(int CollegID, int CourseType);
        List<CommonDataModel_CourseRoomSize> GetCourseRoomSize(int CourseID);
        List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> OtherInformationList_DepartmentAndTypeWise(int DepartmentID, string Type);
        List<CommonDataModel_OtherInformationSize> OtherInformationSize(int OtherInformationID);



        List<CommonDataModel_BuildingType> GetBuildingTypeCheck();
        List<CommonDataModel_BuildingUploadDoc> GetBuildingUploadDetails();


        List<CommonDataModel_TermAndCondition> GetTermAndConditionList_DepartmentWise(int DepartmentID);
        List<CommonDataModel_Annexure> GetAnnexureDataList_DepartmentWise(int DepartmentID, int LandDocumentTypeID, int LandConvertedID);
        List<CommonDataModel_LandAreaMasterList_DepartmentWise> GetLandAreaMasterList_DepartmentWise(int DepartmentID, int CollageID);

        List<CommonDataModel_QualificationMasterDepartmentWise> GetQualificationMasterList_DepartmentWise(int DepartmentID);

        List<CommonDataModel_CollegeWiseSubject> GetCollegeWiseSubjectList(int CollegeID);

        List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitiesMasterList_DepartmentAndTypeWise(int DepartmentID, string Type);
        List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitesMinSize(int FacilitieID);
        List<CommonDataModel_DashBoard> GetDashboardDataSSOWise(string SSOID);
        List<CommonDataModel_DataTable> GetCollegeBasicDetails(int CollegID);

    }

}
