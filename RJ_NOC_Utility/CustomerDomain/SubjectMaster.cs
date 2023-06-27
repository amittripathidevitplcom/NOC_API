using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class SubjectMaster : UtilityBase, ISubjectMaster
    {
        public SubjectMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CourseList> GetDepartmentByCourse(int DepartmentID)
        {
            return UnitOfWork.SubjectMasterRepository.GetDepartmentByCourse(DepartmentID);
        }
        public List<SubjectMasterDataModel_list> GetAllSubjectList()
        {
            return UnitOfWork.SubjectMasterRepository.GetAllSubjectList();
        }
        public List<SubjectMasterDataModel> GetSubjectIDWise(int SubjectID)
        {
            return UnitOfWork.SubjectMasterRepository.GetSubjectIDWise(SubjectID);
        }
        public bool SaveData(SubjectMasterDataModel request)
        {
            return UnitOfWork.SubjectMasterRepository.SaveData(request);
        }       
        public bool DeleteData(int SubjectID)
        {
            return UnitOfWork.SubjectMasterRepository.DeleteData(SubjectID);
        }
        
        public bool IfExists(int SubjectID, string SubjectName)
        {
            return UnitOfWork.UniversityMasterRepository.IfExists(SubjectID, SubjectName);
        }

       
    }
}
