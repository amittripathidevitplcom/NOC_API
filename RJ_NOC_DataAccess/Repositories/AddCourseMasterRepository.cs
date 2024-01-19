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
        public List<CommonDataModel_DataTable> GetAllCourseList(int DepartmentID)
        {
            string SqlQuery = "exec USP_AddCourseMaster_GetData @DepartmentID='"+DepartmentID+"'";
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
            List<AddCourseMasterDataModel> dataModels = new List<AddCourseMasterDataModel>();
            string SqlQuery = " exec USP_AddCourseMaster_GetData @CourseID='" + CourseID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AddCourseMasterService.GetCourseIDWise");
            if (dataSet != null)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                dataModels = JsonConvert.DeserializeObject<List<AddCourseMasterDataModel>>(JsonDataTable_Data);
                if (dataSet.Tables[1] != null)
                {
                    string subjects = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<SubjectAddCourseMasterDataModel> subjectaddcoursemasterdatamodel = JsonConvert.DeserializeObject<List<SubjectAddCourseMasterDataModel>>(subjects);
                    dataModels[0].CourseSubjects = subjectaddcoursemasterdatamodel;
                }
            }
            return dataModels;
        }
        public bool SaveData(AddCourseMasterDataModel request)
        {

            string CourseSubject_str = request.CourseSubjects.Count>0? CommonHelper.GetDetailsTableQry(request.CourseSubjects, "Temp_M_CourseWiseSubject"):"";
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_USP_AddCourseMaster_AddUpdate";
            SqlQuery += " @CourseID='" + request.CourseID + "',@DepartmentID='" + request.DepartmentID + "',@CollegeLevel='" + request.CollegeLevel + "',@CourseLevelID='" + request.CourseLevelID + "',@CourseName='" + request.CourseName+ "',@Duration='" + request.Duration + "',@NoOfRooms='" + request.NoOfRooms + "',@CourseDurationType='" + request.CourseDurationType + "',";
            SqlQuery += "@ActiveStatus='" + request.ActiveStatus+ "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "',@CourseSubject_str='" + CourseSubject_str + "',@UniversityID='" + request.UniversityID + "',@StreamID='" + request.StreamID + "',@NoofSubjectsForCombination='" + request.NoofSubjectsForCombination + "'";
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
        public bool IfExists(int DepartmentID,int CourseID, string CourseName,int UniversityID,int StreamID, int CourseLevelID)
        {
            string SqlQuery = "USP_IfExistsCourse @CourseID='" + CourseID + "',@DepartmentID='" + DepartmentID + "',@UniversityID='" + UniversityID + "',@CourseName='" + CourseName + "',@StreamID='" + StreamID + "',@CourseLevelID='" + CourseLevelID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AddCourseMasterService.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
      
    }
}
