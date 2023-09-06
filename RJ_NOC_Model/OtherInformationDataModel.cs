using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class OtherInformationDataModels
    {
        public DataTable data { get; set; }
    }
    public class OtherInformationDataModel
    {
        public int CollegeWiseOtherInfoID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFilePath { get; set; }
        public string? Image_Dis_FileName { get; set; }
        public string BookImageFileName { get; set; }
        public string BookImageFilePath { get; set; }
        public string? BookImage_Dis_FileName { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int NoofBooks { get; set; }
        public int NoofComputers { get; set; }
        public int UserID { get; set; }

        public string? Action { get; set; }
        public string? Remark { get; set; }
        public string? CourseName { get; set; }


        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }

        public int NoOfRooms { get; set; }
    }
}
