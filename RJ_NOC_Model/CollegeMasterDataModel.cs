
namespace RJ_NOC_Model
{
    public class CollegeMasterDataModel
    {
        public int UserID { get; set; }
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public string CollegeStatus { get; set; }
        public string CollegeLogo { get; set; }
        public string PresentCollegeStatus { get; set; }
        public int CollegeTypeID { get; set; }
        public int CollegeLevelID { get; set; }
        public string CollegeNameEn { get; set; }
        public string CollegeNameHi { get; set; }
        public Int16 AISHECodeStatus { get; set; }
        public string AISHECode { get; set; }
        public string CollegeMedium { get; set; }
        public int UniversityID { get; set; }
        public long MobileNumber { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Int16 RuralUrban { get; set; }
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
        public string WebsiteLink { get; set; }
        public string GCD_Designation { get; set; }
        public Int64 GCD_MobileNumber { get; set; }
        public Int64 GCD_LandlineNumber { get; set; }
        public string TGC_Latitude { get; set; }
        public string TGC_Longitude { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public string? IPAddress { get; set; }
        public List<ContactDetailsDataModel> ContactDetailsList { get; set; }
    }
    public class ContactDetailsDataModel
    {
        public int ContactID { get; set; }
        public int CollegeDetailsID { get; set; }
        public string NameOfPerson { get; set; }
        public string Designation { get; set; }
        public long MobileNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
