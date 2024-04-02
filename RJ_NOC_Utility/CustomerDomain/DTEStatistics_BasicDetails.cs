using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_BasicDetails : UtilityBase, IDTEStatistics_BasicDetails
    {
        public DTEStatistics_BasicDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_BasicDetailsDataModel GetByID(int CollegeID)
        {
            return UnitOfWork.DTEStatistics_BasicDetailsRepository.GetByID(CollegeID);
        }
        public bool SaveData(DTEStatistics_BasicDetailsDataModel request)
        {
            return UnitOfWork.DTEStatistics_BasicDetailsRepository.SaveData(request);
        }
    }
}
