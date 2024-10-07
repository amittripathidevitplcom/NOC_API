using Azure.Core;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class MGOneNOC : UtilityBase, IMGOneNOC
    {
        public MGOneNOC(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetNOCApplicationList(int RoleID, int UserID, string Status)
        {
            return UnitOfWork.MGOneNOCRepository.GetNOCApplicationList(RoleID, UserID, Status);
        }
        public bool SaveNOCWorkFlow(DocumentScrutinySave_DataModel_MGOne request)
        {
            return UnitOfWork.MGOneNOCRepository.SaveNOCWorkFlow(request);
        }
        public bool SaveNOCWorkFlowDock(DocumentSave_DataModel_MGOne request)
        {
            return UnitOfWork.MGOneNOCRepository.SaveNOCWorkFlowDock(request);
        }
        public List<CommonDataModel_DataTable> GetNOCWorkFlowDock(int ApplyNOCID)
        {
            return UnitOfWork.MGOneNOCRepository.GetNOCWorkFlowDock(ApplyNOCID);
        }
        public bool SaveInspectionReport(InspectionReport_DataModel_MGOne request)
        {
            return UnitOfWork.MGOneNOCRepository.SaveInspectionReport(request);
        }
        public bool GenerateOrderForInspectionReport(InspectionReport_DataModel_MGOne request)
        {
            return UnitOfWork.MGOneNOCRepository.GenerateOrderForInspectionReport(request);
        }
        public List<CommonDataModel_DataTable> GetGeneratePDFData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            return UnitOfWork.MGOneNOCRepository.GetGeneratePDFData(ApplyNocID,DepartmentID, CollegeID,Action);
        }
        public bool FinalSavePDFPathandNOC(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark, string Action, int ActionID = 0, int NextRoleID = 0, int NextUserID = 0)
        {
            return UnitOfWork.MGOneNOCRepository.FinalSavePDFPathandNOC(Path, ApplyNOCID, DepartmentID, RoleID, UserID, NOCIssuedRemark, Action, ActionID, NextRoleID,NextUserID);
        }
        public bool SaveNOCIssueData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            return UnitOfWork.MGOneNOCRepository.SaveNOCIssueData(ApplyNocID, DepartmentID, CollegeID, Action);
        }
    }
}

