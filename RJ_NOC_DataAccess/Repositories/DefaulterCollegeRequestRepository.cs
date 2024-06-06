using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class RNCCheckListMasterRepository : IRNCCheckListMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public RNCCheckListMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        
        public List<CommonDataModel_DataTable> GetRNCCheckListData()
        {
            string SqlQuery = " exec USP_GetRNCCheckListMasterData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "RNCCheckListMaster.GetRNCCheckListData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<RNCCheckListMasterDataModel> GetByID(int RNCCheckListID)
        {
            string SqlQuery = " exec USP_GetRNCCheckListMasterData @RNCCheckListID='" + RNCCheckListID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "RNCCheckListMaster.GetByRNCCheckListID");

            List<RNCCheckListMasterDataModel> dataModels = new List<RNCCheckListMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<RNCCheckListMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(RNCCheckListMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec RNCCheckListMaster_AddUpdate";
            SqlQuery += " @RNCCheckListID='" + request.RNCCheckListID + "',@DepartmentID='" + request.DepartmentID + "',@RNCCheckListName='" + request.RNCCheckListName + "',@FileUpload='" + request.FileUpload + "',@UserID='" + request.UserID + "',@ActiveStatus='" + request.ActiveStatus + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "RNCCheckListMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int RNCCheckListID)
        {
            string SqlQuery = "exec USP_DeleteRNCCheckListMaster @RNCCheckListID='" + RNCCheckListID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "RNCCheckListMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool IfExists(int RNCCheckListID, int DepartmentID, string RNCCheckListName)
        {
            string SqlQuery = " USP_IfExistsRNCCheckListMaster @RNCCheckListID='" + RNCCheckListID + "',@DepartmentID = '" + DepartmentID + "',@RNCCheckListName='" + RNCCheckListName + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "RNCCheckListMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
