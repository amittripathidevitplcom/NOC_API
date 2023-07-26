using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using System.Reflection;


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
            string SqlQuery = "exec USP_GetStreamMasterData @Key='GetmappingList'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StreamMaster.GetAllStreamList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<StreamMasterDataModel> GetByID(int StreamMappingID)
        {
            string SqlQuery = " exec USP_GetStreamMasterData @Key='GetDetails',@StreamMappingID='" + StreamMappingID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "StreamMaster.GetByID");

            List<StreamMasterDataModel> listdataModels = new List<StreamMasterDataModel>();

            StreamMasterDataModel dataModels = new StreamMasterDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels.StreamMappingID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["StreamMappingID"]);
                dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DepartmentID"]);
                dataModels.CourseLevelID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CourseLevelID"]);
                dataModels.CourseID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CourseID"]);
                dataModels.StreamID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["StreamID"]);
                //dataModels.StreamName = dataSet.Tables[0].Rows[0]["StreamName"].ToString();


                dataModels.ActiveStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ActiveStatus"]);

                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                List<CourseSubjectMappingListData> SubDataModel_Item = JsonConvert.DeserializeObject<List<CourseSubjectMappingListData>>(JsonDataTable_Data);
                dataModels.SubjectDetails = SubDataModel_Item;
                listdataModels.Add(dataModels);
            }

            return listdataModels;

        }

        //public List<StreamMasterDataModel> GetByID(int StreamMasterID)
        //{
        //    string SqlQuery = " exec USP_GetStreamMasterData @StreamMasterID='" + StreamMasterID + "'";
        //    DataTable dataTable = new DataTable();
        //    dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StreamMaster.GetByID");

        //    List<StreamMasterDataModel> dataModels = new List<StreamMasterDataModel>();
        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
        //    dataModels = JsonConvert.DeserializeObject<List<StreamMasterDataModel>>(JsonDataTable_Data);
        //    return dataModels;
        //}
        public bool SaveData(StreamMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_StreamMaster_AddUpdate";
            SqlQuery += " @StreamMappingID='" + request.StreamMappingID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @CourseLevelID='" + request.CourseLevelID + "',";
            SqlQuery += " @CourseID='" + request.CourseID + "',";
            SqlQuery += " @StreamID='" + request.StreamID + "',";
            SqlQuery += " @ActiveStatus='" + request.ActiveStatus + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @CollegeWiseCourse_SubjectDetails='" + CommonHelper.GetDetailsTableQry(request.SubjectDetails.Where(f => f.IsChecked), "CollegeWiseCourse_SubjectDetails") + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "StreamMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int StreamMappingID)
        {
            string SqlQuery = "exec USP_DeleteStreamMaster @StreamMappingID='" + StreamMappingID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "StreamMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int StreamMappingID, int CourseLevelID, int CourseID, int DepartmentID, int StreamID)
        {
            string SqlQuery = " USP_IfExistsStreamMaster @StreamMappingID='" + StreamMappingID + "',@CourseLevelID = '" + CourseLevelID + "',@CourseID = '" + CourseID + "',@DepartmentID = '" + DepartmentID + "',@StreamID='" + StreamID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StreamMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
