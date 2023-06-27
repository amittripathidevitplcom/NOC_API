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
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFilePath { get; set; }
        public string BookImageFileName { get; set; }
        public string BookImageFilePath { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int NoofBooks { get; set; }
        public int UserID { get; set; }
    }
}
