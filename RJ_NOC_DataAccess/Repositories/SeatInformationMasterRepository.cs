using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class SeatInformationMasterRepository : ISeatInformationMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public SeatInformationMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetSeatInformationList()
        {
            string SqlQuery = " exec USP_GetSeatInfomationData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SeatInformationMaster.GetSeatInformationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<SeatInformationMasterDataModel> GetSeatByID(int ID)
        {
            string SqlQuery = " exec USP_GetSeatInfomationData @ID='" + ID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SeatInformationMaster.GetSeatByID");

            List<SeatInformationMasterDataModel> dataModels = new List<SeatInformationMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<SeatInformationMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(SeatInformationMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SeatInformation_AddUpdate";
            SqlQuery += " @ID='" + request.ID + "',@DepartmentID='" + request.DepartmentID + "',@CourseID='" + request.CourseID + "',@NoofSeats='" + request.NoofSeats + "', @ActiveStatus='" + request.ActiveStatus + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "SeatInformationMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int ID)
        {
            string SqlQuery = " Update M_SeatInformationMaster set ActiveStatus=0 , DeleteStatus=1  WHERE ID='" + ID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "SeatInformationMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        //DepartmentID = '" + DepartmentID + "' and
        public bool IfExists(int ID, int DepartmentID, int CourseID)
        {
            string SqlQuery = " select CourseID from M_SeatInformationMaster Where  CourseID='" + CourseID + "'  and ID !='" + ID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SeatInformationMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
