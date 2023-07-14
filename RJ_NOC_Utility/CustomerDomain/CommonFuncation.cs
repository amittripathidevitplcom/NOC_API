using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Xml.Linq;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
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

        public List<CommonDataModel_DepartmentMaster> GetDepartmentMaster()
        {
            return UnitOfWork.CommonFuncationRepository.GetDepartmentMaster();
        }

        public List<CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster> GetCollageList_DepartmentAndSSOIDWise(int DepartmentID, string LoginSSOID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollageList_DepartmentAndSSOIDWise(DepartmentID, LoginSSOID, Type);
        }

        public List<CommonDataModel_CourseMaster> GetCourseList_DepartmentIDWise(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseList_DepartmentIDWise(DepartmentID);
        }

        public List<CommonDataModel_SubjectMaster> GetSubjectList_CourseIDWise(int CourseID)
        {
            return UnitOfWork.CommonFuncationRepository.GetSubjectList_CourseIDWise(CourseID);
        }

        public List<CommonDataModel_SeatInformationMaster> GetSeatInformation_CourseIDWise(int CourseID)
        {
            return UnitOfWork.CommonFuncationRepository.GetSeatInformation_CourseIDWise(CourseID);
        }


        public List<CommonDataModel_DistrictList> GetDistrictList()
        {
            return UnitOfWork.CommonFuncationRepository.GetDistrictList();
        }


        public List<CommonDataModel_StateList> GetStateList()
        {
            return UnitOfWork.CommonFuncationRepository.GetStateList();
        }

        public List<CommonDataModel_DistrictList> GetDistrictListByStateID(int StateID)
        {
            return UnitOfWork.CommonFuncationRepository.GetDistrictListByStateID(StateID);
        }

        public List<CommonDataModel_DivisionDDL> GetAllDivision()
        {
            return UnitOfWork.CommonFuncationRepository.GetAllDivision();
        }
        public List<CommonDataModel_DistrictList> GetDistrictByDivsionId(int divisionId)
        {
            return UnitOfWork.CommonFuncationRepository.GetDistrictByDivsionId(divisionId);
        }
        public List<CommonDataModel_UniversityDDL> GetUniversityByDepartmentId(int departmentId)
        {
            return UnitOfWork.CommonFuncationRepository.GetUniversityByDepartmentId(departmentId);
        }
        public List<CommonDataModel_SuvdivisionDDL> GetSuvdivisionByDistrictId(int districtId)
        {
            return UnitOfWork.CommonFuncationRepository.GetSuvdivisionByDistrictId(districtId);
        }
        public List<CommonDataModel_TehsilDDL> GetTehsilByDistrictId(int districtId)
        {
            return UnitOfWork.CommonFuncationRepository.GetTehsilByDistrictId(districtId);
        }
        public List<CommonDataModel_PanchyatSamitiDDL> GetPanchyatSamitiByDistrictId(int districtId)
        {
            return UnitOfWork.CommonFuncationRepository.GetPanchyatSamitiByDistrictId(districtId);
        }
        public List<CommonDataModel_ParliamentAreaDDL> GetParliamentAreaByDistrictId(int districtId)
        {
            return UnitOfWork.CommonFuncationRepository.GetParliamentAreaByDistrictId(districtId);
        }
        public List<CommonDataModel_AssemblyAreaDDL> GetAssembelyAreaByDistrictId(int districtId)
        {
            return UnitOfWork.CommonFuncationRepository.GetAssembelyAreaByDistrictId(districtId);
        }
        public List<CommonDataModel_FinancialYearDDL> GetAllFinancialYear()
        {
            return UnitOfWork.CommonFuncationRepository.GetAllFinancialYear();
        }

        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetCommonMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetCommonMasterList_DepartmentAndTypeWise(DepartmentID, Type);
        }
        public List<CommonDataModel_DocumentMasterDepartmentAndTypeWise> GetDocumentMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetDocumentMasterList_DepartmentAndTypeWise(DepartmentID, Type);
        }
        public List<CommonDataModel_LandAreaMasterList_DepartmentWise> GetLandAreaMasterList_DepartmentWise(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetLandAreaMasterList_DepartmentWise(DepartmentID);
        }
        public List<CommonDataModel_LandTypeMasterList_DepartmentWise> GetLandTypeMasterList_DepartmentAndLandConvertWise(int DepartmentID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetLandTypeMasterList_DepartmentAndLandConvertWise(DepartmentID, Type);
        }
        public List<CommonDataModel_LandDocumentTypeMasterList_DepartmentWise> GetLandDoucmentTypeMasterList_DepartmentWise(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetLandDoucmentTypeMasterList_DepartmentWise(DepartmentID);
        }

        public List<CommonDataModel_CollegeWiseCourseList> GetCourseList_CollegeWise(int CollegID,int CourseType)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseList_CollegeWise(CollegID, CourseType);
        }

        public List<CommonDataModel_CourseRoomSize> GetCourseRoomSize(int CourseID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseRoomSize(CourseID);
        }

        public List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> OtherInformationList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.OtherInformationList_DepartmentAndTypeWise(DepartmentID, Type);
        }

        public List<CommonDataModel_OtherInformationSize> OtherInformationSize(int OtherInformationID)
        {
            return UnitOfWork.CommonFuncationRepository.OtherInformationSize(OtherInformationID);
        }

        //public List<CommonDataModel_QualificationMasterDepartmentAndTypeWise> GetQualificationMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        //{
        //    return UnitOfWork.CommonFuncationRepository.GetQualificationMasterList_DepartmentAndTypeWise(DepartmentID, Type);
        //}

        public List<CommonDataModel_BuildingType> GetBuildingTypeCheck()
        {
            return UnitOfWork.CommonFuncationRepository.GetBuildingTypeCheck();
        }
        public List<CommonDataModel_BuildingUploadDoc> GetBuildingUploadDetails()
        {
            return UnitOfWork.CommonFuncationRepository.GetBuildingUploadDetails();
        }
        public List<CommonDataModel_LandAreaMasterList_DepartmentWise> GetLandAreaMasterList_DepartmentWise(int DepartmentID, int CollageID)
        {
            return UnitOfWork.CommonFuncationRepository.GetLandAreaMasterList_DepartmentWise(DepartmentID, CollageID);
        }

        public List<CommonDataModel_TermAndCondition> GetTermAndConditionList_DepartmentWise(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetTermAndConditionList_DepartmentWise(DepartmentID);
        }
        public List<CommonDataModel_Annexure> GetAnnexureDataList_DepartmentWise(int DepartmentID, int LandDocumentTypeID, int LandConvertedID)
        {
            return UnitOfWork.CommonFuncationRepository.GetAnnexureDataList_DepartmentWise(DepartmentID, LandDocumentTypeID, LandConvertedID);
        }
        public List<CommonDataModel_QualificationMasterDepartmentWise> GetQualificationMasterList_DepartmentWise(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetQualificationMasterList_DepartmentWise(DepartmentID);
        }


        public List<CommonDataModel_CollegeWiseSubject> GetCollegeWiseSubjectList(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeWiseSubjectList(CollegeID);
        }
        public List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitiesMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetFacilitiesMasterList_DepartmentAndTypeWise(DepartmentID, Type);
        }
        public List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitesMinSize(int FacilitieID)
        {
            return UnitOfWork.CommonFuncationRepository.GetFacilitesMinSize(FacilitieID);
        }

        public List<CommonDataModel_DashBoard> GetDashboardDataSSOWise(string SSOID, int DepartmentID, int RoleID,int UserID)
        {
            return UnitOfWork.CommonFuncationRepository.GetDashboardDataSSOWise(SSOID, DepartmentID, RoleID, UserID);
        }
        public List<CommonDataModel_DesignationDDL> GetAllDesignation()
        {
            return UnitOfWork.CommonFuncationRepository.GetAllDesignation();
        }
        public List<CommonDataModel_OccupationDDL> GetAllOccupation()
        {
            return UnitOfWork.CommonFuncationRepository.GetAllOccupation();
        }

        public List<CommonDataModel_DataTable> GetCollegeBasicDetails(int CollegID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeBasicDetails(CollegID);
        }    
        public List<CommonDataModel_TabField> GetTabFieldByTabName(string TabName)
        {
            return UnitOfWork.CommonFuncationRepository.GetTabFieldByTabName(TabName);
        }
        public List<CommonDataModel_DataTable> CheckTabsEntry(int CollegID)
        {
            return UnitOfWork.CommonFuncationRepository.CheckTabsEntry(CollegID);
        }
        public bool DraftFinalSubmit(int CollegeID, int IsDraftSubmited)
        {
            return UnitOfWork.CommonFuncationRepository.DraftFinalSubmit(CollegeID, IsDraftSubmited);
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleList()
        {
            return UnitOfWork.CommonFuncationRepository.GetRoleList();
        }
        public List<CommonDataModel_DistrictList> Load_StateWise_DistrictMaster(int StateID)
        {
            return UnitOfWork.CommonFuncationRepository.Load_StateWise_DistrictMaster(StateID);
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleListByLevelID(int LevelID)
        {
            return UnitOfWork.CommonFuncationRepository.GetRoleListByLevelID(LevelID);
        }

        public List<CommonDataModel_GetConnectionString> GetConnectionString()
        {
            return UnitOfWork.CommonFuncationRepository.GetConnectionString();
        }
        public List<CommonDataModel_CommitteeList> GetCommitteeList()
        {
            return UnitOfWork.CommonFuncationRepository.GetCommitteeList();
        }

        public List<CommonDataModel_RoleListByLevel> GetRoleListForApporval(int RoleID)
        {
            return UnitOfWork.CommonFuncationRepository.GetRoleListForApporval(RoleID);
        }

        public List<CreateUserDataModel> GetUserDetailsByRoleID(int RoleID)
        {
            return UnitOfWork.CommonFuncationRepository.GetUserDetailsByRoleID(RoleID);
        }
    }
}
