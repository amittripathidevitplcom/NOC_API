using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDefaulterCollegeRequest
    {
        
        List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData();
        List<DefaulterCollegeRequestDataModel> GetByID(int RNCCheckListID);
        bool SaveData(DefaulterCollegeRequestDataModel request);       
        bool DeleteData(int RNCCheckListID);
        bool IfExists(int RNCCheckListID, int DepartmentID, string UniversityName);


    }
}