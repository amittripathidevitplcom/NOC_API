using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class AddCourseMaster : UtilityBase, IAddCourseMaster
    {
        public AddCourseMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllCourseList(int DepartmentID)
        {
            return UnitOfWork.AddCourseMasterRepository.GetAllCourseList(DepartmentID);
        }
        public List<AddCourseMasterDataModel> GetCourseIDWise(int CourseID)
        {
            return UnitOfWork.AddCourseMasterRepository.GetCourseIDWise(CourseID);
        }
        public bool SaveData(AddCourseMasterDataModel request)
        {
            return UnitOfWork.AddCourseMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int CourseID)
        {
            return UnitOfWork.AddCourseMasterRepository.DeleteData(CourseID);
        }
        
        public bool IfExists(int DepartmentID,int CourseID, string CourseName, int UniversityID, int StreamID)
        {
            return UnitOfWork.AddCourseMasterRepository.IfExists(DepartmentID, CourseID, CourseName,UniversityID,StreamID);
        }

       
    }
}
