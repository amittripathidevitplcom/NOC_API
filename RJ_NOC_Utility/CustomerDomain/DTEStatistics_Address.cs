using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_Address : UtilityBase, IDTEStatistics_Address
    {
        public DTEStatistics_Address(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_AddressDataModel GetByID(int RoleID)
        {
            return UnitOfWork.DTEStatistics_AddressRepository.GetByID(RoleID);
        }
        public bool SaveData(DTEStatistics_AddressDataModel request)
        {
            return UnitOfWork.DTEStatistics_AddressRepository.SaveData(request);
        }
    }
}
