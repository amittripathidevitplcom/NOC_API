using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IParliamentAreaMasterRepository
    {
        List<CommonDataModel_DataTable> GetParliamentAreaList();
        List<ParliamentAreaMasterDataModel> GetParliamentAreaIDWise(int ParliamentAreaID);
        bool SaveData(ParliamentAreaMasterDataModel request);
        bool DeleteData(int ParliamentAreaID);
        bool IfExists(int ParliamentAreaID, int DistrictID, string ParliamentAreaName);
    }

}