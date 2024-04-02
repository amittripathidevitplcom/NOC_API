using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_StudentEnrollmentDistanceMode
    {
       DTEStatistics_StudentEnrollmentDistanceModeDataModel GetByID(int RoleID, string EntryType);
        bool SaveData(DTEStatistics_StudentEnrollmentDistanceModeDataModel request);
    }
}