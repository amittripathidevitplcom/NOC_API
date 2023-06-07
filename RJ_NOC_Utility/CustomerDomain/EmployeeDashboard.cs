using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class EmployeeDashboard : UtilityBase, IEmployeeDashboard
    {
        public EmployeeDashboard(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<EmployeeDashboardDataModel_DocumentStatusCounts> EmployeeDocumentStatusCounts(int ProjectID, int EmployeeID)
        {
            return UnitOfWork.EmployeeDashboardRepository.EmployeeDocumentStatusCounts(ProjectID, EmployeeID);
        }

        public bool Save_ProjectWiseEmployeeDocuments(int ProjectID, int EmployeeID, int DID, string DocumentName)
        {
            return UnitOfWork.EmployeeDashboardRepository.Save_ProjectWiseEmployeeDocuments(ProjectID, EmployeeID, DID, DocumentName);
        }
    }
}
