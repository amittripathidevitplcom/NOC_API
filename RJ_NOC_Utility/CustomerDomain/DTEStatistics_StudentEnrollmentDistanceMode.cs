using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DTEStatistics_StudentEnrollmentDistanceMode : UtilityBase, IDTEStatistics_StudentEnrollmentDistanceMode
    {
        public DTEStatistics_StudentEnrollmentDistanceMode(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public DTEStatistics_StudentEnrollmentDistanceModeDataModel GetByID(int RoleID,string EntryType)
        {
            return UnitOfWork.DTEStatistics_StudentEnrollmentDistanceModeRepository.GetByID(RoleID, EntryType);
        }
        public bool SaveData(DTEStatistics_StudentEnrollmentDistanceModeDataModel request)
        {
            return UnitOfWork.DTEStatistics_StudentEnrollmentDistanceModeRepository.SaveData(request);
        }
    }
}
