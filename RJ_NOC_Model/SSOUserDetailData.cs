using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace RJ_NOC_Model
{
    public class SSOUserDetailData
    {

        public string SSOID { get; set; }
        public string AadhaarId { get; set; }
        public string BhamashahId { get; set; }
        public string BhamashahMemberId { get; set; }
        public string DisplayName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNumber { get; set; }
        public string IpPhone { get; set; }
        public string MailPersonal { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        [JsonProperty("l")]
        public string City { get; set; }
        [JsonProperty("st")]
        public string State { get; set; }
        public string Photo { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string MailOfficial { get; set; }
        public string EmployeeNumber { get; set; }
        public string DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] SldSSOIDs { get; set; }
        public string JanaadhaarId { get; set; }
        public string ManaadhaarMemberId { get; set; }
        public string UserType { get; set; }
        public string Mfa { get; set; } 

    }

    public class SSOLandingDataDataModel
    {
        public string Username { get; set; }
        public string LoginType { get; set; }
        public string Password { get; set; }
    } 
}

 