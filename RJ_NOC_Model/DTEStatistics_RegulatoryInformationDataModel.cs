using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_RegulatoryInformationDataModel
    {
        public int? EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int? Department { get; set; }
        public int? CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int? FYearID { get; set; }

        public string? UniversityHasUploaded { get; set; }
        public string? UniversityIsComplying { get; set; }
        public string? UniversityHadMinimum { get; set; }
        public string? UnderSection { get; set; }
        public string? Date { get; set; } 
         

        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int? ModifyBy { get; set; }
    }

}
