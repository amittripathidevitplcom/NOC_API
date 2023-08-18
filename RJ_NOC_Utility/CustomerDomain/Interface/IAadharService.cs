using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IAadharService
    {
        DataTable SendOtpByAadharNo(CommonDataModel_AadharDataModel modal, IConfiguration _configuration);
        DataTable ValidateAadhaarOTP(CommonDataModel_AadharDataModel modal, IConfiguration _configuration);
        string GetAadharByVID(CommonDataModel_AadharDataModel modal, IConfiguration _configuration);
    }
}