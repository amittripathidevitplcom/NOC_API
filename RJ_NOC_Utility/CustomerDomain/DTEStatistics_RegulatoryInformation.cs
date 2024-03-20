using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_RegulatoryInformation : UtilityBase, IDTEStatistics_RegulatoryInformation
    {
        public DTEStatistics_RegulatoryInformation(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_RegulatoryInformationDataModel GetByID(int RoleID)
        {
            return UnitOfWork.DTEStatistics_RegulatoryInformationRepository.GetByID(RoleID);
        }
        public bool SaveData(DTEStatistics_RegulatoryInformationDataModel request)
        {
            return UnitOfWork.DTEStatistics_RegulatoryInformationRepository.SaveData(request);
        }
    }
}
