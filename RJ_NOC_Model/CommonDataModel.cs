using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace RJ_NOC_Model
{
    public class CommonDataModel_DataTable
    {
        public DataTable data { get; set; }
    }
    public class CommonDataModel_DataSet
    {
        public DataSet data { get; set; }
    }

    public class CommonDataModel_DocumentMasterList
    {
        public int DID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public bool Status { get; set; }
        public bool ForEmployeeCode { get; set; }
    }
    public class CommonDataModel_TabHistory
    {
        public int ID { get; set; }
        public int? CollegeID { get; set; }
        public string Type { get; set; }
        public string? DocumentName { get; set; }
    }
   

    public class CommonDataModel_EmployeeDocumentList
    {
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }
        public int DID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFileName { get; set; }
        public string Status { get; set; }
        public string ActionRemarks { get; set; }

    }



    public class CommonDataModel_DepartmentMasterList
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
    public class CommonDataModel_SchemeListByDepartment
    {
        public int SchemeID { get; set; }
        public int DepatmentID { get; set; }
        public string SchemeName { get; set; }
    }
    public class CommonDataModel_CollegeID_SearchRecordIDWise
    {
        public int CollegeID { get; set; }
    }

    public class CommonDataModel_ModuleMasterList
    {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
    }

    public class CommonDataModel_SubModuleListByModule
    {

        public int SubModuleID { get; set; }
        public int ModuleID { get; set; }
        public string SubModuleName { get; set; }
    }

    public class CommonDataModel_LevelMasterList
    {
        public int LevelID { get; set; }
        public string LevelName { get; set; }
    }
    public class CommonDataModel_CommitteeList
    {
        public int CommitteeID { get; set; }
        public string CommitteeName { get; set; }
    }
    public class CommonDataModel_RoleListByLevel
    {

        public int RoleID { get; set; }
        public int LevelID { get; set; }
        public string RoleName { get; set; }
    }

    public class CommonDataModel_ActionHeadList
    {
        public int ActionHeadID { get; set; }
        public string ActionHeadName { get; set; }
    }

    public class CommonDataModel_ActionListByActionHead
    {
        public int ActionID { get; set; }
        public int ActionHeadID { get; set; }
        public string ActionName { get; set; }
    }


    public class CommonDataModel_DepartmentMaster
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
    public class CommonDataModel_DepartmentAndLoginSSOIDWiseCollageMaster
    {
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public string CollegeName { get; set; }
        public string CourseCategoryName { get; set; }
        public int CourseCategoryId { get; set; }
    }


    public class CommonDataModel_CourseMaster
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseLevelID { get; set; }

    }
    public class CommonDataModel_SubjectMaster
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }

    public class CommonDataModel_SeatInformationMaster
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }

    public class CommonDataModel_CommonMasterDepartmentAndTypeWise
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }

    public class CommonDataModel_DocumentMasterDepartmentAndTypeWise
    {
        public int DID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public bool IsMandatory { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string SampleDocument { get; set; }
        public string DisplayName { get; set; }
    }
    public class CommonDataModel_LandAreaMasterList_DepartmentWise
    {
        public int LandAreaID { get; set; }
        public string LandAreaName { get; set; }
    }
    public class CommonDataModel_LandTypeMasterList_DepartmentWise
    {
        public int LandTypeID { get; set; }
        public string LandTypeName { get; set; }
    }
    public class CommonDataModel_LandDocumentTypeMasterList_DepartmentWise
    {
        public int LandDocumentTypeID { get; set; }
        public string LandDocumentTypeName { get; set; }
    }

    public class CommonDataModel_DistrictList
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
    }

    public class CommonDataModel_StateList
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
    public class CommonDataModel_DivisionDDL
    {
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
    }
    public class CommonDataModel_UniversityDDL
    {
        public int UniversityID { get; set; }
        public string UniversityName { get; set; }
    }
    public class CommonDataModel_SuvdivisionDDL
    {
        public int SuvdivisionID { get; set; }
        public string SubdivisionName { get; set; }
    }
    public class CommonDataModel_TehsilDDL
    {
        public int TehsilID { get; set; }
        public string TehsilName { get; set; }
    }
    public class CommonDataModel_PanchyatSamitiDDL
    {
        public int PanchyatSamitiID { get; set; }
        public string PanchyatSamitiName { get; set; }
    }
    public class CommonDataModel_ParliamentAreaDDL
    {
        public int ParliamentAreaID { get; set; }
        public string ParliamentAreaName { get; set; }
    }
    public class CommonDataModel_AssemblyAreaDDL
    {
        public int AssemblyAreaID { get; set; }
        public string AssemblyAreaName { get; set; }
    }
    public class CommonDataModel_FinancialYearDDL
    {
        public int FinancialYearID { get; set; }
        public string FinancialYearName { get; set; }
    }


    public class CommonDataModel_CollegeWiseCourseList
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string? CourseOldNew { get; set; }
    }


    public class CommonDataModel_CourseRoomSize
    {
        public int NoOfRooms { get; set; }
        public int NoofPredicalRooms { get; set; }
        public int WidthMin { get; set; }
        public int LengthMin { get; set; }
    }


    public class CommonDataModel_OtherInformationList_DepartmentAndTypeWise
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }


    public class CommonDataModel_OtherInformationSize
    {
        public int WidthMin { get; set; }
        public int LengthMin { get; set; }
        public int NoOfRooms { get; set; }
        public string AnnexurePath { get; set; }
        public string AnnexurePath2 { get; set; }

    }
    public class CommonDataModel_DesignationDDL
    {
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
    }
    public class CommonDataModel_TabField
    {
        public int TabFieldID { get; set; }
        public string TabName { get; set; }
        public string TabFieldName { get; set; }
    }

    public class CommonDataModel_GetConnectionString
    {
        public string ConnectionString1 { get; set; }
        public string ConnectionString2 { get; set; }
        public string ConnectionString3 { get; set; }
    }

    public class CommonDataModel_WorkFlowActionsByRole
    {

        public int RoleID { get; set; }
        public int NextRoleID { get; set; }
        public string RoleName { get; set; }
        public string ActionName { get; set; }
        public int ActionID { get; set; }
        public bool IsNextAction { get; set; }
        public bool IsRevert { get; set; }
    }

    public class CommonDataModel_RNCCheckListData
    {

        public int RNCCheckListID { get; set; }
        public int DepartmentID { get; set; }
        public string RNCCheckListName { get; set; }
        public bool FileUpload { get; set; }

        public string? IsChecked { get; set; }
        public string? Remark { get; set; }
        public string? FinalRemark { get; set; }
        public string? CheckFinalRemark { get; set; }
        public string? FileUploadName_Dis_FileName { get; set; }
        public string? FileUploadNamePath { get; set; }
        public string? FileUploadName { get; set; }
        public int IsCheckList { get; set; }
    }

    public class CommonDataModel_ApplicationTrail
    {
        public int NOCWorkFlowID { get; set; }
        public int DepartmentID { get; set; }
        public int ActionID { get; set; }
        public string Remark { get; set; }
        public string ActionDate { get; set; }
        public string ActionName { get; set; }
        public string ActionUser { get; set; }
        public string RoleName { get; set; }
        public string ActionUserSSOID { get; set; }
        public string NextRoleName { get; set; }
        public string NextUserName { get; set; }
    }

    public class CommonDataModel_AadharDataModel
    {
        public string AadharNo { get; set; }
        public string TransactionNo { get; set; }
        public string OTP { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string AadharID { get; set; }

    }

    public class CommonDataModel_LandSqureMeterMappingDetails_DepartmentWise
    {
        public int LandAreaID { get; set; }
        public string LandAreaName { get; set; }
        public int FinancialYearID { get; set; }
        public string FinancialYearName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string RequiredSquareMeter { get; set; }
        public string AreaType { get; set; }
    }
    public class CommonDataModel_CollegeDraftFinal
    {
        public int CollegeID { get; set; }
        public int IsDraftSubmited { get; set; }
        public string? Deficiency { get; set; }

    }
    public class CommonDataModel_NOCFormatMaster
    {
        public int NOCFormatID { get; set; }
        public int DepartmentID { get; set; }
        public int ParameterID { get; set; }
        public string NOCFormat { get; set; }

    }

    public class CommonDataModel_Category
    {
        public int CategoryId { get; set; }       
        public string CategoryName { get; set; }

    }
}
