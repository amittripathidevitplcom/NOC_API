using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_PlacementDetails
    {
       DTEStatistics_PlacementDetailsDataModel GetByID(int RoleID, string EntryType);
        bool SaveData(DTEStatistics_PlacementDetailsDataModel request);
    }
}