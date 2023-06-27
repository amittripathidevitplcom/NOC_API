using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ICommonMasterRepository
    {
        List<CommonDataModel_DataTable> GetCommonMasterList();
        List<CommonMasterDataModel> GetCommonMasterIDWise(int ID);
        bool SaveData(CommonMasterDataModel request);
        bool DeleteData(int ID);
        bool IfExists(int ID, int DepartmentID,string Type, string Name);
    }

}