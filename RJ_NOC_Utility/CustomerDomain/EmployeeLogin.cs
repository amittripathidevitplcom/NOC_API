using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class EmployeeLogin : UtilityBase, IEmployeeLogin
    {
        public EmployeeLogin(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        List<EmployeeLoginDataModel> IEmployeeLogin.EmployeeLogin(string LoginID, string Password)
        {
            return UnitOfWork.EmployeeLoginRepository.EmployeeLogin(LoginID, Password);
        }
    }
}
