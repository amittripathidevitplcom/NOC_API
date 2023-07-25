using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class CourseMaster : UtilityBase, ICourseMaster
    {
        public CourseMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllCourse(string LoginSSOID)
        {
            return UnitOfWork.CourseMasterRepository.GetAllCourse(LoginSSOID);
        }
        public List<CourseMasterDataModel> GetCollegeWiseCourseIDWise(int CollegeWiseCourseID, string LoginSSOID)
        {
            return UnitOfWork.CourseMasterRepository.GetCollegeWiseCourseIDWise(CollegeWiseCourseID,LoginSSOID);
        }
        public bool SaveData(CourseMasterDataModel request)
        {
            return UnitOfWork.CourseMasterRepository.SaveData(request);
        }
        public bool UpdateData(CourseMasterDataModel request)
        {
            return UnitOfWork.CourseMasterRepository.UpdateData(request);
        }
        public bool DeleteData(int CollegeWiseCourseID)
        {
            return UnitOfWork.CourseMasterRepository.DeleteData(CollegeWiseCourseID);
        }
        
        public bool IfExists(int CourseID, int DepartmentID, int CollegeWiseCourseID, int CollegeID, int StreamMasterID)
        {
            return UnitOfWork.CourseMasterRepository.IfExists(CourseID, DepartmentID, CollegeWiseCourseID, CollegeID, StreamMasterID);
        }
         
    }
}
