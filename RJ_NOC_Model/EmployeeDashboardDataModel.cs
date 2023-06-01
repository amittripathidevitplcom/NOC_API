using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class EmployeeDashboardDataModel_DocumentStatusCounts
    {
        public int TotalRequiredDocuments { get; set; }
        public int TotalPendingDocuments { get; set; }
        public int TotalSubmitDocuments { get; set; }
    }

}
