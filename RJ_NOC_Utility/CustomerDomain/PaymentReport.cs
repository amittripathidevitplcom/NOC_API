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
    public class PaymentReport : UtilityBase, IPaymentReport
    {
        public PaymentReport(IRepositories unitOfWork) : base(unitOfWork)
        {

        }
        public List<CommonDataModel_DataTable> GetPaymentReport(string FromDate, string ToDate, int DepartmentID)
        {
            return UnitOfWork.PaymentReportRepository.GetPaymentReport(FromDate, ToDate, DepartmentID);
        }
    }
}
