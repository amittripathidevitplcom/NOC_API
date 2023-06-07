using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Repositories;

namespace RJ_NOC_DataAccess.Repository
{
    public class CoreRepositories : IRepositories
    {

        protected CommonDataAccessHelper CommonHelper { get; set; }
        public CoreRepositories(IConfiguration configuration)
        {
            CommonHelper = new CommonDataAccessHelper(configuration);
            IntializeRepositories(CommonHelper);
        }




        private ICommonFuncationRepository commonFuncationRepository;
        public ICommonFuncationRepository CommonFuncationRepository
        {
            get { return commonFuncationRepository; }
        }
        private IProjectMasterRepository projectMasterRepository;
        public IProjectMasterRepository ProjectMasterRepository
        {
            get { return projectMasterRepository; }
        }

        private IEmployeeLoginRepository employeeLoginRepository;
        public IEmployeeLoginRepository EmployeeLoginRepository
        {
            get { return employeeLoginRepository; }
        }


        private IEmployeeDashboardRepository employeeDashboardRepository;
        public IEmployeeDashboardRepository EmployeeDashboardRepository
        {
            get { return employeeDashboardRepository; }
        }


        private IUserMasterRepository userMasterRepository;
        public IUserMasterRepository UserMasterRepository
        {
            get { return userMasterRepository; }
        }

        private IMenuRepository menuRepository;
        public IMenuRepository MenuRepository
        {
            get { return menuRepository; }
        }

        private ICollegeMasterRepository _collegeMasterRepository;
        public ICollegeMasterRepository CollegeMasterRepository
        {
            get
            {
                if (_collegeMasterRepository == null)
                    _collegeMasterRepository = new CollegeMasterRepository(CommonHelper);
                return _collegeMasterRepository;    
            }
        }

        private ILegalEntityRepoSitory legalEntityRepoSitory;
        public ILegalEntityRepoSitory LegalEntityRepoSitory
        {
            get { return legalEntityRepoSitory; }
        }

        private ICourseMasterRepository courseMasterRepository;
        public ICourseMasterRepository CourseMasterRepository
        {
            get { return courseMasterRepository; }
        }

        private IWorkFlowMasterRepository workFlowMasterRepository;
        public IWorkFlowMasterRepository WorkFlowMasterRepository
        {
            get { return workFlowMasterRepository; }
        }

        public void IntializeRepositories(CommonDataAccessHelper commonHelper)
        {
            commonFuncationRepository = new CommonFuncationRepository(commonHelper);
            projectMasterRepository = new ProjectMasterRepository(commonHelper);
            legalEntityRepoSitory = new LegalEntityRepository(commonHelper);
            employeeLoginRepository = new EmployeeLoginRepository(commonHelper);
            employeeDashboardRepository = new EmployeeDashboardRepository(commonHelper);
            userMasterRepository = new UserMasterRepository(commonHelper);
            menuRepository = new MenuRepository(commonHelper);
            workFlowMasterRepository = new WorkFlowMasterRepository(commonHelper);
            courseMasterRepository = new CourseMasterRepository(commonHelper);


        }
    }
}
