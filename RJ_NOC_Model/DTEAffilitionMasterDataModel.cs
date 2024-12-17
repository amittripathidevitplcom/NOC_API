using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEAffiliationRegistrationDataModel
    {
        public int DTE_ARId { get; set; }
        public int? DepartmentID { get; set; }
        public int? CollegeStatusId { get; set; }
        public int? OpenSessionFY { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifyBy { get; set; }
        public int? UserID { get; set; }
        public int? AffiliationTypeID { get; set; }
        public string? College_Name { get; set; }
        public string? Mobile_Number { get; set; }
        public string? Email_Address { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? SSOID { get; set; }
    }
    public class DTEAffiliationCourseDataModel
    {
        public int AffiliationCourseID { get; set; }
        public int? DepartmentID { get; set; }
        public int? AffiliationCourseTypeID { get; set; }
        public string? CourseIntakeAsPerAICTELOA { get; set; }
        public int? CourseID { get; set; }
        public int? AffiliationShiftID { get; set; }
        public int? AffiliationBranchID { get; set; }
        public int? FYID { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifyBy { get; set; }
        public int? UserID { get; set; }

    }
    public class DTEAffiliationOtherDetailsDataModel
    {
        public int OtherDetailsID { get; set; }
        public int? DepartmentID { get; set; }
        public int? NocIssued { get; set; }
        public string? NocNumber { get; set; }
        public string? NocIssueDate { get; set; }
        public string? UploadNocApproval { get; set; }
        public string? UploadNocApprovalDocPath { get; set; }
        public string? UploadNocApprovalDoc_Dis_FileName { get; set; }
        public int? AICTE_EOA_LOA { get; set; }
        public string? AICTELAO_No { get; set; }
        public string? EOA_LOA_Date { get; set; }
        public string? UploadLOAApproval { get; set; }
        public string? UploadLOAApprovalDocPath { get; set; }
        public string? UploadLOAApproval_Dis_FileName { get; set; }
        public string? UploadApplicationForm { get; set; }
        public string? UploadApplicationFormDocPath { get; set; }
        public string? UploadApplicationFormDoc_Dis_FileName { get; set; }
        public int? FYID { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifyBy { get; set; }
        public int? UserID { get; set; }

    }
    public class DTEAffiliationAddCoursePreviewDataModel
    {
       public int AffiliationCourseID { get; set; }
        public int DepartmentID{ get; set; }
       public string? AffiliationCourseType { get; set; }
        public string? CourseIntakeAsPerAICTELOA{ get; set; }
       public string? CourseName{ get; set; }
       public string? ShiftName{ get; set; }
       public string? AffiliationBranchType{ get; set; }

    }
    public class DTEAffiliationAddOtherDetailsPreviewDataModel
    {
        public int OtherDetailsID { get; set; }
        public int? DepartmentID { get; set; }
        public string? UploadNocApproval { get; set; }
        public string? UploadNocApprovalDocPath { get; set; }
        public string? UploadNocApprovalDoc_Dis_FileName { get; set; }
        public string? NocIssued { get; set; }
        public string? NocNumber { get; set; }
        public string? NocIssueDate { get; set; }
        public string? UploadLOAApproval { get; set; }
        public string? UploadLOAApprovalDocPath { get; set; }
        public string? UploadLOAApproval_Dis_FileName { get; set; }
        public string? AICTE_EOA_LOA { get; set; }
        public string? AICTELAO_No { get; set; }
        public string? EOA_LOA_Date { get; set; }
        public string? UploadApplicationForm { get; set; }
        public string? UploadApplicationFormDocPath { get; set; }
        public string? UploadApplicationFormDoc_Dis_FileName { get; set; }

    }

}
