using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ISubjectMaster
    {
        List<CourseList> GetDepartmentByCourse(int DepartmentID);
        List<SubjectMasterDataModel_list> GetAllSubjectList(int DepartmentID);
        List<SubjectMasterDataModel>GetSubjectIDWise(int SubjectID);
        bool SaveData(SubjectMasterDataModel request);       
        bool DeleteData(int SubjectID);
        bool IfExists(int DepartmentID,int SubjectID, string SubjectName,int CourseID);


    }
}