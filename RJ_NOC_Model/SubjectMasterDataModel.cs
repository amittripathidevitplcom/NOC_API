using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class SubjectMasterDataModel
    {
       public int DepartmentID { get; set; }
       public int SubjectID { get; set; }
        //public int CourseID { get; set; }
        public string SubjectName { get; set; }
        public int UserID { get; set; }
        public string? Predical { get; set; }
        public bool IsPredical { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
   public class SubjectMasterDataModel_list
    {
        public DataTable data { get; set; }
    }
    //public class CourseList
    //{
    //    public int CourseID { get; set; }
    //    public string CourseName { get; set; }
    //}
}
