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


        public BasicDetails_InstituteHeadDetailsDataModel InstituteHeadDetails { get; set; }
        public BasicDetails_NodalOfficerDetailsDataModel NodalOfficerDetails { get; set; }
        public BasicDetails_AffiliationDetailsDataModel AffiliationDetails { get; set; }


        public string ManagementOfTheInstitution { get; set; }
        public string IsEveningCollege { get; set; }
        public string AutonomousInstitute { get; set; }
        public string MinorityCommunityType { get; set; }

        public int EnrolledStudentInNCCOtherInstitute { get; set; }
        public int EnrolledFemaleStudentInNCCOtherInstitute { get; set; }


        public string SpecialisedUniversity { get; set; }
        public string OtherSpecialisedUniversity { get; set; }
        public string WhetherTheCollegeRunningDiplomaLevelCourse { get; set; }
        public string DiplomaLevelCourse { get; set; }
        public string OtherDiplomaCourse { get; set; }
        public string WhetherAwardsDegreethroughAnyUniversity { get; set; }
        public string OtherUniversityName { get; set; }

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



    public class BasicDetails_InstituteHeadDetailsDataModel
    {
        public int EntryID { get; set; }
        public int AID { get; set; }
        public string NameOfUniversityNodalOfficerForAISHE { get; set; }
        public string Email { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNo { get; set; }
    }
    public class BasicDetails_NodalOfficerDetailsDataModel
    {
        public int EntryID { get; set; }
        public int AID { get; set; }
        public string NameOfUniversityNodalOfficerForAISHE { get; set; }
        public string Email { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNo { get; set; }
    }
    public class BasicDetails_AffiliationDetailsDataModel
    {
        public int EntryID { get; set; }
        public int AID { get; set; }
        public string NameStatutorybody { get; set; }
        public string AffiliationYear { get; set; }
        public string AffiliatedOtherUniversity { get; set; }
    }
}
