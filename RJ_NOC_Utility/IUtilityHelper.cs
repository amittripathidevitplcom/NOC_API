using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Utility.CustomerDomain;
using RJ_NOC_Utility.CustomerDomain.Interface;

namespace RJ_NOC_Utility
{
    public interface IUtilityHelper
    {
        ICommonFuncation CommonFuncationUtility { get; }
        IProjectMaster ProjectMasterUtility { get; }
        IEmployeeLogin EmployeeLoginUtility { get; }
        IEmployeeDashboard EmployeeDashboardUtility { get; }
        IUserMaster UserMasterUtility { get; }
        ISSOAPI SSOAPIUtility { get; }
        IMenu MenuUtility { get; }
        ICollegeMaster CollegeMasterUtility { get; }

    }
}
