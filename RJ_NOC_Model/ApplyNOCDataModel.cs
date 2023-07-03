using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class ApplyNOCDataModel
    {
        public int ApplyNOCID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string DepartmentName { get; set; }
        public string CollegeName { get; set; }
    }

    public class DocumentScrutiny_TempDataModel
    {
        public int DocumentScrutinyID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public int ActionID { get; set; }
        public string Remark { get; set; }
        public string TabName { get; set; }
        public int ApplyNOCID { get; set; }
        public string ActionType { get; set; }
        public List<DocumentScrutinyDetail_DocumentScrutiny_TempDataModel> DocumentScrutiny_TempDetail { get; set; }
    }
    public class DocumentScrutinyDetail_DocumentScrutiny_TempDataModel
    {
        public int DocumentScrutinyDetailID { get; set; }
        public int DocumentScrutinyID { get; set; }
        public int TabFieldID { get; set; }
        public string TabFieldName { get; set; }
}
}
