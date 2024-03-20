using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEStatistics_InfrastructureDetailsRepository
    {
        DTEStatistics_InfrastructureDetailsDataModel GetByID(int RoleID, string EntryType);
        DTEStatistics_InfrastructureDetailsDataModel InfrastructureDetailsItem(int CollegeID);
        bool SaveData(DTEStatistics_InfrastructureDetailsDataModel request);
    }

}

