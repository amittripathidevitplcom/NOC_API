using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_Department : UtilityBase, IDTEStatistics_Department
    {
        public DTEStatistics_Department(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_DepartmentDataModel GetByID(int RoleID)
        {
            return UnitOfWork.DTEStatistics_DepartmentRepository.GetByID(RoleID);
        }
        public bool SaveData(DTEStatistics_DepartmentDataModel request)
        {
            return UnitOfWork.DTEStatistics_DepartmentRepository.SaveData(request);
        }
    }
}
