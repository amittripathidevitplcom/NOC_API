using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IUniversityMaster
    {
        
        List<UniversityasterDataModel_list> GetAllUniversityList(int DepartmentID);
        List<UniversityasterDataModel> GetUniversityIDWise(int UniversityID);
        bool SaveData(UniversityasterDataModel request);       
        bool DeleteData(int UniversityID);
        bool IfExists(int UniversityID, string UniversityName);


    }
}