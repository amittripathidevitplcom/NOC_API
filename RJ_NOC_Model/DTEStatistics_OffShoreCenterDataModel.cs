using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_OffShoreCenterDataModel
    {
        public int EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }

        public int NumberOfOffShoreCenter { get; set; }

        public List<OffShoreCenter_OffShoreCenterDetails>? OffShoreCenterDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class OffShoreCenter_OffShoreCenterDetails
    {
        public string? NameOffShoreCenter { get; set; }
        public string? Country { get; set; }
        public string? StudyMode { get; set; }
        public int TotalEnrolledStudents { get; set; }
        public int TotalEnrolledGirlsStudents { get; set; }
    }
}
