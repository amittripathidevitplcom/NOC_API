using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_OtherMinorityDataModel
    {
        public int? EntryID { get; set; }
        public string EntryDate { get; set; }
        public int? Department { get; set; }
        public int? CollegeID { get; set; }
        public string SelectedCollegeEntryTypeName { get; set; }
        public int? FYearID { get; set; }
        public string EntryType { get; set; }

        public List<DTEStatistics_OtherMinorityDataModel_OtherMinorityDetails>? OtherMinorityDetails { get; set; }

        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int? ModifyBy { get; set; }
    }
    public class DTEStatistics_OtherMinorityDataModel_OtherMinorityDetails
    {
        public int? LevelID { get; set; }
        public string? LevelName { get; set; }
        public string Discipline { get; set; }
        public int? Year { get; set; }
        public int? General_Male { get; set; }
        public int? General_Female { get; set; }
        public int? General_Transgender { get; set; }
        public int? EWS_Male { get; set; }
        public int? EWS_Female { get; set; }
        public int? EWS_Transgender { get; set; }
        public int? SC_Male { get; set; }
        public int? SC_Female { get; set; }
        public int? SC_Transgender { get; set; }
        public int? ST_Male { get; set; }
        public int? ST_Female { get; set; }
        public int? ST_Transgender { get; set; }
        public int? OBC_Male { get; set; }
        public int? OBC_Female { get; set; }
        public int? OBC_Transgender { get; set; }
        public int? Total_Male { get; set; }
        public int? Total_Female { get; set; }
        public int? Total_Transgender { get; set; }
        public string Type { get; set; }
    }
}


