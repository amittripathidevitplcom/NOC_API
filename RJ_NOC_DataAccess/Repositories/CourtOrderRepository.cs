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
    public class CourtOrderRepository: ICourtOrderRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CourtOrderRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetCourtOrderData(CourtOrderSearchFilterDataModel request)
        {
            string SqlQuery = " exec [USP_GetCourtOrderData] @CourtOrderID='" + request.CourtOrderID + "',@DepartmentID='" + request.DepartmentID + "',@CollegeID='" + request.CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CourtOrder.GetCourtOrderData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool SaveData(CourtOrderModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@CourtOrderID='{0}',", request.CourtOrderID);
            sb.AppendFormat("@DepartmentID='{0}',", request.DepartmentID);
            sb.AppendFormat("@CollegeID='{0}',", request.CollegeID);
            sb.AppendFormat("@OrderName='{0}',", request.OrderName);
            sb.AppendFormat("@OrderDate='{0}',", request.OrderDate);
            sb.AppendFormat("@OrderDocumentName='{0}',", request.OrderDocumentName);
            sb.AppendFormat("@UserID='{0}',", request.UserID);
            sb.AppendFormat("@IPAddress='{0}'", IPAddress);

            string SqlQuery = $" exec USP_Trn_CourtOrder_IU  {sb.ToString()}";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "CourtOrder.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int CourtOrderID)
        {
            string SqlQuery = "Exec [USP_DeleteCourtOrder] @CourtOrderID='" + CourtOrderID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CourtOrder.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
