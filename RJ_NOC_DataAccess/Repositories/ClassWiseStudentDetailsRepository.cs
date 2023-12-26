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
        public List<ClassWiseStudentDetailsDataModel> GetCollegeWiseStudenetDetails(int CollegeID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_ClassWiseStudentDetails_GET  @Key='GetStudentDetails',@CollegeID='" + CollegeID + "',@ApplyNOCID='" + ApplyNOCID + "'";
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

        public List<SubjectWiseStatisticsDetailsDataModel> GetSubjectWiseStudenetDetails(int CollegeID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_ClassWiseStudentDetails_GET  @Key='GetStudentDetailsSubjectWise',@CollegeID='" + CollegeID + "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ClassWiseStudentDetailsRepository.GetSubjetWiseStudenetDetails");
            List<SubjectWiseStatisticsDetailsDataModel> dataModels = new List<SubjectWiseStatisticsDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<SubjectWiseStatisticsDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;
        }

        public bool StatisticsFinalSubmit_Save(StatisticsFinalSubmitDataModel model)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_StatisticsFinalSubmit_Save @CollegeID='"+ model.CollegeID+ "',@SSOID='"+ model.SSOID+ "',@Confirmation='" + model.Confirmation + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ClassWiseStudentDetailsRepository.StatisticsFinalSubmit_Save");
            if (Rows > 0)
                return true;
            else
                return false;
        }
         

        List<DataTable> IClassWiseStudentDetailsRepository.CollegeList_StatisticsDraftSubmited(CollegeList_StatisticsDraftSubmitedDataModel_Filter model)
        {
            string SqlQuery = " exec USP_CollegeList_StatisticsDraftSubmited  @DepartmentID = '" + model.DepartmentID + "',@UniversityID =   '" + model.UniversityID + "',@DivisionID =  '" + model.DivisionID + "',@DistrictID =  '" + model.DistrictID + "'";
            
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ClassWiseStudentDetailsRepository.CollegeList_StatisticsDraftSubmited");
            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<DataTable> CollegeList_StatisticsFinalSubmited(CollegeList_StatisticsFinalSubmitedDataModel_Filter model)
        {
            string SqlQuery = " exec USP_CollegeList_StatisticsFinalSubmited  @DepartmentID = '" + model.DepartmentID + "',@UniversityID =   '" + model.UniversityID + "',@DivisionID =  '" + model.DivisionID + "',@DistrictID =  '" + model.DistrictID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ClassWiseStudentDetailsRepository.CollegeList_StatisticsDraftSubmited");
            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
