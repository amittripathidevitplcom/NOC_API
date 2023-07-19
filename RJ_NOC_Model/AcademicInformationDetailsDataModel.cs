using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class AcademicInformationDetailsDataModels
    {
        public DataTable data { get; set; }
    }
    public class AcademicInformationDetailsDataModel
    {
        public int AcademicInformationID { get; set; }
        public int CollegeID { get; set; }
        public int YearID { get; set; }
        public string YearValue { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int AdmittedStudent { get; set; }
        public int AppearedStudent { get; set; }
        public int ResultID { get; set; }
        public string ResultName { get; set; }
        public int? PassedStudent { get; set; }
        public int? FailedStudent { get; set; }
        public int? OtherStudent { get; set; }
        public int UserID { get; set; }

        public string? Action { get; set; }
        public string? Remark { get; set; }

        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }
    }
}
