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
        List<CommonDataModel_DataTable> GetAllCourse(string LoginSSOID);
        List<CourseMasterDataModel> GetCollegeWiseCourseIDWise(int CollegeWiseCourseID, string LoginSSOID);
        bool SaveData(CourseMasterDataModel request);
        bool UpdateData(CourseMasterDataModel request);
        bool DeleteData(int CollegeWiseCourseID);
        bool IfExists(int CourseID, int DepartmentID, int CollegeWiseCourseID, int CollegeID); 
    }

}

