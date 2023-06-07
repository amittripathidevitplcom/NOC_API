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

    public class CommonDataModel_DocumentMasterList
    {
        public int DID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public bool Status { get; set; }
        public bool ForEmployeeCode { get; set; }
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
        public string CollegeName { get; set; }
    }


    public class CommonDataModel_CourseMaster
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
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
    public class CommonDataModel_AssembelyAreaDDL
    {
        public int AssembelyAreaID { get; set; }
        public string AssembelyAreaName { get; set; }
    }
    public class CommonDataModel_FinancialYearDDL
    {
        public int FinancialYearID { get; set; }
        public string FinancialYearName { get; set; }
    }
}
