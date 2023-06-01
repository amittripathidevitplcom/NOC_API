using RJ_NOC_DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IRepositories
    {
      
        ICommonFuncationRepository CommonFuncationRepository { get; }
        IProjectMasterRepository ProjectMasterRepository { get; }
        IEmployeeLoginRepository EmployeeLoginRepository { get; }
        IEmployeeDashboardRepository EmployeeDashboardRepository { get; }
        IUserMasterRepository UserMasterRepository { get; }
        IMenuRepository MenuRepository { get; }
         
    }
}
