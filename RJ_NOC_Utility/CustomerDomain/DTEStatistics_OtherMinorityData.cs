using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_OtherMinorityData : UtilityBase, IDTEStatistics_OtherMinorityData
    {
        public DTEStatistics_OtherMinorityData(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_OtherMinorityDataModel GetByID(int RoleID, string EntryType)
        {
            return UnitOfWork.DTEStatistics_OtherMinorityDataRepository.GetByID(RoleID, EntryType);
        }
        public bool SaveData(DTEStatistics_OtherMinorityDataModel request)
        {
            return UnitOfWork.DTEStatistics_OtherMinorityDataRepository.SaveData(request);
        }
    }
}
