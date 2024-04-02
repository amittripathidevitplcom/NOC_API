using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_ScholarshipFellowshipLoanAccDataModel
    {
        public int EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }

        public List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship>? Scholarship { get; set; }
        public List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship>? Fellowship { get; set; }
        public List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship>? Loan { get; set; }
        public List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_ACC>? ACC { get; set; }

        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship
    {
        public int RowNo { get; set; }
        public int SID { get; set; }
        public string? EntryType { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public int General_Total { get; set; }
        public int General_Female { get; set; }
        public int General_TransGender { get; set; }
        public int EWS_Total { get; set; }
        public int EWS_Female { get; set; }
        public int EWS_TransGender { get; set; }
        public int SC_Total { get; set; }
        public int SC_Female { get; set; }
        public int SC_TransGender { get; set; }
        public int ST_Total { get; set; }
        public int ST_Female { get; set; }
        public int ST_TransGender { get; set; }
        public int OBC_Total { get; set; }
        public int OBC_Female { get; set; }
        public int OBC_TransGender { get; set; }
        public int TOTAL_Total { get; set; }
        public int TOTAL_Female { get; set; }
        public int TOTAL_TransGender { get; set; }
        public string? Remarks { get; set; }
    }


    public class DTEStatistics_ScholarshipFellowshipLoanAccDataModel_ACC
    {
        public string? Name { get; set; }
        public string? AccreditationBody { get; set; }
        public string? IsScoreProvided { get; set; }
        public string? MaximumScore { get; set; }
        public string? Score { get; set; }
        public string? CycleofAccreditatio { get; set; }
        public string? StatusofAccreditation { get; set; }
        public string? DateifAccreditationValidity { get; set; }
        public string? Grade { get; set; }
    }

}


