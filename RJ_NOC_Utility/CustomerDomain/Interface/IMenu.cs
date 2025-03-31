using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IMenu
    {
        List<MenuDataModel_List> GetAllMenu();
        List<MenuDataModel_List> GetUserWiseMenu(int UserID,string SSOID);
        List<MenuDataModel> GetMenuIDWise(int AccountID);
        bool SaveData(MenuDataModel request);
        bool UpdateData(MenuDataModel request);
        bool DeleteData(int AccountID);

        bool IfExists(int AccountID, string GroupName);
        List<UserRoleRightsDataModel> GetAllMenuUserRoleRightsRoleWise(int RoleID);

        List<MenuModel> GetUserAllMenu(int UserId);
        List<MenuModel> GetUserWiseMenuNew(int UserID);

    }
}


