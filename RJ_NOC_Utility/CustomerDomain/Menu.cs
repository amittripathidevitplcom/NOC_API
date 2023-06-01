using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace FIH_EPR_Utility.CustomerDomain
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
        public List<MenuDataModel_List> GetUserWiseMenu(int UserID)
        {
            return UnitOfWork.MenuRepository.GetUserWiseMenu(UserID);
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

    }
}

