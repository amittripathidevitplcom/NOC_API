using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IPaymentReportRepository
    {
        List<CommonDataModel_DataTable> GetPaymentReport(string FromDate, string ToDate, int DepartmentID);
    }
}
