using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class AssemblyAreaMasterDataModel
    {
        public int AssemblyAreaID { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string AssemblyAreaName { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
