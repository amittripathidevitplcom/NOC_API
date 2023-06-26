using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class CollegeDocumentDataModel
    { 
        public int CollegeID { get; set; }
        public string DocumentType { get; set; }
        public List<CommonDataModel_BuildingUploadDoc> DocumentDetails { get; set; }
    }
     
}