using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_ResidentialFacilityDataModel
    {
        public int EntryID { get; set; }
        public string EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }

        public string IsStaffQuarterAvailable { get; set; }
        public int TeachingStaff { get; set; }
        public int NonTeachingStaff { get; set; }
        public int TotalStaffQuarter { get; set; }
        public string IsStudentsHostelAvailable { get; set; }

        public List<ResidentialFacility_HostelDetailsDataModel>? HostelDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class ResidentialFacility_HostelDetailsDataModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int ResidingStudents { get; set; }
    }


}
