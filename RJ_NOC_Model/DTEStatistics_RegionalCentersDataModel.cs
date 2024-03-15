using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_RegionalCentersDataModel
    {
        public int EntryID { get; set; }
        public string EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }

        public string DistanceEducationMode { get; set; }
        public string PrivateExternalProgramme { get; set; }
        public string RegionalCenters { get; set; }

        public List<RegionalCenters_RegionalCentersDetails>? RegionalCentersDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class RegionalCenters_RegionalCentersDetails
    {
        public string NameOfRegionalCenter { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int NoofStudyCenters { get; set; }
    } 
}
