using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_FacultyDataModel
    {
        public int EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }

        public List<Faculty_FacultyDetails>? FacultyDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class Faculty_FacultyDetails
    {
        public string? NameofFaculty { get; set; }
    }
}


