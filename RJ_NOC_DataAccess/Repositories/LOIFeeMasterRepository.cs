using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class LOIFeeMasterRepository : ILOIFeeMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public LOIFeeMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAllLOIFeeList()
        {
            string SqlQuery = " exec USP_GetLOIFeeMasterData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LOIFeeMaster.GetAllLOIFeeList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<LOIFeeMasterDataModel> GetLOIFeeByID(int FeeID)
        {
            string SqlQuery = " exec USP_GetLOIFeeMasterData @FeeID='" + FeeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LOIFeeMaster.GetLOIFeeByID");

            List<LOIFeeMasterDataModel> dataModels = new List<LOIFeeMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<LOIFeeMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(LOIFeeMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec LOIFeeMaster_AddUpdate";
            SqlQuery += " @FeeID='" + request.FeeID + "',@DepartmentID='" + request.DepartmentID + "',@FeeType='" + request.FeeType + "',@Amount='" + request.Amount + "', @ActiveStatus='" + request.ActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "LOIFeeMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int FeeID)
        {
            string SqlQuery = " Update M_LOIFeeMaster set ActiveStatus=0 , DeleteStatus=1  WHERE FeeID='" + FeeID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "LOIFeeMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int FeeID, int DepartmentID, string FeeType)
        {
            string SqlQuery = " select FeeType from M_LOIFeeMaster Where DepartmentID = '"+ DepartmentID + "' and FeeType='" + FeeType.Trim() + "'  and FeeID !='" + FeeID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LOIFeeMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
