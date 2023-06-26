using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ICommonMaster
    {

        List<CommonDataModel_DataTable> GetCommonMasterList();
        List<CommonMasterDataModel> GetCommonMasterIDWise(int ID);
        bool SaveData(CommonMasterDataModel request);
        bool DeleteData(int ID);

        bool IfExists(int ID, int DepartmentID,string Type, string Name);
    }
}

