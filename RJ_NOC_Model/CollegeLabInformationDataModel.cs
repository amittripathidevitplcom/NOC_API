using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class CollegeLabInformationDataModel
    {
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public string RoomNo { get; set; }
        public int UserID { get; set; }
        public string? Dis_FileName { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? Dis_OtherFileName { get; set; }
        public string? FileOtherName { get; set; }
        public string? FileOtherPath { get; set; }
        public string SubjectName { get; set; }
        public string CourseName { get; set; }
    }

    public class PostCollegeLabInformation
    {
        public int CollegeID { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }
        public List<CollegeLabInformationDataModel> CollegeLabInformationList { get; set; }
    }
}
