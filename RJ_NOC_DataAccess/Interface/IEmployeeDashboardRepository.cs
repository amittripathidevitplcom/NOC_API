using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IEmployeeDashboardRepository
    {
        List<EmployeeDashboardDataModel_DocumentStatusCounts> EmployeeDocumentStatusCounts(int ProjectID, int EmployeeID);

        bool Save_ProjectWiseEmployeeDocuments(int ProjectID, int EmployeeID, int DID, string DocumentName);

    }

}

