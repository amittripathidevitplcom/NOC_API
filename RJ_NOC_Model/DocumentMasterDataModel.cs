using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class DocumentMasterDataModel
    {
        public int DocumentMasterID { get; set; }
        public int DepartmentID { get; set; }
        public string DocumentTypeID { get; set; }
        public string DocumentName { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public bool IsCompulsory { get; set; }
        public bool IsActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int UserID { get; set; } 
    }
}
