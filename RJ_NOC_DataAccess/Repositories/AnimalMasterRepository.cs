using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class AnimalMasterRepository : IAnimalMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public AnimalMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAllAnimalList()
        {
            string SqlQuery = " exec USP_GetAnimalMasterData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalMaster.GetAllAnimalList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<AnimalMasterDataModel> GetByID(int AnimalMasterID)
        {
            string SqlQuery = " exec USP_GetAnimalMasterData @AnimalMasterID='" + AnimalMasterID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalMaster.GetByID");

            List<AnimalMasterDataModel> dataModels = new List<AnimalMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<AnimalMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(AnimalMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec AnimalMaster_AddUpdate";
            SqlQuery += " @AnimalMasterID='" + request.AnimalMasterID + "',@DepartmentID='" + request.DepartmentID + "',@AnimalName='" + request.AnimalName + "',@ActiveStatus='" + request.ActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AnimalMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int AnimalMasterID)
        {
            string SqlQuery = "exec USP_DeleteAnimalMaster @AnimalMasterID='" + AnimalMasterID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AnimalMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int AnimalMasterID, int DepartmentID, string AnimalName)
        {
            string SqlQuery = " USP_IfExistsAnimalMaster @AnimalMasterID='" + AnimalMasterID + "',@DepartmentID = '" + DepartmentID + "',@AnimalName='" + AnimalName + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
