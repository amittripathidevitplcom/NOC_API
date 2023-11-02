using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface ILOIFeeMasterRepository
    {
        List<CommonDataModel_DataTable> GetAllLOIFeeList();
        List<LOIFeeMasterDataModel> GetLOIFeeByID(int FeeID);
        bool SaveData(LOIFeeMasterDataModel request);       
        bool DeleteData(int FeeID);
        bool IfExists(int FeeID, int DepartmentID, string FeeType);
      

    }

}

