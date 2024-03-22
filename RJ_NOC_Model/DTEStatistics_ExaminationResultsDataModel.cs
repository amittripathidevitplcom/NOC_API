using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_ExaminationResultsDataModel
    {
        public int EntryID { get; set; }
        public string EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }
        public string EntryType { get; set; }

        public List<DTEStatistics_ExaminationResultsDataModel_ProgrammesDetails>? ProgrammesDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class DTEStatistics_ExaminationResultsDataModel_ProgrammesDetails
    {
        public int AID { get; set; }
        public string Faculty_School { get; set; }
        public string Department_Centre { get; set; }
        public int LevelID { get; set; }
        public string LevelName { get; set; }
        public string Discipline { get; set; }



        public string AppeardCategory { get; set; }
        public int AppeardGeneralCategoryMale { get; set; }
        public int AppeardGeneralCategoryFemale { get; set; }
        public int AppeardGeneralCategoryTransGender { get; set; }

        public int AppeardEWSCategoryMale { get; set; }
        public int AppeardEWSCategoryFemale { get; set; }
        public int AppeardEWSCategoryTransGender { get; set; }

        public int AppeardSCCategoryMale { get; set; }
        public int AppeardSCCategoryFemale { get; set; }
        public int AppeardSCCategoryTransGender { get; set; }

        public int AppeardSTCategoryMale { get; set; }
        public int AppeardSTCategoryFemale { get; set; }
        public int AppeardSTCategoryTransGender { get; set; }

        public int AppeardOBCCategoryMale { get; set; }
        public int AppeardOBCCategoryFemale { get; set; }
        public int AppeardOBCCategoryTransGender { get; set; }

        public int AppeardTotalCategoryMale { get; set; }
        public int AppeardTotalCategoryFemale { get; set; }
        public int AppeardTotalCategoryTransGender { get; set; }

        public string AppeardRemark { get; set; }
        public string trCss { get; set; }


        //Total Number of Students Passed/Awarded Degree
        public string PassedCategory { get; set; }
        public int PassedGeneralCategoryMale { get; set; }
        public int PassedGeneralCategoryFemale { get; set; }
        public int PassedGeneralCategoryTransGender { get; set; }

        public int PassedEWSCategoryMale { get; set; }
        public int PassedEWSCategoryFemale { get; set; }
        public int PassedEWSCategoryTransGender { get; set; }

        public int PassedSCCategoryMale { get; set; }
        public int PassedSCCategoryFemale { get; set; }
        public int PassedSCCategoryTransGender { get; set; }

        public int PassedSTCategoryMale { get; set; }
        public int PassedSTCategoryFemale { get; set; }
        public int PassedSTCategoryTransGender { get; set; }

        public int PassedOBCCategoryMale { get; set; }
        public int PassedOBCCategoryFemale { get; set; }
        public int PassedOBCCategoryTransGender { get; set; }

        public int PassedTotalCategoryMale { get; set; }
        public int PassedTotalCategoryFemale { get; set; }
        public int PassedTotalCategoryTransGender { get; set; }

        public string PassedRemark { get; set; }

        //Out of Total, Number of Students Passed with 60% or above
        public string OutofTotalPassedCategory { get; set; }
        public int OutofTotalPassedGeneralCategoryMale { get; set; }
        public int OutofTotalPassedGeneralCategoryFemale { get; set; }
        public int OutofTotalPassedGeneralCategoryTransGender { get; set; }

        public int OutofTotalPassedEWSCategoryMale { get; set; }
        public int OutofTotalPassedEWSCategoryFemale { get; set; }
        public int OutofTotalPassedEWSCategoryTransGender { get; set; }

        public int OutofTotalPassedSCCategoryMale { get; set; }
        public int OutofTotalPassedSCCategoryFemale { get; set; }
        public int OutofTotalPassedSCCategoryTransGender { get; set; }

        public int OutofTotalPassedSTCategoryMale { get; set; }
        public int OutofTotalPassedSTCategoryFemale { get; set; }
        public int OutofTotalPassedSTCategoryTransGender { get; set; }

        public int OutofTotalPassedOBCCategoryMale { get; set; }
        public int OutofTotalPassedOBCCategoryFemale { get; set; }
        public int OutofTotalPassedOBCCategoryTransGender { get; set; }

        public int OutofTotalPassedTotalCategoryMale { get; set; }
        public int OutofTotalPassedTotalCategoryFemale { get; set; }
        public int OutofTotalPassedTotalCategoryTransGender { get; set; }

        public string OutofTotalPassedRemark { get; set; }
        public List<DTEStatistics_ExaminationResultsDataModel_StudentDetails>? StudentDetails { get; set; }
    }
    public class DTEStatistics_ExaminationResultsDataModel_StudentDetails
    {
        public string AppeardCategory { get; set; }
        public int AppeardGeneralCategoryMale { get; set; }
        public int AppeardGeneralCategoryFemale { get; set; }
        public int AppeardGeneralCategoryTransGender { get; set; }

        public int AppeardEWSCategoryMale { get; set; }
        public int AppeardEWSCategoryFemale { get; set; }
        public int AppeardEWSCategoryTransGender { get; set; }

        public int AppeardSCCategoryMale { get; set; }
        public int AppeardSCCategoryFemale { get; set; }
        public int AppeardSCCategoryTransGender { get; set; }

        public int AppeardSTCategoryMale { get; set; }
        public int AppeardSTCategoryFemale { get; set; }
        public int AppeardSTCategoryTransGender { get; set; }

        public int AppeardOBCCategoryMale { get; set; }
        public int AppeardOBCCategoryFemale { get; set; }
        public int AppeardOBCCategoryTransGender { get; set; }

        public int AppeardTotalCategoryMale { get; set; }
        public int AppeardTotalCategoryFemale { get; set; }
        public int AppeardTotalCategoryTransGender { get; set; }
         


        //Total Number of Students Passed/Awarded Degree
        public string PassedCategory { get; set; }
        public int PassedGeneralCategoryMale { get; set; }
        public int PassedGeneralCategoryFemale { get; set; }
        public int PassedGeneralCategoryTransGender { get; set; }

        public int PassedEWSCategoryMale { get; set; }
        public int PassedEWSCategoryFemale { get; set; }
        public int PassedEWSCategoryTransGender { get; set; }

        public int PassedSCCategoryMale { get; set; }
        public int PassedSCCategoryFemale { get; set; }
        public int PassedSCCategoryTransGender { get; set; }

        public int PassedSTCategoryMale { get; set; }
        public int PassedSTCategoryFemale { get; set; }
        public int PassedSTCategoryTransGender { get; set; }

        public int PassedOBCCategoryMale { get; set; }
        public int PassedOBCCategoryFemale { get; set; }
        public int PassedOBCCategoryTransGender { get; set; }

        public int PassedTotalCategoryMale { get; set; }
        public int PassedTotalCategoryFemale { get; set; }
        public int PassedTotalCategoryTransGender { get; set; }
         

        //Out of Total, Number of Students Passed with 60% or above
        public string OutofTotalPassedCategory { get; set; }
        public int OutofTotalPassedGeneralCategoryMale { get; set; }
        public int OutofTotalPassedGeneralCategoryFemale { get; set; }
        public int OutofTotalPassedGeneralCategoryTransGender { get; set; }

        public int OutofTotalPassedEWSCategoryMale { get; set; }
        public int OutofTotalPassedEWSCategoryFemale { get; set; }
        public int OutofTotalPassedEWSCategoryTransGender { get; set; }

        public int OutofTotalPassedSCCategoryMale { get; set; }
        public int OutofTotalPassedSCCategoryFemale { get; set; }
        public int OutofTotalPassedSCCategoryTransGender { get; set; }

        public int OutofTotalPassedSTCategoryMale { get; set; }
        public int OutofTotalPassedSTCategoryFemale { get; set; }
        public int OutofTotalPassedSTCategoryTransGender { get; set; }

        public int OutofTotalPassedOBCCategoryMale { get; set; }
        public int OutofTotalPassedOBCCategoryFemale { get; set; }
        public int OutofTotalPassedOBCCategoryTransGender { get; set; }

        public int OutofTotalPassedTotalCategoryMale { get; set; }
        public int OutofTotalPassedTotalCategoryFemale { get; set; }
        public int OutofTotalPassedTotalCategoryTransGender { get; set; }
         
    }


    public class DTEStatistics_ExaminationResultsDataModel_StudentDetails_Data
    {
        public string Faculty_School { get; set; }
        public string Department_Centre { get; set; }
        public int LevelID { get; set; }
        public string LevelName { get; set; }
        public string Discipline { get; set; }

        public string AppeardCategory { get; set; }
        public int AppeardGeneralCategoryMale { get; set; }
        public int AppeardGeneralCategoryFemale { get; set; }
        public int AppeardGeneralCategoryTransGender { get; set; }

        public int AppeardEWSCategoryMale { get; set; }
        public int AppeardEWSCategoryFemale { get; set; }
        public int AppeardEWSCategoryTransGender { get; set; }

        public int AppeardSCCategoryMale { get; set; }
        public int AppeardSCCategoryFemale { get; set; }
        public int AppeardSCCategoryTransGender { get; set; }

        public int AppeardSTCategoryMale { get; set; }
        public int AppeardSTCategoryFemale { get; set; }
        public int AppeardSTCategoryTransGender { get; set; }

        public int AppeardOBCCategoryMale { get; set; }
        public int AppeardOBCCategoryFemale { get; set; }
        public int AppeardOBCCategoryTransGender { get; set; }

        public int AppeardTotalCategoryMale { get; set; }
        public int AppeardTotalCategoryFemale { get; set; }
        public int AppeardTotalCategoryTransGender { get; set; }

        public string AppeardRemark { get; set; }
        public string trCss { get; set; }


        //Total Number of Students Passed/Awarded Degree
        public string PassedCategory { get; set; }
        public int PassedGeneralCategoryMale { get; set; }
        public int PassedGeneralCategoryFemale { get; set; }
        public int PassedGeneralCategoryTransGender { get; set; }

        public int PassedEWSCategoryMale { get; set; }
        public int PassedEWSCategoryFemale { get; set; }
        public int PassedEWSCategoryTransGender { get; set; }

        public int PassedSCCategoryMale { get; set; }
        public int PassedSCCategoryFemale { get; set; }
        public int PassedSCCategoryTransGender { get; set; }

        public int PassedSTCategoryMale { get; set; }
        public int PassedSTCategoryFemale { get; set; }
        public int PassedSTCategoryTransGender { get; set; }

        public int PassedOBCCategoryMale { get; set; }
        public int PassedOBCCategoryFemale { get; set; }
        public int PassedOBCCategoryTransGender { get; set; }

        public int PassedTotalCategoryMale { get; set; }
        public int PassedTotalCategoryFemale { get; set; }
        public int PassedTotalCategoryTransGender { get; set; }

        public string PassedRemark { get; set; }

        //Out of Total, Number of Students Passed with 60% or above
        public string OutofTotalPassedCategory { get; set; }
        public int OutofTotalPassedGeneralCategoryMale { get; set; }
        public int OutofTotalPassedGeneralCategoryFemale { get; set; }
        public int OutofTotalPassedGeneralCategoryTransGender { get; set; }

        public int OutofTotalPassedEWSCategoryMale { get; set; }
        public int OutofTotalPassedEWSCategoryFemale { get; set; }
        public int OutofTotalPassedEWSCategoryTransGender { get; set; }

        public int OutofTotalPassedSCCategoryMale { get; set; }
        public int OutofTotalPassedSCCategoryFemale { get; set; }
        public int OutofTotalPassedSCCategoryTransGender { get; set; }

        public int OutofTotalPassedSTCategoryMale { get; set; }
        public int OutofTotalPassedSTCategoryFemale { get; set; }
        public int OutofTotalPassedSTCategoryTransGender { get; set; }

        public int OutofTotalPassedOBCCategoryMale { get; set; }
        public int OutofTotalPassedOBCCategoryFemale { get; set; }
        public int OutofTotalPassedOBCCategoryTransGender { get; set; }

        public int OutofTotalPassedTotalCategoryMale { get; set; }
        public int OutofTotalPassedTotalCategoryFemale { get; set; }
        public int OutofTotalPassedTotalCategoryTransGender { get; set; }

        public string OutofTotalPassedRemark { get; set; }
    }
}


