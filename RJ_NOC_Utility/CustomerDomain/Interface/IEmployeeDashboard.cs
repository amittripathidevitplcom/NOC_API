using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IEmployeeDashboard
    {
        List<EmployeeDashboardDataModel_DocumentStatusCounts> EmployeeDocumentStatusCounts(int ProjectID, int EmployeeID);
        bool Save_ProjectWiseEmployeeDocuments(int ProjectID, int EmployeeID, int DID, string DocumentName);

    }
}