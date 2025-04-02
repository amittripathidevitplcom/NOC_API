using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ApplyNOC : UtilityBase, IApplyNOC
    {
        public ApplyNOC(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID, int UserID, int DepartmentID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCApplicationListByRole(RoleID, UserID, DepartmentID);
        }
        public bool DocumentScrutiny(DocumentScrutinySave_DataModel request)
        {
            return UnitOfWork.ApplyNOCRepository.DocumentScrutiny(request);
        }
        public bool SaveDocumentScrutiny(DocumentScrutinyDataModel request)
        {
            return UnitOfWork.ApplyNOCRepository.SaveDocumentScrutiny(request);
        }
        public bool SaveApplicationPenalty(ApplicationPenaltyDataModel request)
        {
            return UnitOfWork.ApplyNOCRepository.SaveApplicationPenalty(request);
        }
        public List<DocumentScrutinyDataModel> GetDocumentScrutinyData_TabNameCollegeWise(string TabName, int CollegeID, int RoleID)
        {
            return UnitOfWork.ApplyNOCRepository.GetDocumentScrutinyData_TabNameCollegeWise(TabName, CollegeID, RoleID);
        }
        public List<ApplyNocParameterDataModel> GetRevertApplyNOCApplicationDepartmentRoleWise(int DepartmentID, int RoleID)
        {
            return UnitOfWork.ApplyNOCRepository.GetRevertApplyNOCApplicationDepartmentRoleWise(DepartmentID, RoleID);
        }
        public bool SaveCommiteeInspectionRNCCheckList(List<CommiteeInspection_RNCCheckList_DataModel> request)
        {
            return UnitOfWork.ApplyNOCRepository.SaveCommiteeInspectionRNCCheckList(request);
        }
        public List<CommonDataModel_DataTable> GetApplyNOCRejectedReport(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCRejectedReport(UserID, ActionName, RoleID, DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetForwardCommiteeAHList(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            return UnitOfWork.ApplyNOCRepository.GetForwardCommiteeAHList(UserID, ActionName, RoleID, DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetApplyNOCCompletedReport(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCCompletedReport(UserID, ActionName, RoleID, DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetApplyNOCRevertReport(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCRevertReport(UserID, ActionName, RoleID, DepartmentID);
        }
        public List<CommonDataModel_DataTable> GetPendingMedicalApplications(int RoleID, int UserID, string ActionName)
        {
            return UnitOfWork.ApplyNOCRepository.GetPendingMedicalApplications(RoleID, UserID, ActionName);
        }
        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetApplyNOCApplicationType(int CollegeID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCApplicationType(CollegeID);
        }
        public List<CommonDataModel_DataTable> GeneratePDFForJointSecretary(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.GeneratePDFForJointSecretary(ApplyNOCID);
        }
        public List<CommonDataModel_DataTable> GenerateNOCForDCE(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.GenerateNOCForDCE(ApplyNOCID);
        }
        public bool SavePDFPath(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark)
        {
            return UnitOfWork.ApplyNOCRepository.SavePDFPath(Path, ApplyNOCID, DepartmentID, RoleID, UserID, NOCIssuedRemark);
        }
        public int CheckAppliedNOCCollegeWise(int CollegeID)
        {
            return UnitOfWork.ApplyNOCRepository.CheckAppliedNOCCollegeWise(CollegeID);
        }
        public List<CommonDataModel_DataTable> GetIssuedNOCReportList(int UserID, string ActionName, int RoleID, int DepartmentID)
        {
            return UnitOfWork.ApplyNOCRepository.GetIssuedNOCReportList(UserID, ActionName, RoleID, DepartmentID);
        }

        public List<CommonDataModel_DataTable> GetNocLateFees(int DepartmentID)
        {
            return UnitOfWork.ApplyNOCRepository.GetNocLateFees(DepartmentID);
        }
        public List<CommonDataModel_DataTable> DefaulterCollegePenalty(int CollegeID, string Other1, string Other2)
        {
            return UnitOfWork.ApplyNOCRepository.DefaulterCollegePenalty(CollegeID, Other1, Other2);
        }
        public bool SubmitRevertApplication(SubmitRevertApplication request)
        {
            return UnitOfWork.ApplyNOCRepository.SubmitRevertApplication(request);
        }
        public List<CommonDataModel_DataTable> GetParameterFeeMaster(ParameterFeeMaster request)
        {
            return UnitOfWork.ApplyNOCRepository.GetParameterFeeMaster(request);
        }
        public bool SaveDCENOCData(NOCIssuedRequestDataModel model)
        {
            return UnitOfWork.ApplyNOCRepository.SaveDCENOCData(model);
        }
       
        public bool GenerateEssentialityMgone(NOCIssuedForMGOneDataModel model)
        {
            return UnitOfWork.ApplyNOCRepository.GenerateEssentialityMgone(model);
        }
        public bool UpdateNOCPDFPath(List<DCENOCPDFPathDataModel> PdfPathList)
        {
            return UnitOfWork.ApplyNOCRepository.UpdateNOCPDFPath(PdfPathList);
        }
     
        public bool UpdateMgonePDFPath(NOCIssuedForMGOneDataModel PdfPathList)
        {
            return UnitOfWork.ApplyNOCRepository.UpdateMgonePDFPath(PdfPathList);
        }
        public bool DeleteNOCIssuedDetails(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.DeleteNOCIssuedDetails(ApplyNOCID);
        }
      
        public bool DeleteMgoneIssuedDetails(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.DeleteMgoneIssuedDetails(ApplyNOCID);
        }
        public DataSet GetNOCIssuedDetailsByNOCIID(int ApplyNOCID, int ParameterID)
        {
            return UnitOfWork.ApplyNOCRepository.GetNOCIssuedDetailsByNOCIID(ApplyNOCID, ParameterID);
        }
        public NocInformation GetNocInformation(Guid SearchRecordID)
        {
            return UnitOfWork.ApplyNOCRepository.GetNocInformation(SearchRecordID);
        }
        public List<CommonDataModel_DataTable> GetNOCIssuedReportListForAdmin(int UserID, string ActionName, int RoleID)
        {
            return UnitOfWork.ApplyNOCRepository.GetNOCIssuedReportListForAdmin(UserID, ActionName, RoleID);
        }
        public List<CommonDataModel_DataTable> GetAppliedParameterNOCForByApplyNOCID(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.GetAppliedParameterNOCForByApplyNOCID(ApplyNOCID);
        }
        
        public List<CommonDataModel_DataTable> GetAppliedParameterEssentialityForByApplyNOCID(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.GetAppliedParameterEssentialityForByApplyNOCID(ApplyNOCID);
        }
        
       
        public bool SaveDocumentScrutinyLOI(DocumentScrutinyDataModel request)
        {
            return UnitOfWork.ApplyNOCRepository.SaveDocumentScrutinyLOI(request);
        }
        public int CountTotalRevertDCE(int ApplyNOCID, int RoleID, int UserID)
        {
            return UnitOfWork.ApplyNOCRepository.CountTotalRevertDCE(ApplyNOCID, RoleID, UserID);
        }
        public List<CommonDataModel_DataTable> GetApplicationPenalty(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplicationPenalty(ApplyNOCID);
        }
        public List<CommonDataModel_DataTable> GetApplicationPenaltyList(string SSOID, int SessionYear)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplicationPenaltyList(SSOID, SessionYear);
        }

        public DataSet GetDraftNOCDetailsByNOCIID(int ApplyNOCID, string ParameterID, int NoOfIssuedYear, string CourseIDs, string SubjectIDs)
        {
            return UnitOfWork.ApplyNOCRepository.GetDraftNOCDetailsByNOCIID(ApplyNOCID, ParameterID, NoOfIssuedYear, CourseIDs, SubjectIDs);
        }
        public DataSet GetEssentialityDraftNOCDetailsByNOCIID(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.GetEssentialityDraftNOCDetailsByNOCIID(ApplyNOCID);
        }
        
        public bool SaveDCEDraftNOCData(NOCIssuedRequestDataModel model)
        {
            return UnitOfWork.ApplyNOCRepository.SaveDCEDraftNOCData(model);
        }
        public bool ForwardToEsignDCE(int ApplyNOCID, int UserId)
        {
            return UnitOfWork.ApplyNOCRepository.ForwardToEsignDCE(ApplyNOCID,UserId);
        }        
        public bool SaveAHDegreeNOCData(NOCIssuedForAHDegreeDataModel model)
        {
            return UnitOfWork.ApplyNOCRepository.SaveAHDegreeNOCData(model);
        }       
        public DataSet GetAHDegreeNOCDetailsNOCIID(int ApplyNOCID, int ParameterID)
        {
            return UnitOfWork.ApplyNOCRepository.GetAHDegreeNOCDetailsNOCIID(ApplyNOCID,ParameterID);
        }    
        public bool UpdateAHNOCPDFPath(string PDFPath, int ApplyNOCID, int ParameterID)
        {
            return UnitOfWork.ApplyNOCRepository.UpdateAHNOCPDFPath(PDFPath,ApplyNOCID, ParameterID);
        }
        public bool SaveBTERDocumentScrutiny(BTERDocumentScrutinyDataModel request)
        {
            return UnitOfWork.ApplyNOCRepository.SaveBTERDocumentScrutiny(request);
        }
        public List<CommonDataModel_DataTable> GetAppliedParameterEssentialityForAffiliationorder()
        {
            return UnitOfWork.ApplyNOCRepository.GetAppliedParameterEssentialityForAffiliationorder();
        }
        
    }
}
