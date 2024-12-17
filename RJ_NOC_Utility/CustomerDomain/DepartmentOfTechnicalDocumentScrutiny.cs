using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DepartmentOfTechnicalDocumentScrutiny : UtilityBase, IDepartmentOfTechnicalDocumentScrutiny
    {
        public DepartmentOfTechnicalDocumentScrutiny(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument(DepartmentID,CollageID, RoleID, ApplyNOCID,Type, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_HostelDetail(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }     
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCourseDetail> DocumentScrutiny_CourseDetails(int CollageID, int RoleID, int ApplyNOCID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_CourseDetails(CollageID, RoleID, ApplyNOCID, VerificationStep);
        }
        public List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID, string VerificationStep)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.CheckDocumentScrutinyTabsData( ApplyNOCID, RoleID, CollegeID, VerificationStep);
        }
        public List<DataTable> GetApplyNOCApplicationList(int RoleID, int UserID, string Status, string ActionName, int SessionYear = 0)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.GetApplyNOCApplicationList(  RoleID, UserID,Status,ActionName, SessionYear);
        }
        public bool WorkflowInsertDTE(DocumentScrutinySave_DataModel request)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.WorkflowInsertDTE(request);
        }
        public bool SavePDFPath(string Path, int ApplyNOCID, int UserID, string Remark, int IsIssuedNOC)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.SavePDFPath(Path, ApplyNOCID, UserID, Remark, IsIssuedNOC);
        }
        public DataSet GeneratePDF_DTENOCData(GenerateDTENOCPDFDataModel request)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.GeneratePDF_DTENOCData(request);
        }        
        public bool PdfEsign(int ApplyNOCID, int CreatedBy)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.PdfEsign(ApplyNOCID, CreatedBy);
        }
        public DataSet GenerateReceipt(GenerateDocument_DTE request)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.GenerateReceipt(request);
        }
        public bool SaveGenerateReceiptPDFPath(GenerateDocument_DTE request)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.SaveGenerateReceiptPDFPath(request);
        }
        public bool ReceiptPdfEsign(int ApplyNOCID, int CreatedBy)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.ReceiptPdfEsign(ApplyNOCID, CreatedBy);
        }     
        public DataSet GetConsolidatedReportData(GenerateDocument_DTE request)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.GetConsolidatedReportData(request);
        }
        public bool SaveConsolidatedReportPDFPath(GenerateDocument_DTE request)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.SaveConsolidatedReportPDFPath(request);
        }
        public List<DataTable> GetConsolidatedReportByApplyNOCID(int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.GetConsolidatedReportByApplyNOCID(ApplyNOCID);
        }
        public bool UploadConsolidatedReport(GenerateDocument_DTE request)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.UploadConsolidatedReport(request);
        }
        public bool UploadInspectionReport(GenerateDocument_DTE request)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.UploadInspectionReport(request);
        }   
        public DataSet GenerateDTEActionSummaryPDF(int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.GenerateDTEActionSummaryPDF(ApplyNOCID);
        }
    }
}
