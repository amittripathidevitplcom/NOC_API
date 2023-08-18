using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class ApplyNOCDataModel
    {
        public int ApplyNOCID { get; set; }
        public string ApplicationNo { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string DepartmentName { get; set; }
        public string CollegeName { get; set; }
    }
    public class DocumentScrutinyDataModel
    {

        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public int ApplyNOCID { get; set; }
        public string TabName { get; set; }
        public string FinalRemark { get; set; }
        public List<DocumentScrutinyList_DataModel> DocumentScrutinyDetail { get; set; }

    }
    public class DocumentScrutinyList_DataModel
    {
        public int DocumentScrutinyID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public int ApplyNOCID { get; set; }
        public string Action { get; set; }
        public string? Remark { get; set; }
        public int TabRowID { get; set; }
        public string? SubTabName { get; set; }
    }

    public class DocumentScrutinySave_DataModel
    {
        public int ApplyNOCID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public int ActionID { get; set; }
        public int DepartmentID { get; set; }
        public string? Remark { get; set; }
        public int NextRoleID { get; set; }
        public int NextUserID { get; set; }
        public int NextActionID { get; set; }
    }

    public class CommiteeInspection_RNCCheckList_DataModel
    {
        public int RNCCheckListID { get; set; }
        public int ApplyNOCID { get; set; }
        public int CreatedBy { get; set; }
        public string? FileUploadName { get; set; }

    }

    public class ApplyNocApplicationDetails_DataModel
    {
        public int ApplyNOCID { get; set; }
        public string ApplicationNo { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string DepartmentName { get; set; }
        public string CollegeName { get; set; }
        public int PVStage { get; set; }
        public int strPVStage { get; set; }
    }
}
