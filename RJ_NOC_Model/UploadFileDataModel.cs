using System;
using System.Collections.Generic;
using System.Text;

namespace RJ_NOC_Model
{
   public class UploadFileDataModel
    {
        public string FileName { get; set; }
    }
    public class UploadFileWithPathDataModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Dis_FileName { get; set; }

    }
}
