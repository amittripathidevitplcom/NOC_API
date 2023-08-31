using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class AddCourseMasterDataModel
    {

        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeLevel { get; set; }
        public int CourseLevelID { get; set; }
        public string? CourseLevel { get; set; }
        public string CourseName { get; set; }
        public int CourseDurationType { get; set; }
        public string? CourseDuratinName { get; set; }
        public int Duration { get; set; }
        public int NoOfRooms { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }

        public int StreamID { get; set; }
        public int UniversityID { get; set; }
        public int NoofSubjectsForCombination { get; set; }
        public List<SubjectAddCourseMasterDataModel> CourseSubjects { get; set; }
    }
    public class SubjectAddCourseMasterDataModel
    {
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
    }
}
