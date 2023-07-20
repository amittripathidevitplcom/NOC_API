using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class StreamMasterDataModel
    {
        public int StreamMasterID { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public int CourseLevelID { get; set; }
        public string? CourseLevelName { get; set; }
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string StreamName { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public string? ActiveDeactive { get; set; }
        public bool DeleteStatus { get; set; }
    }

}
