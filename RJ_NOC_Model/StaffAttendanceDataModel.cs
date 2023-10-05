using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class StaffAttendanceDataModel
    {
        public int StaffAttendanceID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public int StaffDetailID { get; set; }
        public string? Date { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int UserID { get; set; }
        public string? IPAddress { get; set; }
        public List<AttendanceDataModel> AttendanceDetailsList { get; set; }
    }
    public class AttendanceDataModel
    {
        public int StaffAttendanceDetailID { get; set; }
        public int StaffID { get; set; }
        public int PresentStatus { get; set; }

    }
}
