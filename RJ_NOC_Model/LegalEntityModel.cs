using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class LegalEntityModel
    {
        public int LegalEntityID { get; set; }
        public int IsLegalEntity { get; set; }
        public string SSOID { get; set; }
        public string RegistrationNo { get; set; }
        public string PresidentMobileNo { get; set; }
        public string PresidentEmail { get; set; }
        public string SocietyName { get; set; }
        public string SocietyPresentStatus { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public int RegisteredActID { get; set; }
        public string RegisteredActName { get; set; }
        public string SocietyRegistrationDate { get; set; }
        public string ElectionPresentManagementCommitteeDate { get; set; }
        public string SocietyRegisteredAddress { get; set; }
        public string Pincode { get; set; }
        public string TrustLogoDoc { get; set; }
        public string TrusteeMemberProofDoc { get; set; }
        public string IsOtherInstitution { get; set; }
        public string IsWomenMembers { get; set; }
        public string IsDateOfElection { get; set; }
        public string ManagementCommitteeCertified { get; set; }
        public string PresidentAadhaarNumber { get; set; }
        public string PresidentAadhaarProofDoc { get; set; }
        public string SocietyPANNumber { get; set; }
        public string SocietyPanProofDoc { get; set; }
        public List<LegalEntityMemberDetailsDataModel> MemberDetails { get; set; }
        public List<LegalEntityInstituteDetailsDataModel> InstituteDetails { get; set; }

    }

    public class LegalEntityMemberDetailsDataModel
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberFatherName { get; set; }
        public string MemberDOB { get; set; }
        public string MemberMobileNo { get; set; }
        public string MemberPostID { get; set; }
        public string MembersPostName { get; set; }
        public string MemberPhoto { get; set; }
        public string MemberSignature { get; set; }
    }

    public class LegalEntityInstituteDetailsDataModel
    {
        public int InstituteID { get; set; }
        public string RegistrationNo { get; set; }
        public string InstituteName { get; set; }
        public string InstitutePersonName { get; set; }
        public string InstituteDesignation { get; set; }
        public string InstituteContactNumber { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
    public class LegalEntityDuplicateCheckDataModel
    {
        public int LegalEntityID { get; set; }
        public string RegistrationNo { get; set; }
    }
}
