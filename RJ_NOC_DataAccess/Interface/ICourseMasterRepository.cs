using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ICourseMasterRepository
    {
        List<CommonDataModel_DataTable> GetAllCourse(string LoginSSOID, int CollegeID, int ApplyNOCID);
        List<CommonDataModel_DataTable> GetAllCourseDTE(string LoginSSOID, int CollegeWiseCourseID, int CollegeID, int ApplyNOCID);
        List<CourseMasterDataModel> GetCollegeWiseCourseIDWise(int CollegeWiseCourseID, string LoginSSOID);
        bool SaveData(CourseMasterDataModel request);
        bool DTESaveData(DTECourseMasterDataModel request);
        bool UpdateData(CourseMasterDataModel request);
        bool DeleteData(int CollegeWiseCourseID);
        bool IfExists(int CourseID, int DepartmentID, int CollegeWiseCourseID, int CollegeID,int StreamMasterID);
        DataTable IfExists_CheckCourseandSubject(string Action, int CollegeWiseCourseID, string Subject_Ids);
        List<CommonDataModel_DataTable> GetCoursesByCollegeID(int CollegeID);

        List<CommonDataModel_DataTable> CoursesReport(CourseReportSearchFilter request);
    }

}

