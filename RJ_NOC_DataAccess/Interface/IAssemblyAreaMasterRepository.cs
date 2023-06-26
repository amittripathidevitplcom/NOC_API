using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IAssemblyAreaMasterRepository
    {
        List<CommonDataModel_DataTable> GetAssemblyAreaList();
        List<AssemblyAreaMasterDataModel> GetAssemblyAreaIDWise(int AssemblyAreaID);
        bool SaveData(AssemblyAreaMasterDataModel request);
        bool DeleteData(int AssemblyAreaID);
        bool IfExists(int AssemblyAreaID, int DistrictID, string AssemblyAreaName);
    }

}
