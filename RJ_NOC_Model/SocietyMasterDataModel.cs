using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class SocietyMasterDataModels
    {
        public DataTable data { get; set; }
    }
    public class SocietyMasterDataModel
    {
        public int UserID { get; set; }
        public int SocietyID { get; set; }
        public int CollegeID { get; set; }
        public int DesignationID { get; set; }
        public int OccupationID { get; set; }
        public String Educationists { get; set; }
        public string PersonName { get; set; }
        public string FatherName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PANNo { get; set; }
        public string PANCard { get; set; }
        public string AadhaarNo { get; set; }
        public string AadhaarCard { get; set; }
        public string SignatureDoc { get; set; }
        public string ProfilePhoto { get; set; }
        public string AuthorizedDocument { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsAuthorized { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }


    }
}
