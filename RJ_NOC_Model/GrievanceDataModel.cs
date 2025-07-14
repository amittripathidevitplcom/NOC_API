using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class GrievanceDataModel
    {
        public int GrievanceID { get; set; }
        public string SSOID { get; set; }
        public string MobileNo { get; set; }
        public string BugFrom { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string AttachmentFile { get; set; }
        public string AttachmentFile_Dis_FileName { get; set; }
        public string AttachmentFilePath { get; set; }
        public string AttachmentImage { get; set; }
        public string GrievanceRemark { get; set; }
        public string Action { get; set; }      

    }

}
