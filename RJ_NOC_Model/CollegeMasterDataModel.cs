
using System.Numerics;

namespace RJ_NOC_Model
{
    public class CollegeMasterDataModel
    {
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public string TypeofCollege { get; set; }
        public int CollegeStatusID { get; set; }
        public string CollegeLogo { get; set; }
        public string CollegeLogoPath { get; set; }
        public string CollegeLogo_Dis_FileName { get; set; }
        public int PresentCollegeStatusID { get; set; }
        public int CollegeTypeID { get; set; }
        public int? CollegeLevelID { get; set; }
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
        public string? YearofEstablishmentName { get; set; }
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
        public string? CollegeStatus { get; set; }
        public int? CityID { get; set; }
        public int? ManagementTypeID { get; set; }
        public string? OtherUniversityName { get; set; }
        public string? FinancialYear { get; set; }
        public List<ContactDetailsDataModel> ContactDetailsList { get; set; }
        public List<NearestGovernmentHospitalsDataModel> NearestGovernmentHospitalsList { get; set; }
        public List<CollegeLevelDetailsDataModel> CollegeLevelDetails { get; set; }

        //Medical Group 1 
        public int? AnnualIntakeStudents { get; set; }
        public decimal? SocietyCapitalAssets { get; set; }
        public decimal? SocietyIncome { get; set; }
        public decimal? TotalProjectCost { get; set; }
        public string? FundingSources { get; set; }
        public string? FundingSourcesPath { get; set; }
        public string? FundingSources_Dis_FileName { get; set; }
        public int? LegalEntityID { get; set; }
        public string? CollegeLevelName { get; set; }



        public int? AffiliationDocument { get; set; }
        public string? AffiliationDocumentCertificate { get; set; }
        public string? AffiliationDocumentCertificatePath { get; set; }
        public string? AffiliationDocumentCertificate_Dis_FileName { get; set; }


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
        public int? CityID { get; set; }
        public string? CityName { get; set; }
    }

    public class CollegeLevelDetailsDataModel
    {
        public int AID { get; set; }
        public int CollegeID { get; set; }
        public int ID { get; set; }
        public string? Name { get; set; }
    }

    public class TotalCollegeReportSearchFilter
    {
        public int DepartmentID { get; set; }
        public int UniversityID { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public string CollegeName { get; set; }
    }

    public class DCECollegesReportSearchFilter
    {
        public int DepartmentID { get; set; }
        public string CollegeName { get; set; }
        public int NOCStatusID { get; set; }
        public int ApplicationStatusID { get; set; }
        public string FromSubmittedDate { get; set; }
        public string ToSubmittedDate { get; set; }
        public int CollegeTypeID { get; set; }
        public string CollegeMobileNo { get; set; }
        public string CollegeEmail { get; set; }
        public int StatusOfCollegeID { get; set; }
        public int CollegeLevelID { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public int SubDivisionID { get; set; }
        public int TehsilID { get; set; }
        public int ParliamentID { get; set; }
        public int AssemblyID { get; set; }
        public string PermanentAddress { get; set; }
        public string CityTownVillage { get; set; }
        public string PinCode { get; set; }
        public string LandlineNo { get; set; }
        public string AdditionalMobileNo { get; set; }
        public string FaxNo { get; set; }
        public string Website { get; set; }
        public int NodalOfficerID { get; set; }
        public int EstablishmentYearID { get; set; }
        public int ApplicationTypeID { get; set; }
        public int LandAreaID { get; set; }
        public int LandDocumentID { get; set; }
        public int LandConversionID { get; set; }
        public int AgricultureLandArea { get; set; }
        public int CommercialLandArea { get; set; }
        public int InstitutionalLandArea { get; set; }
        public int ResidentialLandArea { get; set; }
        public string AgricultureKhasraNo { get; set; }
        public string CommercialKhasraNo { get; set; }
        public string InstitutionalKhasraNo { get; set; }
        public string ResidentialKhasraNo { get; set; }
        public string FromAffidavitDate { get; set; }
        public string ToAffidavitDate { get; set; }
        public int UniversityID { get; set; }
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public int UrbanRuralID { get; set; }
        public int CollegeNAACID { get; set; }
        public string AISHECode { get; set; }
        public string ApplicationId { get; set; }
    }


}
