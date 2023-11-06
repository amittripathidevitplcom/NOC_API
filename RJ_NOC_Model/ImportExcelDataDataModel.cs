using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class ImportExcelDataDataModel
    {
        public int StaticsFileID { get; set; }
        public string DataType { get; set; }
        public string FileName { get; set; }
        public string SSOID { get; set; }
        public string FinancialYear { get; set; }
        public string? FinancialYearName { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public List<MemberDataModel>? Data { get; set; }
    }

    public class MemberDataModel
    {
        //commit
        public long ID { get; set; }
        public int ImportExcelID { get; set; }
        public string? ApplicationID { get; set; }
        public string? District { get; set; }
        public string? CollegeName { get; set; }
        public string? AISHECode { get; set; }
        public string? StudentName { get; set; }
        public string? FatherName { get; set; }
        public string? Gender { get; set; }
        public string? Course { get; set; }
        public string? Subject { get; set; }
        public string? Class { get; set; }
        public string? Cast { get; set; }
        public string? PH { get; set; }
        public string? Minorty { get; set; }
        public string? HasScholarship { get; set; }
        public string? ScholarshipName { get; set; }
        public string? DOB { get; set; }
        public string? StudentMobileNo { get; set; }
        public string? StudentEmailId { get; set; }
        public string? PrincipalName { get; set; }
        public string? PrincipalMobileNo { get; set; }
        public string? CollegeEmailId { get; set; }
        public string? CreatedDate { get; set; }
    }
}
