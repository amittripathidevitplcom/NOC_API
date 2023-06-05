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
        List<CommonDataModel_DataTable> GetAllCourse();
        List<CourseMasterDataModel> GetCourseIDWise(int CourseID);
        bool SaveData(CourseMasterDataModel request);
        bool UpdateData(CourseMasterDataModel request);
        bool DeleteData(int CourseID);
        bool IfExists(int CourseID, string CourseName); 
    }

}

