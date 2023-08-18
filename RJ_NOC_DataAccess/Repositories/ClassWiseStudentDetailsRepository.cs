using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class ClassWiseStudentDetailsRepository : IClassWiseStudentDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ClassWiseStudentDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<ClassWiseStudentDetailsDataModel> GetCollegeWiseStudenetDetails(int CollegeID)
        {
            string SqlQuery = " exec USP_ClassWiseStudentDetails_GET  @Key='GetStudentDetails',@CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ClassWiseStudentDetailsRepository.GetCollegeWiseStudenetDetails");
            List<ClassWiseStudentDetailsDataModel> dataModels = new List<ClassWiseStudentDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ClassWiseStudentDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(PostClassWiseStudentDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ClassWiseStudentDetails_AddUpdate";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @ClassWiseStudentDetails='" + CommonHelper.GetDetailsTableQry(request.ClassWiseStudentDetails, "ClassWiseStudentDetails") + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ClassWiseStudentDetailsRepository.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }


      
        public bool SaveDataSubjectWise(PostSubjectWiseStatisticsDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SubjectWiseStaticsDetails_AddUpdate";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @SubjectWiseStaticsDetails='" + CommonHelper.GetDetailsTableQry(request.SubjectWiseStatisticsDetails, "SubjectWiseStaticsDetails") + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ClassWiseStudentDetailsRepository.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<SubjectWiseStatisticsDetailsDataModel> GetSubjectWiseStudenetDetails(int CollegeID)
        {
            string SqlQuery = " exec USP_ClassWiseStudentDetails_GET  @Key='GetStudentDetailsSubjectWise',@CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ClassWiseStudentDetailsRepository.GetSubjetWiseStudenetDetails");
            List<SubjectWiseStatisticsDetailsDataModel> dataModels = new List<SubjectWiseStatisticsDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<SubjectWiseStatisticsDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}
