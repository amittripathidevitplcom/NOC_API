using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICourseMaster
    {
        List<CommonDataModel_DataTable> GetAllCourse();
        List<CourseMasterDataModel> GetCourseIDWise(int CourseID);
        bool SaveData(CourseMasterDataModel request);
        bool UpdateData(CourseMasterDataModel request);
        bool DeleteData(int CourseID);
        bool IfExists(int CourseID, string CourseName);
    }
}