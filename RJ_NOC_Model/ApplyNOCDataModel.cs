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
        public string? CollegeMobileNo { get; set; }
        public string? CollegeLogo { get;}
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
        public int? ActionID { get; set; }
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
        public string? UploadDocument { get; set; }
    }

    public class CommiteeInspection_RNCCheckList_DataModel
    {
        public int RNCCheckListID { get; set; }
        public string IsChecked { get; set; }
        public int ApplyNOCID { get; set; }
        public int CreatedBy { get; set; }
        public string? FileUploadName { get; set; }
        public string? Remark { get; set; }
        public string? FinalRemark { get; set; }
        public int RoleID { get; set; }
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
        public string strPVStage { get; set; }
        public string? IsCommittee { get; set; }
        public string? NOCFilePath { get; set; }
        public string? MinisterFile { get; set; }
        public string? MinisterFilePath { get; set; }
        public List<NOCPdfFileDataModel> NOCPdfFileDataModel { get; set; }
        public bool? IsOpenNOCApplication { get; set; }
        public string? L2UploadDocument { get; set; }
        public string? L2UploadDocumentPath { get; set; }
        public string? L1UploadDocument { get; set; }
        public string? L1UploadDocumentPath { get; set; }
        public string? Penalty { get; set; }



        public List<NOCPdfFileDataModel>? DraftNOCPdfFileDataModel { get; set; }
    }

    public class LOIApplicationDetails_DataModel
    {
        public int LOIID { get; set; }
        public string ApplicationNo { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string DepartmentName { get; set; }
        public string CollegeName { get; set; }
        public int PVStage { get; set; }
        public string? NOCFilePath { get; set; }
    }

    public class NOCPdfFileDataModel
    {
        public int ApplyNOCID { get; set; }
        public int ApplyNocParameterID { get; set; }
        public string ApplyNocFor { get; set; }
        public string FileName { get; set; }
        public string NOCFilePath { get; set; }
        public bool IsEsign { get; set; }
        public int EsignBy { get; set; }
    }
    public class GetPhysicalVerificationAppliationList
    {
        public string SSOID { get; set; }
        public int? UserID { get; set; }
        public int? RoleID { get; set; }
        public int? DepartmentID { get; set; }
        public string? Status { get; set; }
    }

    public class GenerateNOC_DataModel
    {
        public int ApplyNOCID { get; set; }
        public int DepartmentID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public int? CourseID { get; set; }
        public string? CourseName { get; set; }
        public int? SubjectID { get; set; }
        public string? SubjectName { get; set; }
        public int? ApplyNocParameterID { get; set; }
        public string? NOCIssuedRemark { get; set; }
        public string? Status { get; set; }
    }
    public class NOCIssuedForDataModel
    {
        public int ApplyNOCID { get; set; }
        public int ParameterID { get; set; }
        public int CreatedBy { get; set; }
        public string Remark { get; set; }
        public int? NoOfIssuedYear { get; set; }
        public string? PdfFilePath { get; set; }
    }

    public class NOCIssuedRequestDataModel
    {
        public List<GenerateNOC_DataModel> NOCDetails { get; set; }
        public List<NOCIssuedForDataModel> AppliedNOCFor { get; set; }
    }
    public class SubmitRevertApplication
    {
        public int ApplyNOCID { get; set; }
        public int DepartmentID { get; set; }
    }

    public class ParameterFeeMaster
    {
        public int ParamterID { get; set; }
        public int DepartmentID { get; set; }
        public int ApplyNocFeeID { get; set; }
        public string OpenFromDate { get; set; }
        public string OpenToDate { get; set; }
        public int FeeAmount { get; set; }
        public string ActionName { get; set; }
        public string TableUpdateType { get; set; }
    }
    public class NocInformation
    {
        public string LegalEntityName { get; set; }
        public string CollegeName { get; set; }
        public string UniversityName { get; set; }
        public string StreamName { get; set; }
        public string SubjectName { get; set; }
    }
    public class DCENOCPDFPathDataModel
    {
        public int AID { get; set; }
        public int ParameterID { get; set; }
        public int ApplyNOCID { get; set; }
        public string PDFPath { get; set; }
    }


    public class ApplicationPenaltyDataModel
    {

        public int PenaltyID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int ApplyNOCID { get; set; }
        public string Penaltyfor { get; set; }
        public decimal PenaltyAmount { get; set; }
        public bool? IsPayment { get; set; }
        public int CreatedBy { get; set; }

    }
}
