using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    

    public class CommitteeMasterDataModel
    {
        public int CommitteeMasterID { get; set; }
        public string CommitteeType { get; set; }
        public string CommitteeName { get; set; }
        public string ContactNumber { get; set; }
        //public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public List<CommitteeMemberDetail> CommitteeMemberDetailList { get; set; }
    }
    public class CommitteeMemberDetail
    {
        public int CommitteeMemberDetailID { get; set; }
        public string NameOfPerson { get; set; }
        public string MobileNumber { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }

    }


}
