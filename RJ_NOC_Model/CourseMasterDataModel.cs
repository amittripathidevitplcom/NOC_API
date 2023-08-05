using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class CourseMasterDataModel
    { 
        public int CollegeWiseCourseID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int CourseTypeID { get; set; }
        public int Seats { get; set; }
        public int NoOfEnrolledStudents { get;set; }

        public List<CourseMasterDataModel_SubjectDetails> SelectedSubjectDetails { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int CourseLevelID { get; set; }
        public int StreamID { get; set; }

    }

    public class CourseMasterDataModel_SubjectDetails
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

    }
}