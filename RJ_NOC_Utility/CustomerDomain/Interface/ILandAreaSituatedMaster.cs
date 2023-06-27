using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ILandAreaSituatedMaster
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