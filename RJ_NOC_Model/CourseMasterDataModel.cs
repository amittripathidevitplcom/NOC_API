using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class CourseMasterDataModel
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string EmpanelmentType { get; set; }
        public string DepartmentName { get; set; }
        public int NumberofResources { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    } 

}
