using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace RJ_NOC_Model
{
    public class CommonDataModel_DataTable
    {
        public DataTable data { get; set; }
    }

    public class CommonDataModel_DocumentMasterList
    {
        public int DID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public bool Status { get; set; }
        public bool ForEmployeeCode { get; set; }
    }

    public class CommonDataModel_EmployeeDocumentList
    {
        public int ProjectID { get; set; }
        public int EmployeeID { get; set; }
        public int DID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFileName { get; set; }    
        public string Status { get; set; }  
        public string ActionRemarks { get; set; }  

    }
}
