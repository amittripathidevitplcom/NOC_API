using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class ActivityDetailsDataModels
    {
        public DataTable data { get; set; }
    }
    public class ActivityDetailsDataModel
    {
        public int CollegeID { get; set; }
        public int ActivityDetailID { get; set; }
        public int ActivityID { get; set; }
        public int NoOf { get; set; }
        public string ActivityUrl { get; set; }
        public string IsAvailable { get; set; }
        public string? ActivityUrlPath { get; set; }
        public string? ActivityUrl_Dis_FileName { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public decimal MinSize { get; set; }
        public string Unit { get; set; }
        public int UserID { get; set; }

        public int? CreatedBy { get; set; }
        public int? ModifyBy { get; set; }
        public string? IPAddress { get; set; }
        public string? Action { get; set; }
        public string? Remark { get; set; }
        public string ActivityName { get; set; }

        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }
    }
}
