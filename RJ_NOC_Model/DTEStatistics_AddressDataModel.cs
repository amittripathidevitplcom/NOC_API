using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_AddressDataModel
    {
        public int? EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int? Department { get; set; }
        public int? CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int? FYearID { get; set; }


        public string? Country { get; set; }
        public string? State { get; set; }
        public int? DistrictID { get; set; }
        public int? RuralUrban { get; set; }
        public int? TehsilID { get; set; }
        public int? CityID { get; set; }
        public string? PinCode { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? TotalArea { get; set; }
        public string? TotalConstructedArea { get; set; }
        public string? Website { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int? ModifyBy { get; set; }
    }

}
