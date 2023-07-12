using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IMenuRepository
    {
        List<MenuDataModel_List> GetAllMenu();
        List<MenuDataModel_List> GetUserWiseMenu(int UserID);

        List<MenuDataModel> GetMenuIDWise(int AccountID);
        bool SaveData(MenuDataModel request);
        bool UpdateData(MenuDataModel request);
        bool DeleteData(int AccountID);

        bool IfExists(int AccountID, string GroupName);
        List<UserRoleRightsDataModel> GetAllMenuUserRoleRightsRoleWise(int RoleID);
    }

}

