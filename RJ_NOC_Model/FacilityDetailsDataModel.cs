using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class FacilityDetailsDataModels
    {
        public DataTable data { get; set; }
    }
    public class FacilityDetailsDataModel
    {     
        public int CollegeID { get; set; }
        public int FacilityDetailID { get; set; }
        public int FacilitiesID { get; set; }
        public string FacilitiesUrl { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public decimal MinSize { get; set; }
        public string Unit { get; set; }
        public int UserID { get; set; }
}
}
