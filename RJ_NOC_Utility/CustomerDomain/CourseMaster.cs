using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace FIH_EPR_Utility.CustomerDomain
{
    public class CourseMaster : UtilityBase, ICourseMaster
    {
        public CourseMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllCourse()
        {
            return UnitOfWork.CourseMasterRepository.GetAllCourse();
        }
        public List<CourseMasterDataModel> GetCourseIDWise(int CourseID)
        {
            return UnitOfWork.CourseMasterRepository.GetCourseIDWise(CourseID);
        }
        public bool SaveData(CourseMasterDataModel request)
        {
            return UnitOfWork.CourseMasterRepository.SaveData(request);
        }
        public bool UpdateData(CourseMasterDataModel request)
        {
            return UnitOfWork.CourseMasterRepository.UpdateData(request);
        }
        public bool DeleteData(int CourseID)
        {
            return UnitOfWork.CourseMasterRepository.DeleteData(CourseID);
        }
        
        public bool IfExists(int CourseID, string CourseName)
        {
            return UnitOfWork.CourseMasterRepository.IfExists(CourseID, CourseName);
        }
         
    }
}
