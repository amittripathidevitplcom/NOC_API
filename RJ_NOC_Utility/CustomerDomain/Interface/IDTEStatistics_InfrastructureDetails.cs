using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_InfrastructureDetails
    {
       DTEStatistics_InfrastructureDetailsDataModel GetByID(int RoleID, string EntryType);
       DTEStatistics_InfrastructureDetailsDataModel InfrastructureDetailsItem(int CollegeID);
        bool SaveData(DTEStatistics_InfrastructureDetailsDataModel request);
    }
}