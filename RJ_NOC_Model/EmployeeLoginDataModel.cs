using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class EmployeeLoginDataModel
    {
        public int CID { get; set; }
        public int ProjectID { get; set; }
        public string Designation { get; set; }
        public string CandidateName { get; set; }
        public string DateofJoining { get; set; }
        public decimal CTC { get; set; }

        public string EmailID { get; set; }
        public string PhoneNo { get; set; }
    }
}