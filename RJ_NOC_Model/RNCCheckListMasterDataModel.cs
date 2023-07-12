using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class RNCCheckListMasterDataModel
    {
        public int RNCCheckListID { get; set; }
        public int DepartmentID { get; set; }
        public string RNCCheckListName { get; set; }
        public int UserID { get; set; }
        public bool FileUpload { get; set; }
        public string? IsFileUpload { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }

    }

}
