using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ILoginMaster
    {
        List<LoginMasterDataModel> Login(string UserName, string Password);
    }
}