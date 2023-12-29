using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    

    public class DTECommitteeMasterDataModel
    {
        public int DTECommitteeMasterID { get; set; }
        public string CommitteeType { get; set; }
        public string CommitteeName { get; set; }
        public string ContactNumber { get; set; }
        //public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public List<DETCommitteeMemberDetail> CommitteeMemberDetailList { get; set; }
    }
    public class DETCommitteeMemberDetail
    {
        public int CommitteeMemberDetailID { get; set; }
        public string NameOfPerson { get; set; }
        public string MobileNumber { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public string SSOID { get; set; }
        public string AadhaarNo { get; set; }
        public bool ISPrimary { get; set; }

    }


}
