using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IFacilitiesMaster
    {
        
        List<FacilitiesMasterDataModel_list> GetAllFacilitiesList(int DepartmentID);
        List<FacilitiesMasterDataModel> GetFacilitiesIDWise(int FID);
        bool SaveData(FacilitiesMasterDataModel request);       
        bool DeleteData(int FID);
        bool IfExists(int FID,int DepartmentID, string FacilitiesName);


    }
}