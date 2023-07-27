using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IFacilitiesMasterRepository
    {
        List<FacilitiesMasterDataModel_list> GetAllFacilitiesList(int DepartmentID);
        List<FacilitiesMasterDataModel> GetFacilitiesIDWise(int FID);
        bool SaveData(FacilitiesMasterDataModel request);       
        bool DeleteData(int FID);
        bool IfExists(int FID,int DepartmentID, string FacilitiesName);
      

    }

}

