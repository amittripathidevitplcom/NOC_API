using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IUniversityMasterRepository
    {
        List<UniversityasterDataModel_list> GetAllUniversityList(int DepartmentID);
        List<UniversityasterDataModel> GetUniversityIDWise(int UniversityID);
        bool SaveData(UniversityasterDataModel request);       
        bool DeleteData(int UniversityID);
        bool IfExists(int UniversityID, string UniversityName);
      

    }

}

