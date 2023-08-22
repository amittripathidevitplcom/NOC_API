using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RJ_NOC_Model
{
    public class SubjectWiseStatisticsDetailsDataModel
    {

        public int SubjectStaticsID { get; set; }
        public int CollegeID { get; set; }
        public string CourseName { get; set; }
        public int CourseID { get; set; }
        public string SubjectName { get; set; }
        public int SubjectID { get; set; }
        public int FirstYearBoysCount { get; set; }
        public int FirstYearGirlsCount { get; set; }
        public int SecYearBoysCount { get; set; }
        public int SecYearGirlsCount { get; set; }
        public int ThirdYearBoysCount { get; set; }
        public int ThirdYearGirlsCount { get; set; }
        public int PervYearBoysCount { get; set; }
        public int PervYearGirlsCount { get; set; }
        public int FinalYearBoysCount { get; set; }
        public int FinalYearGirlsCount { get; set; }
        public int DiplomaBoysCount { get; set; }
        public int DiplomaGirlsCount { get; set; }
        public int OtherBoysCount { get; set; }
        public int OtherGirlsCount { get; set; }
        public decimal Total { get; set; }
        public string? Action { get; set; }
        public string? Remark { get; set; }
    }

    public class PostSubjectWiseStatisticsDetailsDataModel
    {
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public int UserID { get; set; }
        public List<SubjectWiseStatisticsDetailsDataModel> SubjectWiseStatisticsDetails { get; set; }
    }
}