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

        public List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID)
        {
            return UnitOfWork.ApplyNOCRepository.GetApplyNOCApplicationListByRole(RoleID);
        }
        public bool DocumentScrutiny(int ApplyNOCID, int RoleID, int UserID, string ActionType, int DepartmentID)
        {
            return UnitOfWork.ApplyNOCRepository.DocumentScrutiny(ApplyNOCID, RoleID, UserID, ActionType, DepartmentID);
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
    }
}
