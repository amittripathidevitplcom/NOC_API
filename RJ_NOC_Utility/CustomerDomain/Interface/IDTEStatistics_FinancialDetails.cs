using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_FinancialDetails
    {
       DTEStatistics_FinancialDetailsDataModel GetByID(int RoleID, string EntryType);
       DTEStatistics_FinancialDetailsDataModel FinancialDetailsItem(int CollegeID);
        bool SaveData(DTEStatistics_FinancialDetailsDataModel request);
    }
}