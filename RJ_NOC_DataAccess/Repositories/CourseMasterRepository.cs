using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RJ_NOC_Model;
using System.Threading.Tasks;
using RJ_NOC_DataAccess.Interface;
using System.Data.SqlClient;
using System.Data;
using FIH_EPR_DataAccess.Common;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Net;

namespace RJ_NOC_DataAccess.Repository
{
    public class CourseMasterRepository : ICourseMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CourseMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAllCourse(string LoginSSOID)
        {
            string SqlQuery = " exec USP_CourseMaster_GetData @LoginSSOID='" + LoginSSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CourseMaster.GetAllData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CourseMasterDataModel> GetCollegeWiseCourseIDWise(int CollegeWiseCourseID, string LoginSSOID)
        {
            string SqlQuery = " exec USP_CourseMaster_GetData @LoginSSOID ='"+ LoginSSOID + "',@CollegeWiseCourseID='" + CollegeWiseCourseID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CourseMaster.GetDataIDWise");

            List<CourseMasterDataModel> dataModels = new List<CourseMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CourseMasterDataModel>>(JsonDataTable_Data);
            return dataModels;

        }

        public bool SaveData(CourseMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CollegeWiseCourse_AddUpdate  ";

            SqlQuery += " @CollegeWiseCourseID='" + request.CollegeWiseCourseID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @CourseID='" + request.CourseID + "',";
            SqlQuery += " @CourseType='" + request.CourseTypeID + "',";
            SqlQuery += " @Seats='" + request.Seats + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',"; 
            SqlQuery += " @CollegeWiseCourse_SubjectDetails='" + CommonHelper.GetDetailsTableQry(request.SelectedSubjectDetails, "CollegeWiseCourse_SubjectDetails") + "'"; 

            int Rows = _commonHelper.NonQuerry(SqlQuery, "CourseMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool UpdateData(CourseMasterDataModel request)
        {

            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CollegeWiseCourse_AddUpdate  ";

            SqlQuery += " @CollegeWiseCourseID='" + request.CollegeWiseCourseID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @CourseID='" + request.CourseID + "',";
            SqlQuery += " @CourseType='" + request.CourseTypeID + "',";
            SqlQuery += " @Seats='" + request.Seats + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @CollegeWiseCourse_SubjectDetails='" + CommonHelper.GetDetailsTableQry(request.SelectedSubjectDetails, "CollegeWiseCourse_SubjectDetails") + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "CourseMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int CollegeWiseCourseID)
        {
            string SqlQuery = " Update Trn_CollegeWiseCourse set ActiveStatus=0 , DeleteStatus=1  WHERE CollegeWiseCourseID='" + CollegeWiseCourseID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CourseMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int CourseID, string CourseName)
        {
            //string SqlQuery = " select CourseName from M_CourseMaster Where CourseName='" + CourseName.Trim() + "'  and CourseID !='" + CourseID + "'  and DeleteStatus=0";
            //DataTable dataTable = new DataTable();
            //dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CourseMaster.IfExists");
            //if (dataTable.Rows.Count > 0)
            //    return true;
            //else
                return false;
        }

    }
}
