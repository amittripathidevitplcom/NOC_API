using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_InfrastructureDetailsDataModel
    {
        public int EntryID { get; set; }
        public string EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }
        public string EntryType { get; set; }

        public List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails>? InfrastructureDetails_A { get; set; }
        public List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails>? InfrastructureDetails_B { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails
    {
        public string FID { get; set; }
        public string EntryType { get; set; }
        public string SNoText { get; set; }
        public string Item { get; set; }
        public string Value { get; set; }
    }
}


