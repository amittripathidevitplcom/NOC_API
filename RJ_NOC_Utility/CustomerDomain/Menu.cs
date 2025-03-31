using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class Menu : UtilityBase, IMenu
    {
        public Menu(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<MenuDataModel_List> GetAllMenu()
        {
            return UnitOfWork.MenuRepository.GetAllMenu();
        }
        public List<MenuDataModel_List> GetUserWiseMenu(int UserID,string SSOID)
        {
            return UnitOfWork.MenuRepository.GetUserWiseMenu(UserID, SSOID);
        }
        public List<MenuDataModel> GetMenuIDWise(int AccountID)
        {
            return UnitOfWork.MenuRepository.GetMenuIDWise(AccountID);
        }
        public bool SaveData(MenuDataModel request)
        {
            return UnitOfWork.MenuRepository.SaveData(request);
        }
        public bool UpdateData(MenuDataModel request)
        {
            return UnitOfWork.MenuRepository.UpdateData(request);
        }
        public bool DeleteData(int AccountID)
        {
            return UnitOfWork.MenuRepository.DeleteData(AccountID);
        }

        public bool IfExists(int AccountID, string GroupName)
        {
            return UnitOfWork.MenuRepository.IfExists(AccountID, GroupName);
        }
        public List<UserRoleRightsDataModel> GetAllMenuUserRoleRightsRoleWise(int RoleID)
        {
            return UnitOfWork.MenuRepository.GetAllMenuUserRoleRightsRoleWise(RoleID);
        }
        public List<MenuModel> GetUserWiseMenuNew(int UserId)
        {
            return UnitOfWork.MenuRepository.GetUserWiseMenuNew(UserId);
        }
        public List<MenuModel> list1 = new List<MenuModel>();
        public List<MenuModel> GetUserAllMenu(int UserId)
        {
            List<MenuModel> menuItems = new List<MenuModel>();
            List<MenuModel> menu = new List<MenuModel>();
            menu = UnitOfWork.MenuRepository.GetUserWiseMenuNew(UserId);
            Dictionary<int, MenuModel> menuItemMap = new Dictionary<int, MenuModel>();
            foreach (var item in menu)
            {
                MenuModel menuItem = new MenuModel { MenuId = item.MenuId, name = item.name,ParentId=item.ParentId,icon=item.icon};
                if (!menuItemMap.ContainsKey(item.MenuId))
                {
                    menuItem.type = "link";
                    menuItemMap.Add(item.MenuId, menuItem);
                }
                if (menuItemMap.ContainsKey(item.ParentId))
                {
                    MenuModel parent = menuItemMap[item.ParentId];
                    if (parent.sub == null)
                    {
                        parent.sub = new List<MenuModel>();
                    }
                    parent.type= "dropDown";
                    parent.sub.Add(menuItem);
                }
                else
                {
                    menuItems.Add(menuItem);
                }

            }
            return menuItems;
        }
    }
}

