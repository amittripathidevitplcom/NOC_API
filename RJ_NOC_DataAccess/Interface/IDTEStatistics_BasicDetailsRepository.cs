using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEStatistics_BasicDetailsRepository
    {
        DTEStatistics_BasicDetailsDataModel GetByID(int CollegeID);
        bool SaveData(DTEStatistics_BasicDetailsDataModel request);
    }

}

