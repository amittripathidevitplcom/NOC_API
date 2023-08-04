using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class AddCourseMasterRepository : IAddCourseMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public AddCourseMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAllCourseList()
        {
            string SqlQuery = "exec USP_AddCourseMaster_GetData ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AddCourseMasterService.GetAllCourseList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<AddCourseMasterDataModel> GetCourseIDWise(int CourseID)
        {
            string SqlQuery = " exec USP_AddCourseMaster_GetData @CourseID='" + CourseID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AddCourseMasterService.GetCourseIDWise");

            List<AddCourseMasterDataModel> dataModels = new List<AddCourseMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<AddCourseMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(AddCourseMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_USP_AddCourseMaster_AddUpdate";
            SqlQuery += " @CourseID='" + request.CourseID + "',@DepartmentID='" + request.DepartmentID + "',@CourseLevelID='" + request.CourseLevelID + "',@CourseName='" + request.CourseName+ "',@Duration='" + request.Duration + "',@NoOfRooms='" + request.NoOfRooms + "',@CourseDurationType='" + request.CourseDurationType + "',";
            SqlQuery += "@ActiveStatus='" + request.ActiveStatus+ "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AddCourseMasterService.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int CourseID)
        {
            string SqlQuery = " Update M_CourseMaster set ActiveStatus=0 , DeleteStatus=1  WHERE CourseID='" + CourseID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AddCourseMasterService.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int DepartmentID,int CourseID, string CourseName)
        {
            string SqlQuery = " select CourseName from M_CourseMaster Where DepartmentID = '" + DepartmentID + "' and CourseName='" + CourseName.Trim() + "'  and CourseID !='" + CourseID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AddCourseMasterService.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
      
    }
}
