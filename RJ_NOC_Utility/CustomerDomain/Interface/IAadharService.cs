using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IAadharService
    {
        CommonDataModel_DataTable SendOtpByAadharNo(CommonDataModel_AadharDataModel modal, IConfiguration _configuration);
      //  CommonDataModel_AadharDataModel VerifyAadhaarOTP(CommonDataModel_AadharDataModel modal);
    }
}