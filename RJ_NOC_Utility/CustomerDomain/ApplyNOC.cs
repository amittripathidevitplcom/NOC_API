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

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ApplyNOC : UtilityBase, IApplyNOC
    {
        public ApplyNOC(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID, int UserID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCApplicationListByRole(RoleID, UserID);
        }
        public bool DocumentScrutiny(DocumentScrutinySave_DataModel request)
        {
            return UnitOfWork.ApplyNOCRepository.DocumentScrutiny(request);
        }
        public bool SaveDocumentScrutiny(DocumentScrutinyDataModel request)
        {
            return UnitOfWork.ApplyNOCRepository.SaveDocumentScrutiny(request);
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
        public List<CommonDataModel_DataTable> GetApplyNOCRejectedReport(int UserID, string ActionName)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCRejectedReport(UserID,ActionName);
        }
        public List<CommonDataModel_DataTable> GetApplyNOCCompletedReport(int UserID, string ActionName)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCCompletedReport(UserID,ActionName);
        }
        public List<CommonDataModel_DataTable> GetPendingMedicalApplications(int RoleID, int UserID, string ActionName)
        {
            return UnitOfWork.ApplyNOCRepository.GetPendingMedicalApplications(RoleID, UserID,ActionName);
        }
        public List<CommonDataModel_CommonMasterDepartmentAndTypeWise> GetApplyNOCApplicationType(int CollegeID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCApplicationType(CollegeID);
        }
        public List<CommonDataModel_DataTable> GeneratePDFForJointSecretary(int ApplyNOCID)
        {
            return UnitOfWork.ApplyNOCRepository.GeneratePDFForJointSecretary(ApplyNOCID);
        }
        public bool SavePDFPath(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark)
        {
            return UnitOfWork.ApplyNOCRepository.SavePDFPath(Path, ApplyNOCID, DepartmentID, RoleID, UserID, NOCIssuedRemark);
        }
    }
}
