using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class StreamSubjectMappingDetailDataModel
    {
        public int AID { get; set; }
        public int StreamMappingID { get; set; }
        public int DepartmentID { get; set; }
        public int CourseLevelID { get; set; }
        public int CourseID { get; set; }
        public int StreamID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int UserID { get; set; }

        public List<StreaSubjectDetails> SelectedSubjectDetails { get; set; }
    }

   

    public class StreamSubjectMappingListDataModel
    {
        public int AID { get; set; }
        public int StreamMappingID { get; set; }
        public int SubjectID { get; set; }
        public bool ActiveStatus { get; set; }
    }

    public class StreaSubjectDetails
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool IsChecked { get; set; }
        public bool ActiveStatus { get; set; }
        public int StreamMappingID { get; set; }

    }


}
