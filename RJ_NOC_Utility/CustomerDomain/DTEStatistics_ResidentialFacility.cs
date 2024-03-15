using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_ResidentialFacility : UtilityBase, IDTEStatistics_ResidentialFacility
    {
        public DTEStatistics_ResidentialFacility(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_ResidentialFacilityDataModel GetByID(int RoleID)
        {
            return UnitOfWork.DTEStatistics_ResidentialFacilityRepository.GetByID(RoleID);
        }
        public bool SaveData(DTEStatistics_ResidentialFacilityDataModel request)
        {
            return UnitOfWork.DTEStatistics_ResidentialFacilityRepository.SaveData(request);
        }
    }
}
