using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace FIH_EPR_Utility.CustomerDomain
{
    public class UserMaster : UtilityBase, IUserMaster
    {
        public UserMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        List<UserMasterDataModel> IUserMaster.Login(string LoginID, string Password)
        {
            return UnitOfWork.UserMasterRepository.Login(LoginID, Password);
        }
    }
}
