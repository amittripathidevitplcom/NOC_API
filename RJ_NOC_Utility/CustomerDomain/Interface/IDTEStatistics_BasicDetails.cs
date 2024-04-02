using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_BasicDetails
    {
        DTEStatistics_BasicDetailsDataModel GetByID(int CollegeID);
        bool SaveData(DTEStatistics_BasicDetailsDataModel request);
    }
}