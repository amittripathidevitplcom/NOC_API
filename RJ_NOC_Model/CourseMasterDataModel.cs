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

    public class DTECourseMasterDataModel
    {
        public int CollegeWiseCourseID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public string OtherCourseName { get; set; }
        public int SuperNumerarySeats { get; set; } 
        public int Intake { get; set; }
        public int ConductMode { get; set; }
        public int Shift { get; set; }
        public int Enrollment { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int CourseLevelID { get; set; }
        public int StreamID { get; set; }

    }
    public class CourseReportSearchFilter
    {
        public int DepartmentID { get; set; }
        public string? CollegeName { get; set; }
        public int CollegeTypeID { get; set; }
        public int NOCStatusID { get; set; }
        public int UniversityID { get; set; }
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public int StatusOfCollegeID { get; set; }
        public int CourseNOCStatusID { get; set; }
        public int SubjectNOCStatusID { get; set; }
        public int CourseTypeID { get; set; }
        public int SubjectNOCOrderNo { get; set; }
        public int CollegeID { get; set; }
        public int EnrolledStudent { get; set; }
        public string? FromSubmittedNOCDate { get; set; }
        public string? ToSubmittedNOCDate { get; set; }
        public int CollegeLevelID { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; } 
    }
}