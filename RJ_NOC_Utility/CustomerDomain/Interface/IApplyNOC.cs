using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IApplyNOC
    {
        List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID,int UserID);
        bool DocumentScrutiny(DocumentScrutinySave_DataModel request);
        bool SaveDocumentScrutiny(DocumentScrutinyDataModel request);
        List<DocumentScrutinyDataModel> GetDocumentScrutinyData_TabNameCollegeWise(string TabName, int CollegeID, int RoleID);
        List<ApplyNocParameterDataModel> GetRevertApplyNOCApplicationDepartmentRoleWise(int DepartmentID, int RoleID);
        bool SaveCommiteeInspectionRNCCheckList(List<CommiteeInspection_RNCCheckList_DataModel> request);
        List<CommonDataModel_DataTable> GetApplyNOCRejectedReport(int UserID, string ActionName);
        List<CommonDataModel_DataTable> GetApplyNOCCompletedReport(int UserID, string ActionName);
        List<CommonDataModel_DataTable> GetPendingMedicalApplications(int RoleID, int UserID, string ActionName);
        List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetApplyNOCApplicationType(int CollegeID);
        List<CommonDataModel_DataTable> GeneratePDFForJointSecretary(int ApplyNOCID);
        bool SavePDFPath(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID,string NOCIssuedRemark);
    }
}
