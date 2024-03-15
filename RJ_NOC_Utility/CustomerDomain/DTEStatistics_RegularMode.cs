using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_RegularMode : UtilityBase, IDTEStatistics_RegularMode
    {
        public DTEStatistics_RegularMode(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_RegularModeDataModel GetByID(int RoleID,string EntryType)
        {
            return UnitOfWork.DTEStatistics_RegularModeRepository.GetByID(RoleID, EntryType);
        }
        public bool SaveData(DTEStatistics_RegularModeDataModel request)
        {
            return UnitOfWork.DTEStatistics_RegularModeRepository.SaveData(request);
        }
    }
}
