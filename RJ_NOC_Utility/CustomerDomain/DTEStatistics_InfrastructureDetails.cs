using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_InfrastructureDetails : UtilityBase, IDTEStatistics_InfrastructureDetails
    {
        public DTEStatistics_InfrastructureDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_InfrastructureDetailsDataModel GetByID(int RoleID,string EntryType)
        {
            return UnitOfWork.DTEStatistics_InfrastructureDetailsRepository.GetByID(RoleID, EntryType);
        }
        public DTEStatistics_InfrastructureDetailsDataModel InfrastructureDetailsItem(int CollegeID)
        {
            return UnitOfWork.DTEStatistics_InfrastructureDetailsRepository.InfrastructureDetailsItem(CollegeID);
        }
        public bool SaveData(DTEStatistics_InfrastructureDetailsDataModel request)
        {
            return UnitOfWork.DTEStatistics_InfrastructureDetailsRepository.SaveData(request);
        }
    }
}
