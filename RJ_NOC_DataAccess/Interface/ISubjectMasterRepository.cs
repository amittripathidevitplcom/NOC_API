using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface ISubjectMasterRepository
    {
        List<CourseList> GetDepartmentByCourse(int DepartmentID);
        List<SubjectMasterDataModel_list> GetAllSubjectList(int SubjectID);
        List<SubjectMasterDataModel> GetSubjectIDWise(int SubjectID);
        bool SaveData(SubjectMasterDataModel request);       
        bool DeleteData(int SubjectID);
        bool IfExists(int SubjectID, string SubjectName);
      

    }

}

