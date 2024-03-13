using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEStatistics_OfficersDetailsRepository
    {
        DTEStatistics_OfficersDetailsDataModel GetByID(int RoleID);
        bool SaveData(DTEStatistics_OfficersDetailsDataModel request);
    }

}

