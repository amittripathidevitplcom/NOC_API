using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class UserManualDocumentMasterDataModel
    {
        public int ID { get; set; }
        public int  DepartmentID { get; set; }
        public int  UserTypeID { get; set; }
        public string  TitleEnglish { get; set; }
        public string TitleHindi { get; set; }
        public string DocumentName { get; set; }
        public string Dis_Document { get; set; }
        public string  DocumentPath { get; set; }
        public bool IsNew { get; set; }
        public bool IsShow { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
    }

    public class UserManualDocumentMasterDataModel_List
    {
        public DataTable data { get; set; }
    }
}
