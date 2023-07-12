using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IRNCCheckListMaster
    {
        
        List<CommonDataModel_DataTable> GetRNCCheckListData();
        List<RNCCheckListMasterDataModel> GetByID(int RNCCheckListID);
        bool SaveData(RNCCheckListMasterDataModel request);       
        bool DeleteData(int RNCCheckListID);
        bool IfExists(int RNCCheckListID, int DepartmentID, string UniversityName);


    }
}