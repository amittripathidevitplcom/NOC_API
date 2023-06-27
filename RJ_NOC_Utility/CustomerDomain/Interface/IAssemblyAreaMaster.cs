using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IAssemblyAreaMaster
    {
        List<CommonDataModel_DataTable> GetAssemblyAreaList();
        List<AssemblyAreaMasterDataModel> GetAssemblyAreaIDWise(int AssemblyAreaID);
        bool SaveData(AssemblyAreaMasterDataModel request);
        bool DeleteData(int AssemblyAreaID);
        bool IfExists(int AssemblyAreaID, int DistrictID, string AssemblyAreaName);
    }
}
