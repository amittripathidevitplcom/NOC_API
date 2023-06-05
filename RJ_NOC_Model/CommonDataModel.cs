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
}
