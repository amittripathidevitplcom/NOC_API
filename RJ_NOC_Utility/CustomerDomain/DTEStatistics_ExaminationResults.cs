using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_ExaminationResults : UtilityBase, IDTEStatistics_ExaminationResults
    {
        public DTEStatistics_ExaminationResults(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_ExaminationResultsDataModel GetByID(int RoleID,string EntryType)
        {
            return UnitOfWork.DTEStatistics_ExaminationResultsRepository.GetByID(RoleID, EntryType);
        }
        public bool SaveData(DTEStatistics_ExaminationResultsDataModel request)
        {
            return UnitOfWork.DTEStatistics_ExaminationResultsRepository.SaveData(request);
        }
    }
}
