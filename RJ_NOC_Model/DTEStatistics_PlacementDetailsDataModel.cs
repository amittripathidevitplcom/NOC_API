using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_PlacementDetailsDataModel
    {
        public int EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }
        public string? EntryType { get; set; }

        public List<DTEStatistics_PlacementDetailsDataModel_PlacementDetails>? PlacementDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class DTEStatistics_PlacementDetailsDataModel_PlacementDetails
    {
        public int NoOfStudentsPlaced_Male { get; set; }
        public int NoOfStudentsPlaced_Female { get; set; }
        public int NoOfStudentsPlaced_Total { get; set; }
        public int NoOfStudentsSelectedForHigherStudies_Male { get; set; }
        public int NoOfStudentsSelectedForHigherStudies_Female { get; set; }
        public int NoOfStudentsSelectedForHigherStudies_Total { get; set; }
        public decimal MedianAnnualSalaryforPlacedStudents { get; set; }
    }
}


