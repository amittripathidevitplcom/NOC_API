using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class ImportExcelDataDataModel
    {
        public string DataType { get; set; } 
        public string FileName { get; set; }
        public string SSOID { get; set; }
        public string FinancialYear { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public List<object> Data { get; set; }
    }

    public class MemberDataModel 
    {
        //commit
        public long ID { get; set; } 
        public int ImportExcelID { get; set; }
        public string Course { get; set; }
        public string Subject { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Section { get; set; }
        public string RollNo { get; set; }
        public string Year { get; set; }
        public string Cast { get; set; }
        public string PH { get; set; }
        public string Minorty { get; set; }
    }
}
