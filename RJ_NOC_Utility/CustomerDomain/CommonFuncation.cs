using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Xml.Linq;
using System.Data;
using static Azure.Core.HttpHeader;
using Newtonsoft.Json.Linq;
using System.Web.Http.Common;
using System.Net;
using RJ_NOC_DataAccess.Common;

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
        public int Client_FolderWiseImages(string SqlQry)
        {
            return UnitOfWork.CommonFuncationRepository.Client_FolderWiseImages(SqlQry);
        }



        public List<CommonDataModel_DepartmentMasterList> GetDepartmentList()
        {
            return UnitOfWork.CommonFuncationRepository.GetDepartmentList();
        }
        public List<CommonDataModel_DepartmentMasterList> GetDepartmentList_IsOpenNOCApplication()
        {
            return UnitOfWork.CommonFuncationRepository.GetDepartmentList_IsOpenNOCApplication();
        }
        public List<CommonDataModel_DepartmentMasterList> GetDepartmentList_IsOpenDefaulter()
        {
            return UnitOfWork.CommonFuncationRepository.GetDepartmentList_IsOpenDefaulter();
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
        public List<CommonDataModel_CourseMaster> GetAddCourseList_DepartmentIDWise(int DepartmentID, int CourseLevelID)
        {
            return UnitOfWork.CommonFuncationRepository.GetAddCourseList_DepartmentIDWise(DepartmentID, CourseLevelID);
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
        public List<CommonDataModel_UniversityDDL> GetUniversityByDepartmentId(int departmentId, int IsLaw)
        {
            return UnitOfWork.CommonFuncationRepository.GetUniversityByDepartmentId(departmentId, IsLaw);
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
        public List<CommonDataModel_FinancialYearDDL> GetAllFinancialYear_AcademicInformation()
        {
            return UnitOfWork.CommonFuncationRepository.GetAllFinancialYear_AcademicInformation();
        }
        public List<CommonDataModel_FinancialYearDDL> GetAllFinancialYear_OldNOC(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetAllFinancialYear_OldNOC(CollegeID);
        }

        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetCommonMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetCommonMasterList_DepartmentAndTypeWise(DepartmentID, Type);
        }
        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetCommonMasterList_DTEManagementType(int DepartmentID, string Type, string SSOID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCommonMasterList_DTEManagementType(DepartmentID, Type, SSOID);
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

        public List<CommonDataModel_CollegeWiseCourseList> GetCourseList_CollegeWise(int CollegID, string CourseType)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseList_CollegeWise(CollegID, CourseType);
        }

        public List<DataTable> Get_CollegeWiseCourse_Subject_OldNOC(int CollegeID, string Type, int CourseID, int OldNocID)
        {
            return UnitOfWork.CommonFuncationRepository.Get_CollegeWiseCourse_Subject_OldNOC(CollegeID, Type, CourseID, OldNocID);
        }

        public List<DataTable> GetCollegeWise_SubjectList_StaffDetails(int CollegeID, string Type, int CourseID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeWise_SubjectList_StaffDetails(CollegeID, Type, CourseID);
        }
        public List<DataTable> GetCollegeWise_CourseList_AcademicInformation(int CollegeID, string Type, int CourseID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeWise_CourseList_AcademicInformation(CollegeID, Type, CourseID);
        }

        public List<CommonDataModel_CourseRoomSize> GetCourseRoomSize(int CourseID, int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseRoomSize(CourseID, CollegeID);
        }

        public List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> OtherInformationList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.OtherInformationList_DepartmentAndTypeWise(DepartmentID, Type);
        }
        public List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> OtherInformationList_DepartmentCollegeAndTypeWise(int DepartmentID, int CollegeID, int OtherInformationID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.OtherInformationList_DepartmentCollegeAndTypeWise(DepartmentID, CollegeID, OtherInformationID, Type);
        }
        public List<CommonDataModel_OtherInformationList_DepartmentAndTypeWise> OtherInformationList_CourseID(int CourseID, int CollegeID, int OtherInformationID)
        {
            return UnitOfWork.CommonFuncationRepository.OtherInformationList_CourseID(CourseID, CollegeID, OtherInformationID);
        }

        public List<CommonDataModel_OtherInformationSize> OtherInformationSize(int OtherInformationID)
        {
            return UnitOfWork.CommonFuncationRepository.OtherInformationSize(OtherInformationID);
        }

        //public List<CommonDataModel_QualificationMasterDepartmentAndTypeWise> GetQualificationMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        //{
        //    return UnitOfWork.CommonFuncationRepository.GetQualificationMasterList_DepartmentAndTypeWise(DepartmentID, Type);
        //}

        public List<CommonDataModel_BuildingType> GetBuildingTypeCheck(int SelectedDepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetBuildingTypeCheck(SelectedDepartmentID);
        }
        public List<CommonDataModel_BuildingType> GetlstMGOneIstheCampusUnitaryChk(int SelectedDepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetlstMGOneIstheCampusUnitaryChk(SelectedDepartmentID);
        }
        public List<CommonDataModel_BuildingUploadDoc> GetBuildingUploadDetails(int DepartmentId)
        {
            return UnitOfWork.CommonFuncationRepository.GetBuildingUploadDetails(DepartmentId);
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
        public List<CommonDataModel_QualificationMasterDepartmentWise> GetQualificationMasterList_DepartmentWise(int DepartmentID, int IsTeaching, string Type, int DesignationID)
        {
            return UnitOfWork.CommonFuncationRepository.GetQualificationMasterList_DepartmentWise(DepartmentID, IsTeaching, Type, DesignationID);
        }


        public List<CommonDataModel_CollegeWiseSubject> GetCollegeWiseSubjectList(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeWiseSubjectList(CollegeID);
        }
        public List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitiesMasterList_DepartmentAndTypeWise(int DepartmentID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetFacilitiesMasterList_DepartmentAndTypeWise(DepartmentID, Type);
        }
        public List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitiesMasterList_DepartmentCollegeAndTypeWise(int DepartmentID, int CollegeID, int FacilitieID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetFacilitiesMasterList_DepartmentCollegeAndTypeWise(DepartmentID, CollegeID, FacilitieID, Type);
        }
        public List<CommonDataModel_ActivityMasterDepartmentAndTypeWise> GetActivityMasterList_DepartmentCollegeAndTypeWise(int DepartmentID, int CollegeID, int FacilitieID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetActivityMasterList_DepartmentCollegeAndTypeWise(DepartmentID, CollegeID, FacilitieID, Type);
        }
        public List<CommonDataModel_FacilitesMasterDepartmentAndTypeWise> GetFacilitesMinSize(int FacilitieID)
        {
            return UnitOfWork.CommonFuncationRepository.GetFacilitesMinSize(FacilitieID);
        }

        public List<CommonDataModel_DashBoard> GetDashboardDataSSOWise(string SSOID, int DepartmentID, int RoleID, int UserID, bool IsWeb, int SessionYear)
        {
            return UnitOfWork.CommonFuncationRepository.GetDashboardDataSSOWise(SSOID, DepartmentID, RoleID, UserID, IsWeb, SessionYear);
        }
        public List<CommonDataModel_DesignationDDL> GetAllDesignation()
        {
            return UnitOfWork.CommonFuncationRepository.GetAllDesignation();
        }
        public List<CommonDataModel_DesignationDDL> GetDesignation_OfficersDetails(string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetDesignation_OfficersDetails(Type);
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
        public List<CommonDataModel_DataTable> CheckTabsEntry_StatisticsEntry(int CollegID)
        {
            return UnitOfWork.CommonFuncationRepository.CheckTabsEntry_StatisticsEntry(CollegID);
        }
        public bool DraftFinalSubmit(CommonDataModel_CollegeDraftFinal request)
        {
            return UnitOfWork.CommonFuncationRepository.DraftFinalSubmit(request);
        }
        public bool LOIFinalSubmit(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.LOIFinalSubmit(CollegeID);
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleList()
        {
            return UnitOfWork.CommonFuncationRepository.GetRoleList();
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleList_CreateUser()
        {
            return UnitOfWork.CommonFuncationRepository.GetRoleList_CreateUser();
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

        public List<CommonDataModel_RoleListByLevel> GetRoleListForApporval(int RoleID, int DepartmentID, string NOCType)
        {
            return UnitOfWork.CommonFuncationRepository.GetRoleListForApporval(RoleID, DepartmentID, NOCType);
        }

        public List<CreateUserDataModel> GetUserDetailsByRoleID(int RoleID, int DepartmentID, int ApplyNOCID)
        {
            return UnitOfWork.CommonFuncationRepository.GetUserDetailsByRoleID(RoleID, DepartmentID, ApplyNOCID);
        }
        public List<CommonDataModel_WorkFlowActionsByRole> GetWorkFlowActionListByRole(int RoleID, string Type, int DepartmentID, string NOCType, int ApplyNOCID)
        {
            return UnitOfWork.CommonFuncationRepository.GetWorkFlowActionListByRole(RoleID, Type, DepartmentID, NOCType, ApplyNOCID);
        }
        public List<CommonDataModel_RNCCheckListData> GetRNCCheckListByTypeDepartment(string Type, int DepartmentID, int ApplyNOCID, int CreatedBy, int RoleID)
        {
            return UnitOfWork.CommonFuncationRepository.GetRNCCheckListByTypeDepartment(Type, DepartmentID, ApplyNOCID, CreatedBy, RoleID);
        }
        public List<CommonDataModel_ApplicationTrail> GetApplicationTrail_DepartmentApplicationWise(int ApplicationID, int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetApplicationTrail_DepartmentApplicationWise(ApplicationID, DepartmentID);
        }
        public List<CommonDataModel_CourseMaster> GetCourseList_ByCourseLevelIDWise(int CourseLevelID, int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseList_ByCourseLevelIDWise(CourseLevelID, DepartmentID);
        }

        public List<CommonDataModel_Stream> GetStreamList_CourseIDWise(int DepartmentID, int CourseLevelID, int CourseID)
        {
            return UnitOfWork.CommonFuncationRepository.GetStreamList_CourseIDWise(DepartmentID, CourseLevelID, CourseID);
        }
        public List<CommonDataModel_SubjectMaster> GetSubjectList_StreamIDWise(int StreamID, int DepartmentID, int CourseLevelID, int CourseID)
        {
            return UnitOfWork.CommonFuncationRepository.GetSubjectList_StreamIDWise(StreamID, DepartmentID, CourseLevelID, CourseID);
        }

        public List<CommonDataModel_DataTable> GetCollegeWiseCourseList(int CollegID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeWiseCourseList(CollegID);
        }
        public List<CommonDataModel_DataTable> GetCollegeWiseCourseIDSubjectList(int CollegeID, int CollegeWiseCourseID, string ViewMode)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeWiseCourseIDSubjectList(CollegeID, CollegeWiseCourseID, ViewMode);
        }
        public List<CommonDataModel_DataTable> GetStreamMasterList(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetStreamMasterList(DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetMappedStreamListByID(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetMappedStreamListByID(DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetCourseByStreamID(int StreamID, int DepartmentID, int CourseLevelID, int UniversityID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseByStreamID(StreamID, DepartmentID, CourseLevelID, UniversityID);
        }

        public List<CommonDataModel_LandSqureMeterMappingDetails_DepartmentWise> GetLandSqureMeterMappingDetails_DepartmentWise(int DepartmentID, int CollageID, int LandAreaId)
        {
            return UnitOfWork.CommonFuncationRepository.GetLandSqureMeterMappingDetails_DepartmentWise(DepartmentID, CollageID, LandAreaId);
        }

        public List<CommonDataModel_DataTable> GetDocumentScritintyTaril(int ID, int NOCApplyID, int CollageID, int DepartmentID, string ActionType)
        {
            return UnitOfWork.CommonFuncationRepository.GetDocumentScritintyTaril(ID, NOCApplyID, CollageID, DepartmentID, ActionType);
        }
        public List<CommonDataModel_DataTable> GetStaffDesignation(int IsTeaching, int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetStaffDesignation(IsTeaching, DepartmentID);
        }
        public List<CollegeLandTypeDetailsDataModel> GetLandTypeDetails_CollegeWise(int DepartmentID, string Type, int LandTypeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetLandTypeDetails_CollegeWise(DepartmentID, Type, LandTypeID);
        }
        public List<CommonDataModel_UniversityDDL> GetUniversityDepartmentWise(int DepartmentId)
        {
            return UnitOfWork.CommonFuncationRepository.GetUniversityDepartmentWise(DepartmentId);
        }
        public List<CommonDataModel_SubjectMaster> GetSubjectDepartmentWise(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetSubjectDepartmentWise(DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetCollegeInspectionFee(int CollageID, int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeInspectionFee(CollageID, DepartmentID);
        }
        public List<CollegeLandConversionDetailsDataModel> GetCollegeLandConversionDetail(int DepartmentID, int LandDetailsId, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeLandConversionDetail(DepartmentID, LandDetailsId, Type);
        }
        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetCommonMasterList_DepartmentAndTypeWises(int DepartmentID, int CollageID, string Type)
        {
            return UnitOfWork.CommonFuncationRepository.GetCommonMasterList_DepartmentAndTypeWises(DepartmentID, CollageID, Type);
        }
        public List<CommonDataModel_DataTable> GetCityByDistrict(int DistrictID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCityByDistrict(DistrictID);
        }
        public List<CommonDataModel_DataTable> GetNOCApplicationStepList(int ApplyNocID, int CurrentActionID, int DepartmentID, string ActionType)
        {
            return UnitOfWork.CommonFuncationRepository.GetNOCApplicationStepList(ApplyNocID, CurrentActionID, DepartmentID, ActionType);
        }
        public List<CommonDataModel_DataTable> GetDownloadPdfDetails(int DepartmentID, int CollageID)
        {
            return UnitOfWork.CommonFuncationRepository.GetDownloadPdfDetails(DepartmentID, CollageID);
        }
        public List<CommonDataModel_DataTable> GetPaymentMode()
        {
            return UnitOfWork.CommonFuncationRepository.GetPaymentMode();
        }

        public bool SaveExcelData(List<MemberDataModel> request, int StaticsFileID, int DeptId, int collegeID, int courseID, string FinYear, string FileName, string SSOID)
        {
            return UnitOfWork.CommonFuncationRepository.SaveExcelData(request, StaticsFileID, DeptId, collegeID, courseID, FinYear, FileName, SSOID);
        }
        public bool UpdateSingleRow(MemberDataModel request, int DeptId, int collegeID, string SSOID)
        {
            return UnitOfWork.CommonFuncationRepository.UpdateSingleRow(request, DeptId, collegeID, SSOID);
        }
        public List<CommonDataModel_DataTable> GetImportExcelData(string SSOID, int DeptId, int collegeID, int StaticsFileID, string ActionType)
        {
            return UnitOfWork.CommonFuncationRepository.GetImportExcelData(SSOID, DeptId, collegeID, StaticsFileID, ActionType);
        }
        public List<CommonDataModel_CollegeWiseCourseList> GetOldNOCCourseList_CollegeWise(int CollegID)
        {
            return UnitOfWork.CommonFuncationRepository.GetOldNOCCourseList_CollegeWise(CollegID);
        }
        public List<DataTable> CheckExistsDETGovernmentCollege(string SSOID)
        {
            return UnitOfWork.CommonFuncationRepository.CheckExistsDETGovernmentCollege(SSOID);
        }

        public List<DataTable> Get_LOIFeeMaster(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.Get_LOIFeeMaster(DepartmentID);
        }
        public CommonDataModel_DataTable GetAppliedNocInformation(string SSOID)
        {
            return UnitOfWork.CommonFuncationRepository.GetAppliedNocInformation(SSOID);
        }

        public CommonDataModel_CollegeID_SearchRecordIDWise GetCollegeID_SearchRecordIDWise(string SearchRecordID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeID_SearchRecordIDWise(SearchRecordID);
        }
        public List<CommonDataModel_DataTable> GetUsersByRoleDepartment(int DepartmentID, int RoleID)
        {
            return UnitOfWork.CommonFuncationRepository.GetUsersByRoleDepartment(DepartmentID, RoleID);
        }
        public List<CommonDataModel_DataTable> GetWorkFlowStatusbyDepartment(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetWorkFlowStatusbyDepartment(DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetApplyNOCParameterbyDepartment(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetApplyNOCParameterbyDepartment(DepartmentID);
        }
        public List<CommonDataModel_DataTable> WebsiteDetails()
        {
            return UnitOfWork.CommonFuncationRepository.WebsiteDetails();
        }
        public List<CommonDataModel_DataTable> GetTotalApplicationListByDepartment(CommonDataModel_TotalApplicationSearchFilter request)
        {
            return UnitOfWork.CommonFuncationRepository.GetTotalApplicationListByDepartment(request);
        }
        public List<CommonDataModel_DataTable> GetPreviousTotalApplicationListByDepartment(CommonDataModel_TotalApplicationSearchFilter request)
        {
            return UnitOfWork.CommonFuncationRepository.GetPreviousTotalApplicationListByDepartment(request);
        }
        public List<CommonDataModel_ApplicationTrail> GetLOIApplicationTrail(int ApplicationID, int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetLOIApplicationTrail(ApplicationID, DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetLOIDocumentScritintyTaril(int ID, int NOCApplyID, int CollageID, int DepartmentID, string ActionType)
        {
            return UnitOfWork.CommonFuncationRepository.GetLOIDocumentScritintyTaril(ID, NOCApplyID, CollageID, DepartmentID, ActionType);
        }
        public List<CommonDataModel_DataTable> GetSocietyByCollege(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetSocietyByCollege(CollegeID);
        }
        public List<CommonDataModel_DataTable> GetIntakeByCollegeCourse(int CollegeID, int CourseID)
        {
            return UnitOfWork.CommonFuncationRepository.GetIntakeByCollegeCourse(CollegeID, CourseID);
        }


        public List<CommonDataModel_DataTable> GetProgrammeByCollegeDTE(int CollegeID, string GetType)
        {

            return UnitOfWork.CommonFuncationRepository.GetProgrammeByCollegeDTE(CollegeID, GetType);
        }
        public List<CommonDataModel_DataTable> GetCourseLevelByCollegeDTE(int CollegeID, string GetType)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseLevelByCollegeDTE(CollegeID, GetType);
        }
        public List<CommonDataModel_DataTable> GetCourseByCollegeProgrammeDTE(int CollegeID, int ProgrammeID, int CourseLevelID, string GetType)
        {
            return UnitOfWork.CommonFuncationRepository.GetCourseByCollegeProgrammeDTE(CollegeID, ProgrammeID, CourseLevelID, GetType);
        }

        public List<CommonDataModel_DataTable> GetCollegeDeficiency(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeDeficiency(CollegeID);
        }

        public bool SSOUpdateSubmit(int CollegeID, string SSOID)
        {
            return UnitOfWork.CommonFuncationRepository.SSOUpdateSubmit(CollegeID, SSOID);
        }


        public List<CommonDataModel_DataTable> GetSSOByCollegeIDWise(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetSSOByCollegeIDWise(CollegeID);
        }

        public List<DataTable> HomePage_IncreaseDate(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.HomePage_IncreaseDate(DepartmentID);
        }
        public List<DataTable> GetOnlinePaymentDetailsByDepartment(PaymentDetailsDataModel_Filter request)
        {
            return UnitOfWork.CommonFuncationRepository.GetOnlinePaymentDetailsByDepartment(request);
        }
        public List<DataTable> GetTotalDraftentryCollege(CommonDataModel_TotalDraftEntrySearchFilter request)
        {
            return UnitOfWork.CommonFuncationRepository.GetTotalDraftentryCollege(request);
        }
        public List<DataTable> GetDeficiencyAction(int ApplyNOCID, int RoleID)
        {
            return UnitOfWork.CommonFuncationRepository.GetDeficiencyAction(ApplyNOCID, RoleID);
        }
        public List<DataTable> GetApplicationCountRoleWise(int DepartmentID, int SessionYear = 0)
        {
            return UnitOfWork.CommonFuncationRepository.GetApplicationCountRoleWise(DepartmentID, SessionYear);
        }
        public List<DataTable> GetLegelEntityDepartmentWise(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetLegelEntityDepartmentWise(DepartmentID);
        }
        public bool ConvertBaseIntoImage()
        {
            return UnitOfWork.CommonFuncationRepository.ConvertBaseIntoImage();
        }
        public bool SaveNOCFormatMaster(CommonDataModel_NOCFormatMaster request)
        {
            return UnitOfWork.CommonFuncationRepository.SaveNOCFormatMaster(request);
        }
        public List<DataTable> GetNOCFormatList(int NOCFormatID)
        {
            return UnitOfWork.CommonFuncationRepository.GetNOCFormatList(NOCFormatID);
        }
        public bool UnlockApplication(UnlockApplicationDataModel request)
        {
            return UnitOfWork.CommonFuncationRepository.UnlockApplication(request);
        }
        public List<CommonDataModel_ApplicationTrail> GetUnlockApplicationTrail_DepartmentApplicationWise(int ApplicationID, int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetUnlockApplicationTrail_DepartmentApplicationWise(ApplicationID, DepartmentID);
        }
        public List<CommonDataModel_DataSet> GetCollegeTabData_History(CommonDataModel_TabHistory request)
        {
            return UnitOfWork.CommonFuncationRepository.GetCollegeTabData_History(request);
        }
        public List<CommonDataModel_FinancialYearDDL> GetDashBoardFinancialYear()
        {
            return UnitOfWork.CommonFuncationRepository.GetDashBoardFinancialYear();
        }
        public List<DataTable> GetAHDepartmentList()
        {
            return UnitOfWork.CommonFuncationRepository.GetAHDepartmentList();
        }
        public List<AHDepartmentDataModel> GetAHFacilityDepartmentList(int DepartmentID, int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetAHFacilityDepartmentList(DepartmentID, CollegeID);
        }
        public bool SaveAHDepartmentInfrastructure(AHDepartmentDataModel request)
        {
            return UnitOfWork.CommonFuncationRepository.SaveAHDepartmentInfrastructure(request);
        }
        public List<CommonDataModel_DataSet> CheckAHStaff(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.CheckAHStaff(CollegeID);
        }
        public List<CommonDataModel_DepartmentWiseStartDateEndDate> GetStartDateEndDateDepartmentwise(int DepartmentID)
        {
            return UnitOfWork.CommonFuncationRepository.GetStartDateEndDateDepartmentwise(DepartmentID);
        }
        public List<CommonDataModel_DTEAffiliationApply> GetDTEAffiliationApply(string SSOID)
        {
            return UnitOfWork.CommonFuncationRepository.GetDTEAffiliationApply(SSOID);
        }
        public List<CommonDataModel_RegistrationDTEAffiliationApply> GetAffiliationRegistrationList(string SSOID)
        {
            return UnitOfWork.CommonFuncationRepository.GetAffiliationRegistrationList(SSOID);
        }

        public CommonDataModel_RegistrationDTEAffiliationApply GetDteAffiliation_SearchRecordIDWise(string SearchRecordID)
        {
            return UnitOfWork.CommonFuncationRepository.GetDteAffiliation_SearchRecordIDWise(SearchRecordID);
        }

        public List<DataTable> GetMGOneDepartmentList()
        {
            return UnitOfWork.CommonFuncationRepository.GetMGOneDepartmentList();
        }

        public List<MGOneDepartmentDataModel> GetMGOneFacilityDepartmentList(int DepartmentID, int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetMGOneFacilityDepartmentList(DepartmentID, CollegeID);
        }
        public List<MGOneClassRoomDepartmentDataModel> GetMGOneClassRoomDepartmentList(int DepartmentID, int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetMGOneClassRoomDepartmentList(DepartmentID, CollegeID);
        }
        public bool SaveMGOneDepartmentInfrastructure(MGOneDepartmentDataModel request)
        {
            return UnitOfWork.CommonFuncationRepository.SaveMGOneDepartmentInfrastructure(request);
        }
        public List<MGOneClinicalLabDataModel> GetMGOneClinicalLabDetails(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetMGOneClinicalLabDetails(CollegeID);
        }
        public bool SaveMGOneClinicalLabDetails(List<MGOneClinicalLabDataModel> request)
        {
            return UnitOfWork.CommonFuncationRepository.SaveMGOneClinicalLabDetails(request);
        }

        public bool SaveMGOneClassRoomDetails(List<MGOneClassRoomDepartmentDataModel> request)
        {
            return UnitOfWork.CommonFuncationRepository.SaveMGOneClassRoomDetails(request);
        }
        public List<DataTable> GetMGoneFacilityEach(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetMGoneFacilityEach(CollegeID);
        } 
        public DataSet GetMGoneASSESSMENTREPORT(int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetMGoneASSESSMENTREPORT(CollegeID);
        }        
        public bool SaveMGoneFacilityEach(List<MGOneFacilityEachDataModel> request)
        {
            return UnitOfWork.CommonFuncationRepository.SaveMGoneFacilityEach(request);
        }     
        public List<DataTable> GetWorkflowPermissions(int DepartmentID, int RoleID)
        {
            return UnitOfWork.CommonFuncationRepository.GetWorkflowPermissions(DepartmentID, RoleID);
        }
        public List<MGOneFacilityDataModel> GetMGOneFacilityList(int DepartmentID, int CollegeID)
        {
            return UnitOfWork.CommonFuncationRepository.GetMGOneFacilityList(DepartmentID, CollegeID);
        }
        public bool SaveMGOneFacility(List<MGOneFacilityDataModel> request)
        {
            return UnitOfWork.CommonFuncationRepository.SaveMGOneFacility(request);
        }        
    }
}
