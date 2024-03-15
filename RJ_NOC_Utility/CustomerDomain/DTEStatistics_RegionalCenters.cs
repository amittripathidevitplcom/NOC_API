using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_RegionalCenters : UtilityBase, IDTEStatistics_RegionalCenters
    {
        public DTEStatistics_RegionalCenters(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_RegionalCentersDataModel GetByID(int RoleID)
        {
            return UnitOfWork.DTEStatistics_RegionalCentersRepository.GetByID(RoleID);
        }
        public bool SaveData(DTEStatistics_RegionalCentersDataModel request)
        {
            return UnitOfWork.DTEStatistics_RegionalCentersRepository.SaveData(request);
        }
    }
}
