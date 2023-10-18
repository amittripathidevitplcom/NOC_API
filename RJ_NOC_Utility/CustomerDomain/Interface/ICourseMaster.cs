using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICourseMaster
    {
        List<CommonDataModel_DataTable> GetAllCourse(string LoginSSOID);
        List<CommonDataModel_DataTable> GetAllCourseDTE(string LoginSSOID, int CollegeWiseCourseID);
        List<CourseMasterDataModel> GetCollegeWiseCourseIDWise(int CollegeWiseCourseID, string LoginSSOID);
        bool SaveData(CourseMasterDataModel request);
        bool DTESaveData(DTECourseMasterDataModel request);
        bool UpdateData(CourseMasterDataModel request);
        bool DeleteData(int CollegeWiseCourseID);
        bool IfExists(int CourseID, int DepartmentID, int CollegeWiseCourseID, int CollegeID, int StreamMasterID);
        DataTable IfExists_CheckCourseandSubject(string Action, int CollegeWiseCourseID, string Subject_Ids);
        List<CommonDataModel_DataTable> GetCoursesByCollegeID(int CollegeID);
    }
}