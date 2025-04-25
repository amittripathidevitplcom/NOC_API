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
        public int BTERCourseID { get; set; }
        public int? CourseStatusId { get; set; }
        public int CourseTypeId { get; set; }
        public int CourseId { get; set; }
        public int? CourseIntakeAsPerAICTELOA { get; set; }
        public int? ShiftID { get; set; }
        public int? Yearofstarting { get; set; }
        public int? BterBranchTypeId { get; set; }
        public int? FirstYearRegularStudent { get; set; }
        public int? FirstYearExStudent { get; set; }
        public int? FirstYearTotal { get; set; }
        public int? SecondYearRegularStudent { get; set; }
        public int? SecondYearExStudent { get; set; }
        public int? SecondYearTotal { get; set; }
        public int? ThirdYearRegularStudent { get; set; }
        public int? ThirdYearExStudent { get; set; }
        public int? ThirdYearTotal { get; set; }
        public string? GovtNOCAvailableforclosure { get; set; }
        public string? NOCNumber { get; set; }
        public string? NOCDate { get; set; }
        public int? NOCClosingYearId { get; set; }
        public string? NOCCUploadDocument { get; set; }
        public string? NOCCUploadDocumentPath { get; set; }
        public string? NOCCUploadDocument_Dis_FileName { get; set; }
        public string? LegalEntityManagementType { get; set; }
        public int DepartmentID { get; set; }
        public int BTERRegID { get; set; }
        public int? RegAffiliationStatusId { get; set; }
        public int UserID { get; set; }
        public string? FinancialYearName { get; set; }
        public List<BTERAffiliationfeesdeposited> BTERAffiliationfeesDetails { get; set; }

    }
    public class BTERAffiliationfeesdeposited
    {
        public int? AffiliationfeeID { get; set; }
        public int? AffiliationRegID { get; set; }
        public int? CollegeStatusId { get; set; }
        public int? AffiliationCourseIDs { get; set; }
        public int? FinancialYearID { get; set; }
        public decimal? FeesAmount { get; set; }
        public string FinancialYearName { get; set; }
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
        public int? BTERRegID { get; set; }
        public int? RegAffiliationStatusId { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifyBy { get; set; }
        public int? UserID { get; set; }

    }
    public class DTEAffiliationAddCoursePreviewDataModel
    {
        public int AffiliationCourseID { get; set; }
        public int DepartmentID { get; set; }
        public int YearofstartingID { get; set; }
        public string? AffiliationCourseType { get; set; }
        public string? CourseIntakeAsPerAICTELOA { get; set; }
        public string? CourseName { get; set; }
        public string? ShiftName { get; set; }
        public string? AffiliationBranchType { get; set; }

    }
    public class DTEAffiliationAddOtherDetailsPreviewDataModel
    {
        public int OtherDetailsID { get; set; }
        public int? NocIssued { get; set; }
        public string? UploadNocApproval { get; set; }
        public string? UploadNocApprovalDocPath { get; set; }
        public string? UploadNocApprovalDoc_Dis_FileName { get; set; }
        public string? StatusNOCIssued { get; set; }
        public string? NocNumber { get; set; }
        public string? NocIssueDate { get; set; }
        public string? UploadLOAApproval { get; set; }
        public string? UploadLOAApprovalDocPath { get; set; }
        public string? UploadLOAApproval_Dis_FileName { get; set; }
        public string? AICTE_EOA_LOA { get; set; }
        public string? AICTEEOALOA { get; set; }
        public string? AICTELAO_No { get; set; }
        public string? EOA_LOA_Date { get; set; }
        public string? UploadApplicationForm { get; set; }
        public string? UploadApplicationFormDocPath { get; set; }
        public string? UploadApplicationFormDoc_Dis_FileName { get; set; }

    }
    public class DTEAffiliationCommonDataModel_DataTable
    {
        public int? BTERCourseID { get; set; }
        public int? AffiliationCourseTypeID { get; set; }
        public int? AffiliationShiftID { get; set; }
        public int? AffiliationBranchID { get; set; }
        public int? CourseID { get; set; }
        public int? DepartmentID { get; set; }
        public int? CourseStatusId { get; set; }
        public string? AffiliationCourseTypeName { get; set; }
        public string? CourseName { get; set; }
        public string? SiftName { get; set; }
        public string? CourseIntakeAsPerAICTELOA { get; set; }
        public string? AffiliationBranchName { get; set; }
        public string? DepartmentName_English { get; set; }
        public string? AffiliationCourseStatus { get; set; }
        public string? AffiliationCategory { get; set; }
    }

    public class BTERCourseAffiliationDataModel
    {
        public DataSet data { get; set; }
    }
    public class BterAffiliationCourseFeeDetails
    {
        public int? BTERCourseID { get; set; }
        public string? BranchType { get; set; }
        public string? CourseFee { get; set; }
        public string? AffiliationFee { get; set; }
        public string? AffiliationApplyFeesOneTime { get; set; }
    }
    public class BTEROtherDetailsDataModel
    {
        public DataTable data { get; set; }
    }
    public class BTERPaymentDataModel
    {
        public string? PaymentID { get; set; }
        public int? ApplyBterAffiliationID { get; set; }
    }
    public class BTERFeeDetailsDataModel
    {
        public DataSet data { get; set; }
    }
    public class NOCRevertOtherDetailsDataModel
    {
        public int OtherDetailsID { get; set; }
        public int? BTERRegID { get; set; }
        public int? DepartmentID { get; set; }
        public int? RegAffiliationStatusId { get; set; }
        public int? UserID { get; set; }
        public int? FYID { get; set; }
        public string? NOCStatus { get; set; }
        public int? NocIssued { get; set; }
        public string? NocNumber { get; set; }
        public string? NocIssueDate { get; set; }
        public string? UploadNocApproval { get; set; }
        public string? UploadNocApprovalDocPath { get; set; }
        public string? UploadNocApprovalDoc_Dis_FileName { get; set; }
    }
    public class EOALOARevertOtherDetailsDataModel
    {
        public int OtherDetailsID { get; set; }
        public int? BTERRegID { get; set; }
        public int? DepartmentID { get; set; }
        public int? RegAffiliationStatusId { get; set; }
        public int? UserID { get; set; }
        public int? FYID { get; set; }
        public string? AICTEStatus { get; set; }
        public int? AICTE_EOA_LOA { get; set; }
        public string? AICTELAO_No { get; set; }
        public string? EOA_LOA_Date { get; set; }
        public string? UploadLOAApproval { get; set; }
        public string? UploadLOAApprovalDocPath { get; set; }
        public string? UploadLOAApproval_Dis_FileName { get; set; }
    }
    public class ApplicationRevertOtherDetailsDataModel
    {
        public int OtherDetailsID { get; set; }
        public int? BTERRegID { get; set; }
        public int? DepartmentID { get; set; }
        public int? RegAffiliationStatusId { get; set; }
        public int? UserID { get; set; }
        public int? FYID { get; set; }
        public string UploadApplicationForm { get; set; }
        public string? UploadApplicationFormDocPath { get; set; }
        public string? UploadApplicationFormDoc_Dis_FileName { get; set; }
    }

    public class Generateorderforbter
    {
        public int? DTEAffiliationID { get; set; }
        public int? SessionID { get; set; }
        public int? UserID { get; set; }
        public int? RoleID { get; set; }
        public string? SessionName { get; set; }
        public List<GenerateorderforbterList> TotalBTERreceivedApplicationList { get; set; }
    }
    public class GenerateorderforbterList
    {
        public int? BterApprovedOrderId { get; set; }
        public int? DTEAffiliationID { get; set; }
        public string? CollegeRegistrationNo { get; set; }
        public string? DistrictName { get; set; }
        public string? CollegeName { get; set; }
        public string? LegalManagementType { get; set; }
        public string? CollegeManagementType { get; set; }
        public string? CollegeEmail { get; set; }
        public string? CollegeStatus { get; set; }
        public string? MappingSSOID { get; set; }
        public string? CollegeCode { get; set; }
        public string? FullAddress { get; set; }
        public string? Branchandintackname { get; set; }
        public string? OrderNumberAndDate { get; set; }
        public string? CourseStatusName { get; set; }
        public int? CourseStatusId { get; set; }
        public string? ApplicationStatusLocation { get; set; }

    }
    public class BTERFeeMasterDataModel
    {
        public int FeeID { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public string FeeType { get; set; }
        public decimal Amount { get; set; }
        public int? UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public string? ActiveDeactive { get; set; }
        public bool DeleteStatus { get; set; }
    }
    public class BTERApplicationOpensessionDataModel
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public int ApplicationSession { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public string? SessionName { get; set; }
        public bool DeleteStatus { get; set; }

    }
    public class BTERPaymentHistoryeMitraDataModel
    {
        public int? DepartmentID { get; set; }
        public string? CollegeCode { get; set; }
        public string? CollegeName { get; set; }
        public int? CollegeID { get; set; }
        public string? MobileNumber { get; set; }
        public string? DistrictName { get; set; }
        public string? FullAddress { get; set; }
        public string? SERVICEID { get; set; }
        public string? TransctionStatus { get; set; }
        public string? Receipt_Number { get; set; }
        public string? TokenNo { get; set; }
        public string? TransctionMSG { get; set; }
        public string? PRNNO { get; set; }
        public string? TransctionDate { get; set; }
        public string? TransctionToDate { get; set; }
        public int? Amount { get; set; }
        public int? ApplyNocApplicationID { get; set; }
    }
    public class BTERPaymentHistoryeMitraDataModel_List
    {
        public DataTable data { get; set; }
    }
}
