using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class LandAreaSituatedMasterRepository : ILandAreaSituatedMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public LandAreaSituatedMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<LandAreaSituatedModel_StateList> GetStateList()
        {
            string SqlQuery = "exec USP_StateLandAreaSituated";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LandAreaSituatedMaster.GetStateList");

            List<LandAreaSituatedModel_StateList> dataModels = new List<LandAreaSituatedModel_StateList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<LandAreaSituatedModel_StateList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<LandAreaSituated_DistrictList> GetDistrictList()
        {
            string SqlQuery = "exec USP_DistrictLandAreaSituated";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LandAreaSituatedMaster.GetDistrictList");

            List<LandAreaSituated_DistrictList> dataModels = new List<LandAreaSituated_DistrictList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<LandAreaSituated_DistrictList>>(JsonDataTable_Data);
            return dataModels;
        }
        
        public List<LandAreaSituatedMasterDataModel_list> GetAllLandAreaSituatedList()
        {
            string SqlQuery = " exec USP_GetLandAreaSituatedAllList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LandAreaSituatedMaster.GetAllLandAreaSituatedList");

            List<LandAreaSituatedMasterDataModel_list> dataModels = new List<LandAreaSituatedMasterDataModel_list>();
            LandAreaSituatedMasterDataModel_list dataModel = new LandAreaSituatedMasterDataModel_list();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<LandAreaSituatedMasterDataModel> GetLandAreaSituatedIDWise(int LandAreaID)
        {
            string SqlQuery = " exec USP_GetLandAreaSituatedAllList @LandAreaID='" + LandAreaID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LandAreaSituatedMaster.GetLandAreaSituatedIDWise");

            List<LandAreaSituatedMasterDataModel> dataModels = new List<LandAreaSituatedMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<LandAreaSituatedMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(LandAreaSituatedMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_LandAreaSituatedMasterInsert";
            SqlQuery += " @LandAreaID='" + request.LandAreaID + "',@StateID='" + request.StateID + "',@DistrictID='" + request.DistrictID+ "',@DepartmentID='" + request.DepartmentID + "',@LandAreaName='" + request.LandAreaName + "',@ActiveStatus='" + request.ActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "LandAreaSituatedMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int LandAreaID)
        {
            string SqlQuery = " Update M_LandAreaMaster set ActiveStatus=0 , DeleteStatus=1  WHERE LandAreaID='" + LandAreaID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "LandAreaSituatedMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int LandAreaID, string LandAreaName)
        {
            string SqlQuery = " select LandAreaName from M_LandAreaMaster Where LandAreaName='" + LandAreaName.Trim() + "'  and LandAreaID !='" + LandAreaID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LandAreaSituatedMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
      
    }
}
