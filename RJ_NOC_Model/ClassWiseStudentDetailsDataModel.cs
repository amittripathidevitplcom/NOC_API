using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RJ_NOC_Model
{
    public class ClassWiseStudentDetailsDataModel
    {

        public string CourseName { get; set; }
        public int ClassStatisticID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public string Class { get; set; }
        public string? ClassName { get; set; }
        public string? Section { get; set; }
        public int SCBoysCount { get; set; }
        public int SCGirlsCount { get; set; }
        public int STBoysCount { get; set; }
        public int STGirlsCount { get; set; }
        public int OBCBoysCount { get; set; }
        public int OBCGirlsCount { get; set; }
        public int MBCBoysCount { get; set; }
        public int MBCGirlsCount { get; set; }
        public int GenBoysCount { get; set; }
        public int GenGirlsCount { get; set; }
        public int EWSGirlsCount { get; set; }
        public int EWSBoysCount { get; set; }
        public int TotalGirls { get; set; }

        public int TotalBoys { get; set; }
        public int Total { get; set; }
        public int OFTotalMinorityBoys { get; set; }
        public int OFTotalMinorityGirls { get; set; }
        public int OFTotalPHBoys { get; set; }
        public int OFTotalPHGirls { get; set; }

        public string? Action { get; set; }
        public string? Remark { get; set; }

    }

    public class PostClassWiseStudentDetailsDataModel
    {
        public int CollegeID { get; set; }
        public int UserID { get; set; }
        public List<ClassWiseStudentDetailsDataModel> ClassWiseStudentDetails { get; set; }
    }
}