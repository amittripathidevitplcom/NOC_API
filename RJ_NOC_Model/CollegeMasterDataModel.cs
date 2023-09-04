
using System.Numerics;

namespace RJ_NOC_Model
{
    public class CollegeMasterDataModel
    {
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeStatusID { get; set; }
        public string CollegeLogo { get; set; }
        public string CollegeLogoPath { get; set; }
        public string CollegeLogo_Dis_FileName { get; set; }
        public int PresentCollegeStatusID { get; set; }
        public int CollegeTypeID { get; set; }
        public int CollegeLevelID { get; set; }
        public string CollegeCode { get; set; }
        public string CollegeNameEn { get; set; }
        public string CollegeNameHi { get; set; }
        public int? AISHECodeStatus { get; set; }
        public string? AISHECode { get; set; }
        public int CollegeMedium { get; set; }
        public int UniversityID { get; set; }
        public string MobileNumber { get; set; }
        public string CollegeLandlineNumber { get; set; }
        //public string? MobileNumber { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int RuralUrban { get; set; }
        public int DistanceFromCity { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public int SubdivisionID { get; set; }
        public int TehsilID { get; set; }
        public int PanchayatSamitiID { get; set; }
        public int ParliamentAreaID { get; set; }
        public int AssemblyAreaID { get; set; }
        public string CityTownVillage { get; set; }
        public int YearofEstablishment { get; set; }
        public int Pincode { get; set; }
        public string? WebsiteLink { get; set; }
        public int GCD_DesignationID { get; set; }
        public string? GCD_MobileNumber { get; set; }
        public string? GCD_LandlineNumber { get; set; }
        public string? TGC_Latitude { get; set; }
        public string? TGC_Longitude { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public string? IPAddress { get; set; }
        public string ParentSSOID { get; set; }
        public string MappingSSOID { get; set; }
        public int? CollegeNAACAccredited { get; set; }
        public string? NAACAccreditedCertificate { get; set; }
        public string? NAACAccreditedCertificatePath { get; set; }
        public string? NAACAccreditedCertificate_Dis_FileName { get; set; }
        public string? NACCValidityDate { get; set; }
        public List<ContactDetailsDataModel> ContactDetailsList { get; set; }
        public List<NearestGovernmentHospitalsDataModel> NearestGovernmentHospitalsList { get; set; }
    }
    public class ContactDetailsDataModel
    {
        public int ContactID { get; set; }
        public int CollegeDetailsID { get; set; }//foreign key of M_CollegeMaster
        public string NameOfPerson { get; set; }
        public int DesignationID { get; set; }
        public string? DesignationName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
    }
    public class NearestGovernmentHospitalsDataModel
    {
        public int NearestGovernmentHospitalsID { get; set; }
        public int CollegeDetailsID { get; set; }//foreign key of M_CollegeMaster
        public string HospitalName { get; set; }
        public string HospitalRegNo { get; set; }
        public string HospitalDocument { get; set; }
        public string HospitalDocumentPath { get; set; }
        public string HospitalDocument_Dis_FileName { get; set; }
        public int HospitalDistance { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int RuralUrban { get; set; }
        public string? RuralUrbanName { get; set; }
        public int DivisionID { get; set; }
        public string? DivisionName { get; set; }
        public int DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public int TehsilID { get; set; }
        public string? TehsilName { get; set; }
        public int PanchayatSamitiID { get; set; }
        public string? PanchayatSamitiName { get; set; }
        public string CityTownVillage { get; set; }
        public int Pincode { get; set; }
    }
}
