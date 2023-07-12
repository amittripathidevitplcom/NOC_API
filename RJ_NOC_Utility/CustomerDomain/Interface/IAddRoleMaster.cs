using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IAddRoleMaster
    {

        List<CommonDataModel_DataTable> GetList();
        List<AddRoleMasterDataModel> GetByID(int RoleID);
        bool SaveData(AddRoleMasterDataModel request);
        bool DeleteData(int RoleID);
        bool IfExists(int RoleID, string RoleName);

        bool SaveUserRoleRight(List<UserRoleRightsDataModel> request);
    }
}