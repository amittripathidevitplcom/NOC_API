using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IAddCourseMasterRepository
    {
        List<CommonDataModel_DataTable> GetAllCourseList(int DepartmentID);
        List<AddCourseMasterDataModel> GetCourseIDWise(int CourseID);
        bool SaveData(AddCourseMasterDataModel request);       
        bool DeleteData(int CourseID);
        bool IfExists(int DepartmentID,int CourseID, string CourseName, int UniversityID, int StreamID);
      

    }

}

