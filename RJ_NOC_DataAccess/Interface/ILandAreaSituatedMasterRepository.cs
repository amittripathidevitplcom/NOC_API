using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface ILandAreaSituatedMasterRepository
    {
        List<LandAreaSituated_DistrictList> GetDistrictList();
        List<LandAreaSituatedModel_StateList> GetStateList();
        List<LandAreaSituatedMasterDataModel_list> GetAllLandAreaSituatedList();
        List<LandAreaSituatedMasterDataModel> GetLandAreaSituatedIDWise(int LandAreaID);
        bool SaveData(LandAreaSituatedMasterDataModel request);       
        bool DeleteData(int LandAreaID);
        bool IfExists(int LandAreaID, string LandAreaName);
      

    }

}

