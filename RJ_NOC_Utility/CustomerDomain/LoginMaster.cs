using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class LoginMaster : UtilityBase, ILoginMaster
    {
        public LoginMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        List<LoginMasterDataModel> ILoginMaster.Login(string UserName, string Password)
        {
            return UnitOfWork.LoginMasterRepository.Login(UserName, Password);
        }
    }
}
