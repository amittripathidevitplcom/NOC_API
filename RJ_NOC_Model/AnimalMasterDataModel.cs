using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class AnimalMasterDataModel
    {
        public int AnimalMasterID { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public string AnimalName { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public string? ActiveDeactive { get; set; }
        public bool DeleteStatus { get; set; }
    }

}
