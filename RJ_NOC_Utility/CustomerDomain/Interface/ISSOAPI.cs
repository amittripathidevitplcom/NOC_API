using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ISSOAPI
    {
        Task<SSOUserDetailData> GetSSOUserLogionDetails(string SSOID,string LoginType, IConfiguration _configuration);

        List<CommonDataModel_DataTable> Check_SSOIDWise_LegalEntity(string SSOID);
    }
}