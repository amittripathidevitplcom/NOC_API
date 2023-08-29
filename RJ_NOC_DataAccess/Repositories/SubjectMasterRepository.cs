using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;


namespace RJ_NOC_DataAccess.Repository
{
    public class SubjectMasterRepository : ISubjectMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public SubjectMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        //public List<CourseList> GetDepartmentByCourse(int DepartmentID)
        //{
        //    string SqlQuery = "exec USP_GetCourseList @DepartmentID=" + DepartmentID;
        //    DataTable dataTable = new DataTable();
        //    dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SubjectMasterService.GetDepartmentByCourse");

        //    List<CourseList> dataModels = new List<CourseList>();
        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
        //    dataModels = JsonConvert.DeserializeObject<List<CourseList>>(JsonDataTable_Data);
        //    return dataModels;
        //}
        public List<SubjectMasterDataModel_list> GetAllSubjectList(int DepartmentID)
        {
            string SqlQuery = " exec USP_GetAllSubjectList @DepartmentID=" + DepartmentID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SubjectMasterService.GetAllSubjectList");

            List<SubjectMasterDataModel_list> dataModels = new List<SubjectMasterDataModel_list>();
            SubjectMasterDataModel_list dataModel = new SubjectMasterDataModel_list();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<SubjectMasterDataModel> GetSubjectIDWise(int SubjectID)
        {
            string SqlQuery = " exec USP_GetAllSubjectList @SubjectID='" + SubjectID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SubjectMasterService.GetSubjectIDWise");

            List<SubjectMasterDataModel> dataModels = new List<SubjectMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<SubjectMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(SubjectMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_M_SubjectMasterInsert";
            SqlQuery += " @SubjectID='" + request.SubjectID + "',@DepartmentID='" + request.DepartmentID + "',@SubjectName='" + request.SubjectName + "',@IsPredical='" + request.IsPredical+ "',@ActiveStatus='" + request.ActiveStatus+ "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "SubjectMasterService.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int SubjectID)
        {
            string SqlQuery = " Update M_SubjectMaster set ActiveStatus=0 , DeleteStatus=1  WHERE SubjectID='" + SubjectID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "SubjectMasterService.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int DepartmentID,int SubjectID, string SubjectName)
        {
            string SqlQuery = " select SubjectName from M_SubjectMaster Where DepartmentID = '"+ DepartmentID + "' and SubjectName='" + SubjectName.Trim() + "'  and SubjectID <>'" + SubjectID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SubjectMasterService.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
      
    }
}
