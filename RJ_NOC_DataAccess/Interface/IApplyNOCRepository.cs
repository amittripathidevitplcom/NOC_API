using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IApplyNOCRepository
    {
        List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID,int UserID,int DepartmentID);
        bool DocumentScrutiny(DocumentScrutinySave_DataModel request);
        bool SaveDocumentScrutiny(DocumentScrutinyDataModel request);
        List<DocumentScrutinyDataModel> GetDocumentScrutinyData_TabNameCollegeWise(string TabName, int CollegeID,int RoleID);
        List<ApplyNocParameterDataModel> GetRevertApplyNOCApplicationDepartmentRoleWise(int DepartmentID, int RoleID);

        bool SaveCommiteeInspectionRNCCheckList(List<CommiteeInspection_RNCCheckList_DataModel> request);
        List<CommonDataModel_DataTable> GetApplyNOCRejectedReport(int UserID, string ActionName, int RoleID, int DepartmentID);
        List<CommonDataModel_DataTable> GetForwardCommiteeAHList(int UserID, string ActionName, int RoleID, int DepartmentID);
        List<CommonDataModel_DataTable> GetApplyNOCCompletedReport(int UserID, string ActionName, int RoleID, int DepartmentID);
       List<CommonDataModel_DataTable> GetApplyNOCRevertReport(int UserID, string ActionName, int RoleID, int DepartmentID);
       
        List<CommonDataModel_DataTable> GetPendingMedicalApplications(int RoleID, int UserID, string ActionName);
        List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetApplyNOCApplicationType(int CollegeID);
        List<CommonDataModel_DataTable> GeneratePDFForJointSecretary(int ApplyNOCID);
        List<CommonDataModel_DataTable> GenerateNOCForDCE(int ApplyNOCID);
        bool SavePDFPath(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark);
        int CheckAppliedNOCCollegeWise(int CollegeID);
        List<CommonDataModel_DataTable> GetIssuedNOCReportList(int UserID, string ActionName, int RoleID, int DepartmentID);
        List<CommonDataModel_DataTable> GetNocLateFees(int DepartmentID);
        bool SubmitRevertApplication(SubmitRevertApplication request);
        List<CommonDataModel_DataTable> GetParameterFeeMaster(ParameterFeeMaster request);
        bool SaveDCENOCData(NOCIssuedRequestDataModel model);

        DataSet GetNOCIssuedDetailsByNOCIID(int ApplyNOCID,int ParameterID);
        bool UpdateNOCPDFPath(List<DCENOCPDFPathDataModel> PdfPathList);
        bool DeleteNOCIssuedDetails(int ApplyNOCID);
        NocInformation GetNocInformation(Guid SearchRecordID);
        List<CommonDataModel_DataTable> GetNOCIssuedReportListForAdmin(int UserID, string ActionName, int RoleID);

        List<CommonDataModel_DataTable> GetAppliedParameterNOCForByApplyNOCID(int ApplyNOCID);
    }
}
