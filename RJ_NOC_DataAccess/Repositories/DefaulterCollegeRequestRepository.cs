using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class DefaulterCollegeRequestRepository : IDefaulterCollegeRequestRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DefaulterCollegeRequestRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        
        public List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData()
        {
            string SqlQuery = " exec USP_GetDefaulterCollegeRequestData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.GetRNCCheckListData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<DefaulterCollegeRequestDataModel> GetByID(int RNCCheckListID)
        {
            string SqlQuery = " exec USP_GetDefaulterCollegeRequestData @RNCCheckListID='" + RNCCheckListID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.GetByRNCCheckListID");

            List<DefaulterCollegeRequestDataModel> dataModels = new List<DefaulterCollegeRequestDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<DefaulterCollegeRequestDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(DefaulterCollegeRequestDataModel request)
        {
            //string IPAddress = CommonHelper.GetVisitorIPAddress();
            //string SqlQuery = " exec DefaulterCollegeRequest_AddUpdate";
            //SqlQuery += " @RNCCheckListID='" + request.RNCCheckListID + "',@DepartmentID='" + request.DepartmentID + "',@RNCCheckListName='" + request.RNCCheckListName + "',@FileUpload='" + request.FileUpload + "',@UserID='" + request.UserID + "',@ActiveStatus='" + request.ActiveStatus + "',@IPAddress='" + IPAddress + "'";
            //int Rows = _commonHelper.NonQuerry(SqlQuery, "DefaulterCollegeRequest.SaveData");
            //if (Rows > 0)
            //    return true;
            //else
                return false;
        }
        public bool DeleteData(int RNCCheckListID)
        {
            string SqlQuery = "exec USP_DeleteDefaulterCollegeRequest @RNCCheckListID='" + RNCCheckListID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DefaulterCollegeRequest.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool IfExists(int RNCCheckListID, int DepartmentID, string RNCCheckListName)
        {
            string SqlQuery = " USP_IfExistsDefaulterCollegeRequest @RNCCheckListID='" + RNCCheckListID + "',@DepartmentID = '" + DepartmentID + "',@RNCCheckListName='" + RNCCheckListName + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
