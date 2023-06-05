using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Utility.CustomerDomain;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using FIH_EPR_Utility.CustomerDomain;

namespace RJ_NOC_Utility
{
    public class UtilityHelper : IUtilityHelper
    {

        // utilities
        public IRepositories UnitOfWork;

        public ICommonFuncation CommonFuncationUtility { get; private set; }
        public IProjectMaster ProjectMasterUtility { get; private set; }
        public ILegalEntity LegalEntity { get; private set; }
        public IEmployeeLogin EmployeeLoginUtility { get; private set; }
        public IEmployeeDashboard EmployeeDashboardUtility { get; private set; }
        public IUserMaster UserMasterUtility { get; private set; }
        public ISSOAPI SSOAPIUtility { get; private set; }
        public IMenu MenuUtility { get; private set; }
        public ICourseMaster CourseMasterUtility { get; private set; }
        public IWorkFlowMaster WorkFlowMasterUtility { get; private set; }

        public UtilityHelper(IConfiguration configuration)
        {
            UnitOfWork = new CoreRepositories(configuration);
            InitializeUtilities();
        }
        public void InitializeUtilities()
        {
            CommonFuncationUtility = new CommonFuncation(UnitOfWork);
            ProjectMasterUtility = new ProjectMaster(UnitOfWork);
            LegalEntity = new LegalEntity(UnitOfWork);
            EmployeeLoginUtility = new EmployeeLogin(UnitOfWork);
            EmployeeDashboardUtility = new EmployeeDashboard(UnitOfWork);
            UserMasterUtility = new UserMaster(UnitOfWork);
            SSOAPIUtility = new SSOAPI(UnitOfWork);
            MenuUtility = new Menu(UnitOfWork);
            CourseMasterUtility = new CourseMaster(UnitOfWork);
            WorkFlowMasterUtility = new WorkFlowMaster(UnitOfWork);

        }
    }
}
