using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class AddRoleMaster : UtilityBase, IAddRoleMaster
    {
        public AddRoleMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetList()
        {
            return UnitOfWork.AddRoleMasterRepository.GetList();
        }
        public List<AddRoleMasterDataModel> GetByID(int RoleID)
        {
            return UnitOfWork.AddRoleMasterRepository.GetByID(RoleID);
        }
        public bool SaveData(AddRoleMasterDataModel request)
        {
            return UnitOfWork.AddRoleMasterRepository.SaveData(request);
        }
        public bool DeleteData(int RoleID)
        {
            return UnitOfWork.AddRoleMasterRepository.DeleteData(RoleID);
        }

        public bool IfExists(int RoleID, string RoleName)
        {
            return UnitOfWork.AddRoleMasterRepository.IfExists(RoleID, RoleName);
        }


    }
}
