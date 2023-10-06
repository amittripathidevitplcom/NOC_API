using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IStaffAttendanceRepository
    {
        List<CommonDataModel_DataTable> GetStaffList_CollegeWise(int CollegeID, int CourseID);
        bool SaveData(StaffAttendanceDataModel request);
        bool IfExists(int StaffAttendanceID, int CollegeID, int CourseID, string Date);
    }
}
