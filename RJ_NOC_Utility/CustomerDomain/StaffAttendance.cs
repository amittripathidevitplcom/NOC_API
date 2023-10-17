using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class StaffAttendance : UtilityBase, IStaffAttendance
    {
        public StaffAttendance(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetStaffList_CollegeWise(int CollegeID,string StaffType, int CourseID, string Date)
        {
            return UnitOfWork.StaffAttendanceRepository.GetStaffList_CollegeWise(CollegeID, StaffType, CourseID, Date);
        }
        public bool SaveData(StaffAttendanceDataModel request)
        {
            return UnitOfWork.StaffAttendanceRepository.SaveData(request);
        }
        public bool IfExists(int StaffAttendanceID, int CollegeID,string StaffType, int CourseID, string Date)
        {
            return UnitOfWork.StaffAttendanceRepository.IfExists(StaffAttendanceID, CollegeID, StaffType, CourseID, Date);
        }
        public List<CommonDataModel_DataTable> GetStaffAttendanceReportData(int CollegeID,string StaffType, int CourseID, string FromDate, string ToDate, int StatusID)
        {
            return UnitOfWork.StaffAttendanceRepository.GetStaffAttendanceReportData(CollegeID, StaffType, CourseID, FromDate, ToDate, StatusID);
        }
    }
}
