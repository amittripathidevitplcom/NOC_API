using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IRNCCheckListMasterRepository
    {
        List<CommonDataModel_DataTable> GetRNCCheckListData();
        List<RNCCheckListMasterDataModel> GetByID(int RNCCheckListID);
        bool SaveData(RNCCheckListMasterDataModel request);       
        bool DeleteData(int RNCCheckListID);
        bool IfExists(int RNCCheckListID,int DepartmentID, string UniversityName);
      

    }

}

