using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_OfficersDetails : UtilityBase, IDTEStatistics_OfficersDetails
    {
        public DTEStatistics_OfficersDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_OfficersDetailsDataModel GetByID(int RoleID)
        {
            return UnitOfWork.DTEStatistics_OfficersDetailsRepository.GetByID(RoleID);
        }
        public bool SaveData(DTEStatistics_OfficersDetailsDataModel request)
        {
            return UnitOfWork.DTEStatistics_OfficersDetailsRepository.SaveData(request);
        }
    }
}
