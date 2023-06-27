using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class AddRoleMasterRepository : IAddRoleMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public AddRoleMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<CommonDataModel_DataTable> GetList()
        {
            string SqlQuery = " exec USP_AddRoleMaster_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AddRoleMaster.GetList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<AddRoleMasterDataModel> GetByID(int RoleID)
        {
            string SqlQuery = " exec USP_AddRoleMaster_GetData @RoleID='" + RoleID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AddRoleMaster.GetByID");

            List<AddRoleMasterDataModel> dataModels = new List<AddRoleMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<AddRoleMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(AddRoleMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_AddRoleList_AddUpdate";
            SqlQuery += " @RoleID='" + request.RoleID + "',@RoleName='" + request.RoleName + "',@UserID='" + request.UserID + "',@ActiveStatus='" + request.ActiveStatus + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AddRoleMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int RoleID)
        {
            string SqlQuery = " Update M_RoleMaster set ActiveStatus=0 , DeleteStatus=1  WHERE RoleID='" + RoleID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AddRoleMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int RoleID, string RoleName)
        {
            string SqlQuery = " select RoleName from M_RoleMaster Where RoleName='" + RoleName.Trim() + "'  and RoleID !='" + RoleID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AddRoleMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
