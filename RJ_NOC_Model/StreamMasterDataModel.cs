using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class StreamMasterDataModel
    {
        public int StreamMappingID { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public int CourseLevelID { get; set; }
        public string? CourseLevelName { get; set; }
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int StreamID { get; set; }
        public string StreamName { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public string? ActiveDeactive { get; set; }
        public bool DeleteStatus { get; set; }
        public int CourseMappingID { get; set; }
        public List<StreamCourseMappingDetails> CourseDetails { get; set; }
    }



    public class CourseSubjectMappingListData
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool IsChecked { get; set; }
        public bool ActiveStatus { get; set; }
        public int StreamMappingID { get; set; }
    }

    public class StreamCourseMappingDetails
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public bool IsChecked { get; set; }
        public bool ActiveStatus { get; set; }
        public int CourseMappingID { get; set; }
    }


}
