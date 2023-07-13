using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class CreateUserDataModel
    {
        public int UId { get; set; }
        public string SSOID { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public int CommitteeID { get; set; }
        public string? CommitteeName { get; set; }
        public string MemberType { get; set; }
        public int StateID { get; set; }
        public string? StateName { get; set; }
        public int DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public int TehsilID { get; set; }
        public string? TehsilName { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
