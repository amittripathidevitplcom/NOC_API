using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDTEStatistics_ScholarshipFellowshipLoanAcc
    {
       DTEStatistics_ScholarshipFellowshipLoanAccDataModel GetByID(int RoleID, string EntryType);
       DTEStatistics_ScholarshipFellowshipLoanAccDataModel ScholarshipFellowshipLoanAccItem(int CollegeID);
        bool SaveData(DTEStatistics_ScholarshipFellowshipLoanAccDataModel request);
    }
}