using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_RegularForeignStudentEnrolmentDataModel
    {
        public int EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }
        public string? EntryType { get; set; }

        public int ForeignStudentEnrolledInTheinstitution { get; set; }
        public int ApprovedIntakeCapacityOfInternationalStudents { get; set; }

        public List<DTEStatistics_RegularForeignStudentEnrolmentDataModel_RegularForeignStudentEnrolment>? RegularForeignStudentEnrolment { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class DTEStatistics_RegularForeignStudentEnrolmentDataModel_RegularForeignStudentEnrolment
    {
        public string? Country { get; set; }
        public string? Faculty_School { get; set; }
        public string? Department_Centre { get; set; }
        public string? Discipline { get; set; }
        public string? Method_of_Admission { get; set; }
        public int No_of_Students_Enrolled_Total { get; set; }
        public int No_of_Students_Enrolled_Girls { get; set; }
        public int No_of_Students_Staying_in_Institutions_Hostel { get; set; }
        public string? Broad_Discipline_Group { get; set; }
        public string? Broad_DisciplineGroup_Category { get; set; }
        public string? Method_of_Admission2 { get; set; }
    }
}


