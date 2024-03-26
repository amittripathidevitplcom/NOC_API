using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;


namespace RJ_NOC_DataAccess.Interface
{
    public interface IDTEStatistics_ScholarshipFellowshipLoanAccRepository
    {
        DTEStatistics_ScholarshipFellowshipLoanAccDataModel GetByID(int RoleID, string EntryType);
        DTEStatistics_ScholarshipFellowshipLoanAccDataModel ScholarshipFellowshipLoanAccItem(int CollegeID);
        bool SaveData(DTEStatistics_ScholarshipFellowshipLoanAccDataModel request);
    }

}

