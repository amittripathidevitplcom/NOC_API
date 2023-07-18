using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IApplyNOCRepository
    {
        List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID,int UserID);
        bool DocumentScrutiny(DocumentScrutinySave_DataModel request);
        bool SaveDocumentScrutiny(DocumentScrutinyDataModel request);
        List<DocumentScrutinyDataModel> GetDocumentScrutinyData_TabNameCollegeWise(string TabName, int CollegeID,int RoleID);
        List<ApplyNocParameterDataModel> GetRevertApplyNOCApplicationDepartmentRoleWise(int DepartmentID, int RoleID);

        bool SaveCommiteeInspectionRNCCheckList(List<CommiteeInspection_RNCCheckList_DataModel> request);
    }
}
