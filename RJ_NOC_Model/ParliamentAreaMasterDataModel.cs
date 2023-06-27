using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class ParliamentAreaMasterDataModel
    {
        public int ParliamentAreaID { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string ParliamentAreaName { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
