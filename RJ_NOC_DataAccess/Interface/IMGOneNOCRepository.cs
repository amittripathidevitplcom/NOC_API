using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IMGOneNOCRepository
    {
        public List<CommonDataModel_DataTable> GetNOCApplicationList(int RoleID, int UserID, string Status);

        public bool SaveNOCWorkFlow(DocumentScrutinySave_DataModel_MGOne request);
        public bool SaveNOCWorkFlowDock(DocumentSave_DataModel_MGOne request);
        public List<CommonDataModel_DataTable> GetNOCWorkFlowDock(int ApplyNOCID);
        public bool SaveInspectionReport(InspectionReport_DataModel_MGOne request);
        public bool GenerateOrderForInspectionReport(InspectionReport_DataModel_MGOne request);
        public List<CommonDataModel_DataTable> GetGeneratePDFData(int ApplyNocID, int DepartmentID, int CollegeID, string Action);
        public bool FinalSavePDFPathandNOC(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark, string Action, int ActionID = 0, int NextRoleID = 0, int NextUserID = 0);
        public bool SaveNOCIssueData(int ApplyNocID, int DepartmentID, int CollegeID, string Action);
    }
}
