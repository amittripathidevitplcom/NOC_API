using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class StreamMasterRepository : IStreamMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public StreamMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAllStreamList()
        {
            string SqlQuery = " exec USP_GetStreamMasterData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StreamMaster.GetAllStreamList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<StreamMasterDataModel> GetByID(int StreamMasterID)
        {
            string SqlQuery = " exec USP_GetStreamMasterData @StreamMasterID='" + StreamMasterID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StreamMaster.GetByID");

            List<StreamMasterDataModel> dataModels = new List<StreamMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<StreamMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(StreamMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_StreamMaster_AddUpdate";
            SqlQuery += " @StreamMasterID='" + request.StreamMasterID + "',@DepartmentID='" + request.DepartmentID + "',@CourseLevelID='" + request.CourseLevelID + "',@CourseID='" + request.CourseID + "',@StreamName='" + request.StreamName + "',@ActiveStatus='" + request.ActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "StreamMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int StreamMasterID)
        {
            string SqlQuery = "exec USP_DeleteStreamMaster @StreamMasterID='" + StreamMasterID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "StreamMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int StreamMasterID, int DepartmentID, string StreamName)
        {
            string SqlQuery = " USP_IfExistsStreamMaster @StreamMasterID='" + StreamMasterID + "',@DepartmentID = '" + DepartmentID + "',@StreamName='" + StreamName + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StreamMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
