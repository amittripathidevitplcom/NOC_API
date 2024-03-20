using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEStatistics_FinancialDetailsRepository
    {
        DTEStatistics_FinancialDetailsDataModel GetByID(int RoleID, string EntryType);
        DTEStatistics_FinancialDetailsDataModel FinancialDetailsItem(int CollegeID);
        bool SaveData(DTEStatistics_FinancialDetailsDataModel request);
    }

}

