using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class PaymentReportRepository : IPaymentReportRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public PaymentReportRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<CommonDataModel_DataTable> GetPaymentReport(string FromDate, string ToDate, int DepartmentID)
        {
            string SqlQuery = " exec USP_PaymentReportData @FromDate ='" + FromDate + "',@ToDate ='" + ToDate + "',@DepartmentID='" + DepartmentID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "PaymentReport.GetPaymentReport");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
