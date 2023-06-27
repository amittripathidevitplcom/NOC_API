using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IAddRoleMasterRepository
    {
        List<CommonDataModel_DataTable> GetList();
        List<AddRoleMasterDataModel> GetByID(int RoleID);
        bool SaveData(AddRoleMasterDataModel request);
        bool DeleteData(int RoleID);
        bool IfExists(int RoleID, string RoleName);


    }

}

