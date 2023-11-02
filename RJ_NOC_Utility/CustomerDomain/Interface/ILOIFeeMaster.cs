using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ILOIFeeMaster
    {
        List<CommonDataModel_DataTable> GetAllLOIFeeList();
        List<LOIFeeMasterDataModel> GetLOIFeeByID(int FeeID);
        bool SaveData(LOIFeeMasterDataModel request);       
        bool DeleteData(int FeeID);
        bool IfExists(int FeeID, int DepartmentID, string FeeType);


    }
}