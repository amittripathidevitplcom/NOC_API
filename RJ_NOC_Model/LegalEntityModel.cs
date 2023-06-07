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
        public string RegistrationNo { get; set; }
        public string PreMobNo { get; set; }
        public string PreMailId { get; set; }
        public string SocietyName { get; set; }
        public string SocietyPresentStatus { get; set; }
        public int State { get; set; }
        public int District { get; set; }
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
        public string ManagementCommitteecertified { get; set; }
        public string PresidentAadhaarNumber { get; set; }
        public string PresidentAadhaarProofDoc { get; set; }
        public string SocietTANNumber { get; set; }
        public string SocietyPANNumber { get; set; }
        public string SocietyPanProofDoc { get; set; }
        public List<LegalEntityMemberDetailsDataModel> MemberDetails { get; set; }
        public List<LegalEntityInstituteDetailsDataModel> InstituteDetails { get; set; }
        
    }

    public class LegalEntityMemberDetailsDataModel
    {
        public int MID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string DOB { get; set; }
        public string MobileNo { get; set; }
        public string PostID { get; set; }
        public string PostName { get; set; }
        public string MemberPhoto { get; set; }
        public string MemberSign { get; set; }
    }

    public class LegalEntityInstituteDetailsDataModel
    {
        public int IID { get; set; }
        public string InstituteName { get; set; }
        public string InstitutePersonName { get; set; }
        public string InstituteDesignation { get; set; }
        public string InstituteContactNumber { get; set; }
    }
}
