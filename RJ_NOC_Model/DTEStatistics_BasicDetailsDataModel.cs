using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_BasicDetailsDataModel
    {
        public int EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }



        public string? AisheCode { get; set; }
        public string? Nameofinstitution { get; set; }
        public string? YearofEstablishment { get; set; }
        public string? StatusPriorToEstablishment { get; set; }
        public string? YearDeclaredUniversityInstitute { get; set; }
        public string? TypeOfInstitution { get; set; }
        public string? OwnershipStatusOfInstitution { get; set; }
        public string? Institutionfromonegender { get; set; }
        public string? InstituteUnnatBharatScheme { get; set; }
        public string? MinorityManagedInstitution { get; set; }
        public string? IsInstitutionNCC { get; set; }
        public int EnrolledStudentInNCC { get; set; }
        public int EnrolledFemaleStudentInNCC { get; set; }
        public int EnrolledTotalStudentInNCC { get; set; }
        public string? IsInstitutionNSS { get; set; }
        public int EnrolledStudentInNSS { get; set; }
        public int EnrolledFemaleStudentInNSS { get; set; }
        public int EnrolledTotalStudentInNSS { get; set; }
        public string? IsspecializedUniversity { get; set; }
        public string? AffiliatedInstitutions { get; set; }

        public List<BasicDetails_SpecialisationDetailsDataModel>? SpecialisationDetails { get; set; }
        public List<BasicDetails_CollegeUnderUniversityDetailsDataModel>? CollegeUnderUniversityDetails { get; set; }

    }
    public class BasicDetails_SpecialisationDetailsDataModel
    {
        public int EntryID { get; set; }
        public int AID { get; set; }
        public string? Specialisation { get; set; }
        public int NoOfCollegesPermanentAffiliation { get; set; }
        public int NoOfCollegesTemporaryAffiliation { get; set; }
        public int Total { get; set; }
    }

    public class BasicDetails_CollegeUnderUniversityDetailsDataModel
    {
        public int EntryID { get; set; }
        public int AID { get; set; }
        public int FID { get; set; }
        public string? College { get; set; }
        public int NoOfColleges { get; set; }
    }
}
