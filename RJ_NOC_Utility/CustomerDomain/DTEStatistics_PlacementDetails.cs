using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_PlacementDetails : UtilityBase, IDTEStatistics_PlacementDetails
    {
        public DTEStatistics_PlacementDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_PlacementDetailsDataModel GetByID(int RoleID,string EntryType)
        {
            return UnitOfWork.DTEStatistics_PlacementDetailsRepository.GetByID(RoleID, EntryType);
        }
        public bool SaveData(DTEStatistics_PlacementDetailsDataModel request)
        {
            return UnitOfWork.DTEStatistics_PlacementDetailsRepository.SaveData(request);
        }
    }
}
