using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class FacilitiesMasterRepository : IFacilitiesMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public FacilitiesMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        
        public List<FacilitiesMasterDataModel_list> GetAllFacilitiesList()
        {
            string SqlQuery = " exec USP_GetFacilitiesMasterAllList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "FacilitiesMaser.GetAllFacilitiesList");

            List<FacilitiesMasterDataModel_list> dataModels = new List<FacilitiesMasterDataModel_list>();
            FacilitiesMasterDataModel_list dataModel = new FacilitiesMasterDataModel_list();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<FacilitiesMasterDataModel> GetFacilitiesIDWise(int FID)
        {
            string SqlQuery = " exec USP_GetFacilitiesMasterAllList @FID='" + FID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "FacilitiesMaser.GetUniversityIDWise");

            List<FacilitiesMasterDataModel> dataModels = new List<FacilitiesMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<FacilitiesMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(FacilitiesMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_M_FacilitiesMasterInsert";
            SqlQuery += " @FID='" + request.FID + "',@DepartmentID='" + request.DepartmentID + "',@FacilitiesName='" + request.FacilitiesName + "',@MinSize='" + request.MinSize + "',@Unit='" + request.Unit + "',@UserID='" + request.UserID + "',@ActiveStatus='"+request.ActiveStatus+"',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "FacilitiesMaser.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int FID)
        {
            string SqlQuery = " Update M_FacilitiesMaster set ActiveStatus=0 , DeleteStatus=1  WHERE FID='" + FID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "FacilitiesMaser.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int FID, string FacilitiesName)
        {
            string SqlQuery = " select FacilitiesName from M_FacilitiesMaster Where FacilitiesName='" + FacilitiesName.Trim() + "'  and FID !='" + FID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "FacilitiesMaser.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
      
    }
}
