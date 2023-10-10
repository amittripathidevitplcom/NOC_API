using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IStaffAttendance
    {
        List<CommonDataModel_DataTable> GetStaffList_CollegeWise(int CollegeID,string StaffType, int CourseID);
        bool SaveData(StaffAttendanceDataModel request);
        bool IfExists(int StaffAttendanceID, int CollegeID,string StaffType, int CourseID, string Date);
        List<CommonDataModel_DataTable> GetStaffAttendanceReportData( int CollegeID,string StaffType, int CourseID, string FromDate,string ToDate,int StatusID);
    }
}
