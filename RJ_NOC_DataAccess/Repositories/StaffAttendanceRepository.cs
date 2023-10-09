using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class StaffAttendanceRepository : IStaffAttendanceRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public StaffAttendanceRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetStaffList_CollegeWise(int CollegeID,string StaffType, int CourseID)
        {
            string SqlQuery = " exec USP_StaffListForAttendance_CollegeWise @CollegeID='" + CollegeID + "',@StaffType='" + StaffType + "',@CourseID='" + CourseID + "'";
            DataTable dt = new DataTable();
            dt = _commonHelper.Fill_DataTable(SqlQuery, "StaffAttendance.GetStaffList_CollegeWise");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dt;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool SaveData(StaffAttendanceDataModel request)
        {
            string StaffAttendanceDetail_Str = CommonHelper.GetDetailsTableQry(request.AttendanceDetailsList, "Temp_StaffAttendanceDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveStaffAttendanceDetails @StaffAttendanceID ='" + request.StaffAttendanceID + "', @CollegeID='" + request.CollegeID + "',@DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += "@StaffType = '" + request.StaffType + "',@CourseID = '" + request.CourseID + "',@Date = '" + request.Date + "',@IPAddress = '" + IPAddress + "',@StaffAttendanceDetail_Str='" + StaffAttendanceDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "StaffAttendance.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool IfExists(int StaffAttendanceID, int CollegeID,string StaffType, int CourseID, string Date)
        {
            string SqlQuery = " exec USP_IfExistsStaffAttendanceDetails @CollegeID='" + CollegeID + "',@StaffType = '" + StaffType + "',@CourseID = '" + CourseID + "',@Date = '" + Date + "',@StaffAttendanceID='" + StaffAttendanceID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StaffAttendance.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataTable> GetStaffAttendanceReportData(int CollegeID,string StaffType, int CourseID, string FromDate, string ToDate, int StatusID)
        {
            string SqlQuery = " exec USP_GetReportStaffAttendanceDetails @CollegeID='" + CollegeID + "',@StaffType='" + StaffType + "',@CourseID='" + CourseID + "',@FromDate='" + FromDate + "',@ToDate='" + ToDate + "',@StatusID='" + StatusID + "'";
            DataTable dt = new DataTable();
            dt = _commonHelper.Fill_DataTable(SqlQuery, "StaffAttendance.GetStaffAttendanceReportData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dt;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
