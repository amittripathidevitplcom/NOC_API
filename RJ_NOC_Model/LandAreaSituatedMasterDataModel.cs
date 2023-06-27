using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class LandAreaSituatedMasterDataModel
    {
      public int DepartmentID { get; set; }
        public int LandAreaID { get; set; }

        public int StateID { get; set; }
        public int  DistrictID { get; set; }
        public string LandAreaName { get; set; }       
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }

    }
    public class LandAreaSituatedMasterDataModel_list
    {
        public DataTable data { get; set; }
    }
    public class LandAreaSituated_DistrictList
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
    }

    public class LandAreaSituatedModel_StateList
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
}
