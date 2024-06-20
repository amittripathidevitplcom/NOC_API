using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class ClinicalFacilityModel
    {
        public int CollegeID { get; set; }
        public int UserId { get; set; }
        public List<ListClinicalFacility> FacilityList { get; set; } = new List<ListClinicalFacility>();
    }
    public class ListClinicalFacility
    {
        public int CollegeFacilityID { get; set; }
        public int ClinicFacilityID { get; set; }
        public string? FacilityName { get; set; }
        public string? FacilityValue { get; set; }
    }
}
