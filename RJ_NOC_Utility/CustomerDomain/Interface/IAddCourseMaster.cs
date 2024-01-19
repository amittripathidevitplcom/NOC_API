using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IAddCourseMaster
    {
        List<CommonDataModel_DataTable> GetAllCourseList(int DepartmentID);
        List<AddCourseMasterDataModel> GetCourseIDWise(int CourseID);
        bool SaveData(AddCourseMasterDataModel request);       
        bool DeleteData(int SubjectID);
        bool IfExists(int DepartmentID,int CourseID, string CourseName, int UniversityID, int StreamID,int CourseLevelID);


    }
}