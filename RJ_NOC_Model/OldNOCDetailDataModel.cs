using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class OldNocDetailsDataModel
    {
        public int OldNocID { get; set; }
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public string? CollegeName { get; set; }
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int NOCTypeID { get; set; }
        public string? NOCTypeName { get; set; }
        public int SessionYear { get; set; }
        public string? FinancialYearName { get; set; }
        public int IssuedYear { get; set; }
        public string NOCNumber { get; set; }
        public string NOCReceivedDate { get; set; }
        public string? NOCExpireDate { get; set; }
        public string UploadNOCDoc { get; set; }
        public string Remark { get; set; }
        public List<OldNocDetails_SubjectDataModel> SubjectData { get; set; }
    }
    public class OldNocDetails_SubjectDataModel
    {
        public int OldNOCSubjectID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
