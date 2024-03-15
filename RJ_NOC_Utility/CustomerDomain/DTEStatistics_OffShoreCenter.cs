using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_OffShoreCenter : UtilityBase, IDTEStatistics_OffShoreCenter
    {
        public DTEStatistics_OffShoreCenter(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_OffShoreCenterDataModel GetByID(int RoleID)
        {
            return UnitOfWork.DTEStatistics_OffShoreCenterRepository.GetByID(RoleID);
        }
        public bool SaveData(DTEStatistics_OffShoreCenterDataModel request)
        {
            return UnitOfWork.DTEStatistics_OffShoreCenterRepository.SaveData(request);
        }
    }
}
