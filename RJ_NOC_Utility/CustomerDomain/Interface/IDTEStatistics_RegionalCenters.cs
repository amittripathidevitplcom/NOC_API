using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_RegionalCenters
    {
       DTEStatistics_RegionalCentersDataModel GetByID(int RoleID);
        bool SaveData(DTEStatistics_RegionalCentersDataModel request);
    }
}