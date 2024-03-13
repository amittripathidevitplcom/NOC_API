using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_OfficersDetailsDataModel
    {
        public int EntryID { get; set; }
        public string EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }


        public string NameOfVice { get; set; }
        public int DesignationID { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNo { get; set; }

        public string NameOfNodal { get; set; }
        public int Nodal_DesignationID { get; set; }
        public string Nodal_Email { get; set; }
        public string Nodal_MobileNo { get; set; }
        public string Nodal_TelephoneNo { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }

}
