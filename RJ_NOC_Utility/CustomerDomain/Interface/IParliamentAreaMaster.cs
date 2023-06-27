using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IParliamentAreaMaster
    {
        List<CommonDataModel_DataTable> GetParliamentAreaList();
        List<ParliamentAreaMasterDataModel> GetParliamentAreaIDWise(int ParliamentAreaID);
        bool SaveData(ParliamentAreaMasterDataModel request);
        bool DeleteData(int ParliamentAreaID);
        bool IfExists(int ParliamentAreaID, int DistrictID, string ParliamentAreaName);
    }
}
