using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_FinancialDetails : UtilityBase, IDTEStatistics_FinancialDetails
    {
        public DTEStatistics_FinancialDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_FinancialDetailsDataModel GetByID(int RoleID,string EntryType)
        {
            return UnitOfWork.DTEStatistics_FinancialDetailsRepository.GetByID(RoleID, EntryType);
        }
        public DTEStatistics_FinancialDetailsDataModel FinancialDetailsItem(int CollegeID)
        {
            return UnitOfWork.DTEStatistics_FinancialDetailsRepository.FinancialDetailsItem(CollegeID);
        }
        public bool SaveData(DTEStatistics_FinancialDetailsDataModel request)
        {
            return UnitOfWork.DTEStatistics_FinancialDetailsRepository.SaveData(request);
        }
    }
}
