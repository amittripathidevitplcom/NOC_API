using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IEmployeeLoginRepository
    {
        List<EmployeeLoginDataModel> EmployeeLogin(string LoginID, string Password);



    }

}

