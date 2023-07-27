using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class UniversityMasterRepository : IUniversityMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public UniversityMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        
        public List<UniversityasterDataModel_list> GetAllUniversityList(int DepartmentID)
        {
            string SqlQuery = " exec USP_GetUniversityList @DepartmentID='" + DepartmentID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "UiversityMaster.GetAllUniversityList");

            List<UniversityasterDataModel_list> dataModels = new List<UniversityasterDataModel_list>();
            UniversityasterDataModel_list dataModel = new UniversityasterDataModel_list();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<UniversityasterDataModel> GetUniversityIDWise(int UniversityID)
        {
            string SqlQuery = " exec USP_GetUniversityList @UniversityID='" + UniversityID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "UiversityMaster.GetUniversityIDWise");

            List<UniversityasterDataModel> dataModels = new List<UniversityasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<UniversityasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(UniversityasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_UniversityMasterInsert";
            SqlQuery += " @UniversityID='" + request.UniversityID + "',@DepartmentID='" + request.DepartmentID + "',@UniversityName='" + request.UniversityName + "',@UserID='" + request.UserID + "',@ActiveStatus='" + request.ActiveStatus + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "UiversityMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int UniversityID)
        {
            string SqlQuery = " Update M_UniversityMaster set ActiveStatus=0 , DeleteStatus=1  WHERE UniversityID='" + UniversityID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "UiversityMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int UniversityID, string UniversityName)
        {
            string SqlQuery = " select UniversityName from M_UniversityMaster Where UniversityName='" + UniversityName.Trim() + "'  and UniversityID !='" + UniversityID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "UiversityMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
      
    }
}
