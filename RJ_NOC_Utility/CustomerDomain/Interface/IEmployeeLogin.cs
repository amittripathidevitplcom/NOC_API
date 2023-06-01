using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IEmployeeLogin
    {
        List<EmployeeLoginDataModel> EmployeeLogin(string LoginID, string Password);

    }
}