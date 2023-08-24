using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class ApplicationCommitteeMemberdataModel
    {
        public int? CommitteeMemberID { get; set; }
        public int? ApplyNocApplicationID { get; set; }
        public string NameOfPerson { get; set; }
        public string MobileNumber { get; set; }
        public string SSOID { get; set; }
        public int? RoleID { get; set; }
        public bool? IsPrimaryMember { get; set; }
        public bool? ActiveStatus { get; set; }
        public bool? DeleteStatus { get; set; }
        public string? AadhaarNo { get; set; }
        public string? CommitteeType { get; set; }
    }

    public class PostApplicationCommitteeMemberdataModel
    {
        public int? CommitteeMemberID { get; set; }
        public int? CollegeID { get; set; }
        public int? ApplyNocApplicationID { get; set; }
        public int? UserID { get; set; }
        public List<ApplicationCommitteeMemberdataModel>? ApplicationCommitteeList { get; set; }
}

}
