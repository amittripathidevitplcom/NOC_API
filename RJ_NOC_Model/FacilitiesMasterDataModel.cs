using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class FacilitiesMasterDataModel
    {
       public int DepartmentID { get; set; }
       public int FID { get; set; }
        public string FacilitiesName { get; set; }
        public decimal MinSize { get; set; }
        public string Unit { get; set; }
public string IsYesNoOption { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
   public class FacilitiesMasterDataModel_list
    {
        public DataTable data { get; set; }
    }


}
