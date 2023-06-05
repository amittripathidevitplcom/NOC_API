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
        public List<CommonDataModel_DataTable> GetAllCourse()
        {
            string SqlQuery = " exec USP_CourseMaster_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CourseMaster.GetAllData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CourseMasterDataModel> GetCourseIDWise(int CourseID)
        {
            string SqlQuery = " exec USP_CourseMaster_GetData @CourseID='" + CourseID + "'";
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
            string SqlQuery = " exec USP_CourseMaster_IU  ";
            SqlQuery += " @EmpanelmentType='" + request.EmpanelmentType + "',@CourseID='" + request.CourseID + "',@CourseName='" + request.CourseName + "',@DepartmentName='" + request.DepartmentName + "',@NumberofResources='" + request.NumberofResources + "',@UserID='" + request.UserID + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CourseMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool UpdateData(CourseMasterDataModel request)
        {

            //string IPAddress = CommonHelper.GetVisitorIPAddress();
            //string SqlQuery = " exec USP_CourseMaster_IU  ";
            //SqlQuery = " @CourseID='" + request.CourseID + "',@CourseName='" + request.CourseID + "',@DepartmentName='" + request.CourseID + "',@NumberofResources='" + request.CourseID + "',@UserID='" + request.CourseID + "',@IPAddress='" + IPAddress + "'";
            //int Rows = _commonHelper.NonQuerry(SqlQuery, "CourseMaster.SaveData");
            //if (Rows > 0)
            //    return true;
            //else
            return false;
        }

        public bool DeleteData(int CourseID)
        {
            string SqlQuery = " Update M_CourseMaster set ActiveStatus=0 , DeleteStatus=1  WHERE CourseID='" + CourseID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CourseMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int CourseID, string CourseName)
        {
            string SqlQuery = " select CourseName from M_CourseMaster Where CourseName='" + CourseName.Trim() + "'  and CourseID !='" + CourseID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CourseMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
         
    }
}
