using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_RegularModeDataModel
    {
        public int? EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int? Department { get; set; }
        public int? CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int? FYearID { get; set; }
        public string? EntryType { get; set; }

        public List<DTEStatistics_RegularModeDataModel_ProgrammesDetails>? ProgrammesDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int? ModifyBy { get; set; }
    }
    public class DTEStatistics_RegularModeDataModel_ProgrammesDetails
    {
        public string? Faculty_School { get; set; }
        public string? Department_Centre { get; set; }
        public int? LevelID { get; set; }
        public string? LevelName { get; set; }
        public int? ProgrammeID { get; set; }
        public string? NameOfTheProgramme { get; set; }
        public string? BroadDisciplineGroupCategory { get; set; }
        public string? BroadDisciplineGroupName { get; set; }
        public string? Discipline { get; set; }
        public string? AdmissionCriterion { get; set; }
        public string? ExaminationSystem { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? ApprovedIntake { get; set; }
        public string? Type { get; set; }
        public string? WhetherVocationalCourse { get; set; }
        public string? YearofStart { get; set; }
        public string? AccreditationStatus { get; set; }
    }
}


