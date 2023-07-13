using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class TrusteeGeneralInfoMasterDataModel
    {
        public int TrusteeGeneralInfoID { get; set; }
        public int LegalEntityID { get; set; }
        public string SocietyRegistrationDocument { get; set; }
        public string? Dis_SocietyRegistrationDocument { get; set; }
        public string? SocietyRegistrationDocumentPath { get; set; }
        public string SocietyLogo { get; set; }
        public string? Dis_SocietyLogo { get; set; }
        public string? SocietyLogoPath { get; set; }
        public string DateOfElectionOfPresentManagementCommittee { get; set; }
        public int? WomenMembersOfManagementCommitteeID { get; set; }
        public int? DateOfElectionOfManagementCommitteeID { get; set; }
        public int? OtherInstitutionRunByTheSocietyID { get; set; }

        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public string? IPAddress { get; set; }
    }
    public class LegalEntityDataModel
    {
        public string SSOID { get; set; }
        public int LegalEntityID { get; set; }
        public string SocietyName { get; set; }
        public string LegalEntity { get; set; }
        public string RegistrationNo { get; set; }
        public string District_Eng { get; set; }
        public string RegisteredAct { get; set; }
        public string SocietyPresentStatus { get; set; }
        public string SocietyRegistrationDate { get; set; }
    }
}
