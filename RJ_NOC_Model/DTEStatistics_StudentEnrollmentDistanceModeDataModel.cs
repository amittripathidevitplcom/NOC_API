using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_StudentEnrollmentDistanceModeDataModel
    {
        public int EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }
        public string? EntryType { get; set; }

        public List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_ProgrammesDetails>? ProgrammesDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class DTEStatistics_StudentEnrollmentDistanceModeDataModel_ProgrammesDetails
    {
        public int AID { get; set; }
        public string? Faculty_School { get; set; }
        public string? Department_Centre { get; set; }
        public int LevelID { get; set; }
        public string? LevelName { get; set; }
        public string? Discipline { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public string? Category { get; set; }
        public int GeneralCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int GeneralCategoryMale { get; set; }
        public int GeneralCategoryFemale { get; set; }
        public int GeneralCategoryTransGender { get; set; }

        public int EWSCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int EWSCategoryMale { get; set; }
        public int EWSCategoryFemale { get; set; }
        public int EWSCategoryTransGender { get; set; }

        public int SCCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int SCCategoryMale { get; set; }
        public int SCCategoryFemale { get; set; }
        public int SCCategoryTransGender { get; set; }

        public int STCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int STCategoryMale { get; set; }
        public int STCategoryFemale { get; set; }
        public int STCategoryTransGender { get; set; }

        public int OBCCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int OBCCategoryMale { get; set; }
        public int OBCCategoryFemale { get; set; }
        public int OBCCategoryTransGender { get; set; }

        public int TotalCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int TotalCategoryMale { get; set; }
        public int TotalCategoryFemale { get; set; }
        public int TotalCategoryTransGender { get; set; }
        public string? Remark { get; set; }
        public List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails>? StudentDetails { get; set; }
    }
    public class DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails
    {

        public string? Category { get; set; }
        public int GeneralCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int GeneralCategoryMale { get; set; }
        public int GeneralCategoryFemale { get; set; }
        public int GeneralCategoryTransGender { get; set; }

        public int EWSCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int EWSCategoryMale { get; set; }
        public int EWSCategoryFemale { get; set; }
        public int EWSCategoryTransGender { get; set; }

        public int SCCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int SCCategoryMale { get; set; }
        public int SCCategoryFemale { get; set; }
        public int SCCategoryTransGender { get; set; }

        public int STCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int STCategoryMale { get; set; }
        public int STCategoryFemale { get; set; }
        public int STCategoryTransGender { get; set; }

        public int OBCCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int OBCCategoryMale { get; set; }
        public int OBCCategoryFemale { get; set; }
        public int OBCCategoryTransGender { get; set; }

        public int TotalCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int TotalCategoryMale { get; set; }
        public int TotalCategoryFemale { get; set; }
        public int TotalCategoryTransGender { get; set; }

    }


    public class DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data
    {

        public string Faculty_School { get; set; }
        public string Department_Centre { get; set; }
        public int LevelID { get; set; }
        public string LevelName { get; set; }
        public string Discipline { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public string Category { get; set; }
        public int GeneralCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int GeneralCategoryMale { get; set; }
        public int GeneralCategoryFemale { get; set; }
        public int GeneralCategoryTransGender { get; set; }

        public int EWSCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int EWSCategoryMale { get; set; }
        public int EWSCategoryFemale { get; set; }
        public int EWSCategoryTransGender { get; set; }

        public int SCCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int SCCategoryMale { get; set; }
        public int SCCategoryFemale { get; set; }
        public int SCCategoryTransGender { get; set; }

        public int STCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int STCategoryMale { get; set; }
        public int STCategoryFemale { get; set; }
        public int STCategoryTransGender { get; set; }

        public int OBCCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int OBCCategoryMale { get; set; }
        public int OBCCategoryFemale { get; set; }
        public int OBCCategoryTransGender { get; set; }

        public int TotalCategorySeatsEarmarkedAsPerGOI { get; set; }
        public int TotalCategoryMale { get; set; }
        public int TotalCategoryFemale { get; set; }
        public int TotalCategoryTransGender { get; set; }
        public string Remark { get; set; }
    }
}


