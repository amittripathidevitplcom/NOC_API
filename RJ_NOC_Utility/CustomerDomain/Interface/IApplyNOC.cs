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
        List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID);
        bool DocumentScrutiny(int ApplyNOCID, int RoleID, int UserID, string ActionType,int DepartmentID);
        bool SaveDocumentScrutiny(DocumentScrutinyDataModel request);
        List<DocumentScrutinyDataModel> GetDocumentScrutinyData_TabNameCollegeWise(string TabName, int CollegeID);
    }
}
