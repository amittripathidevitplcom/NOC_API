
using System.Numerics;

namespace RJ_NOC_Model
{
    public class ApplyNocParameterMasterDataModel
    {

    }
    public class ApplyNocParameterDataModel
    {
        public int ApplyNocApplicationID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public string ApplyNocFor { get; set; }
        public decimal FeeAmount { get; set; }
        public int CollegeID { get; set; }
        public string? CollegeName { get; set; }
        public int ApplicationTypeID { get; set; }
        public string? ApplicationTypeName { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public int CreatedBy { get; set; }
        public int? ApplicationStatus { get; set; }
        public int ModifyBy { get; set; }
        public string? IPAddress { get; set; }
        public string? SSOID { get; set; }
        public decimal TotalNocFee { get; set; }
        public decimal LateFee { get; set; }
        public decimal TotalDefaulterCollegePenalty { get; set; }
        public string ExistingLetterofEOA { get; set; }

        public string? DTE_ChangeInTheMinorityStatusoftheInstitution { get; set; }
        //public string DTE_ChangeInTheMinorityStatusoftheInstitution_Dis_FileName { get; set; }
        //public string DTE_ChangeInTheMinorityStatusoftheInstitution_Path { get; set; }

        public List<ApplyNocParameterMasterListDataModel> ApplyNocParameterMasterListDataModel { get; set; }
        public ApplyNocParameterMaster_TNOCExtensionDataModel? ApplyNocParameterMasterList_TNOCExtension { get; set; }
        public ApplyNocParameterMaster_AdditionOfNewSeats60DataModel? ApplyNocParameterMasterList_AdditionOfNewSeats60 { get; set; }

        public ApplyNocParameterMasterList_ChangeInNameOfCollege? ApplyNocParameterMasterList_ChangeInNameOfCollege { get; set; }
        public ApplyNocParameterMasterList_ChangeInPlaceOfCollege? ApplyNocParameterMasterList_ChangeInPlaceOfCollege { get; set; }
        public ApplyNocParameterMasterList_ChangeInCoedtoGirls? ApplyNocParameterMasterList_ChangeInCoedtoGirls { get; set; }
        public ApplyNocParameterMasterList_ChangeInGirlstoCoed? ApplyNocParameterMasterList_ChangeInGirlstoCoed { get; set; }
        public ApplyNocParameterMasterList_ChangeInCollegeManagement? ApplyNocParameterMasterList_ChangeInCollegeManagement { get; set; }
        public ApplyNocParameterMasterList_MergerCollege? ApplyNocParameterMasterList_MergerCollege { get; set; }
        public ApplyNocParameterMaster_TNOCExtensionDataModel? ApplyNocParameterMasterList_NewCourse { get; set; }
        public ApplyNocParameterMaster_TNOCExtensionDataModel? ApplyNocParameterMasterList_NewCourseSubject { get; set; }

        public ApplyNocParameterMaster_TNOCExtensionDataModel? ApplyNocParameterMasterList_TNOCExtOfSubject { get; set; }
        public ApplyNocParameterMaster_TNOCExtensionDataModel? ApplyNocParameterMasterList_PNOCOfSubject { get; set; }
        //noc applicaton late fees
        public List<ApplyNocLateFeeDetailDataModal>? ApplyNocLateFeeDetailList { get; set; }
        public List<DefaulterCollegePenaltyDataModal>? DefaulterCollegePenaltyDetailList { get; set; }

        public ApplyNocParameterMasterList_BankDetails? DTE_BankDetails { get; set; }
        public ApplyNocParameterMasterList_MergerofInstitutions? DTE_MergerofInstitutions { get; set; }
        public ApplyNocParameterMasterList_ChangeinNameofSociety? DTE_ChangeinNameofSociety { get; set; }
        public List<ApplyNocParameterMasterList_IncreaseinIntakeAdditionofCourse>? DTE_IncreaseinIntakeAdditionofCourse_List { get; set; }
        public List<ApplyNocParameterMasterList_AdditionofIntegratedDualDegree>? DTE_AdditionofIntegratedDualDegreeList { get; set; }
        public List<ApplyNocParameterMasterList_ChangeInNameOfCourse>? DTE_ChangeInNameOfCourseList { get; set; }
        public List<ApplyNocParameterMasterList_ReductionInIntake>? DTE_ReductionInIntakeList { get; set; }
        public List<ApplyNocParameterMasterList_TostartNewProgramme>? DTE_TostartNewProgramme_List { get; set; }
        public ApplyNocParameterMasterList_ChangeInNameofInstitution? DTE_ChangeInNameofInstitution { get; set; }
        public ApplyNocParameterMasterList_ChangeofSite_Location? DTE_ChangeofSite_Location { get; set; }
        public List<ApplyNocParameterMasterList_IncreaseInIntake_AdditionofCourse>? DTE_IncreaseInIntake_AdditionofCourse_List { get; set; }


        public List<ApplyNocParameterMasterList_ClosureOfProgram>? DTE_ClosureOfProgramList { get; set; }
        public List<ApplyNocParameterMasterList_ClosureOfCourses>? DTE_ClosureOfCoursesList { get; set; }
        public List<ApplyNocParameterMasterList_MergerOfTheCourse>? DTE_MergerOfTheCourseList { get; set; }

        public List<ApplyNocParameterMasterList_IntroductionOffCampus>? DTE_IntroductionOffCampus_List { get; set; }
        public List<ApplyNocParameterMasterList_CoursesforWorkingProfessionals>? DTE_CoursesforWorkingProfessionals_List { get; set; }



    }



    public class ApplyNocParameterMaster_ddl
    {
        public int ApplyNocID { get; set; }
        public string ApplyNocFor { get; set; }
        public string ApplyNocCode { get; set; }
        public decimal FeeAmount { get; set; }
        public bool IsChecked { get; set; } = false;
    }
    public class ApplyNocParameterMasterListDataModel
    {
        public int ApplyNocID { get; set; }
        public string ApplyNocFor { get; set; }
        public decimal FeeAmount { get; set; }
        public string? ParameterCode { get; set; }
        public string? ApplyNocCode { get; set; }

        public bool IsChecked { get; set; } = false;
    }
    public class ApplyNocParameterMaster_TNOCExtensionDataModel : ApplyNocParameterMasterListDataModel
    {
        public List<ApplyNocParameterCourseDataModel> ApplyNocParameterCourseList { get; set; }
    }
    public class ApplyNocParameterCourseDataModel
    {
        public int ApplyNocID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string? CollegeLevel { get; set; }
        public bool IsChecked { get; set; } = false;
        public List<ApplyNocParameterSubjectDataModel>? ApplyNocParameterSubjectList { get; set; }
    }
    public class ApplyNocParameterSubjectDataModel
    {
        public int ApplyNocID { get; set; }
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool IsChecked { get; set; } = false;
    }
    public class ApplyNocParameterMaster_AdditionOfNewSeats60DataModel : ApplyNocParameterMasterListDataModel
    {
        public List<ApplyNocParameterCourseDataModel> ApplyNocParameterCourseList { get; set; }
    }
    public class ApplyNocFDRDetailsDataModel
    {
        public int ApplyNocFDRID { get; set; }
        public int ApplyNocID { get; set; }
        public int CollegeID { get; set; }
        public string CollegeName { get; set; }
        public string? CourseType { get; set; }
        public string? CollegeType { get; set; }
        public int DepartmentID { get; set; }
        public decimal Amount { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public string FDRNumber { get; set; }
        public decimal FDRAmount { get; set; }
        public string FDRDate { get; set; }
        public string PeriodOfFDR { get; set; }
        public bool IsFDRSubmited { get; set; }
        public string FDRDocument { get; set; }
        public string FDRDocumentPath { get; set; }
        public string FDRDocument_Dis_FileName { get; set; }
        public string FDRExpriyDate { get; set; }
        public string? Action { get; set; }
    }

    // application details
    public class ApplyNocApplicationDataModel
    {
        public int ApplyNocApplicationID { get; set; }
        public int DepartmentID { get; set; }
        public string ApplicationNo { get; set; }
        public int CollegeID { get; set; }
        //College Add Detail
        public string? CollegeName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? SocietyName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CollegeStatus { get; set; }
        public string? CollegeType { get; set; }
        public string? CollegeMedium { get; set; }
        public string? UniversityName { get; set; }
        public string? CollegeMobileNumber { get; set; }
        public string? CollegeLandlineNumber { get; set; }
        public string? FullAddress { get; set; }
        public string? CreateDate { get; set; }
        public string? GeoTagging { get; set; }
        public string? CollegeRegistrationNo { get; set; }

        public string? CollegeMobileNo { get; set; }
        public string? CollegeEmail { get; set; }
        public int ApplicationTypeID { get; set; }
        public string? ApplicationTypeName { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public decimal TotalNocFee { get; set; }
        public decimal? CurrentYearPaymentAmount { get; set; } = 0;
        public decimal LateFee { get; set; }

        public bool? ApplicationStatus { get; set; }
        public bool? IsFinalSubmit { get; set; }
        public bool? IsMakePayment_ApplicationFee { get; set; }
        public bool? IsSaveFDR { get; set; }
        public bool? IsMakePayment { get; set; }
        public bool? IsNOCIssued { get; set; }
        public string? NOCFilePath { get; set; }

        public decimal ApplicationFeeAmount { get; set; }
        public int ServiceId { get; set; }
        public int? PVStage { get; set; }

        public string? RemitterName { get; set; }
        public string? REGTINNO { get; set; }
        public string? DistrictCode { get; set; }
        public string? Adrees { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }


        public string? DTE_ChangeInTheMinorityStatusoftheInstitution { get; set; }
        public string? ManagementType { get; set; }
        public string? GenerateReceipt_DTE { get; set; }
        public string? GenerateReceiptPath_DTE { get; set; }
        public string? ExistingLetterofEOA { get; set; }
        public List<ApplyNocApplicationParameterDataModel> ApplyNocApplicationParameterList { get; set; }



        //dec extra tables
        public List<ApplyNocParameterMasterList_ChangeInNameOfCollege>? ChangeInNameOfCollegeList { get; set; }
        public List<ApplyNocParameterMasterList_ChangeInPlaceOfCollege>? ChangeInPlaceOfCollegeList { get; set; }
        public List<ApplyNocParameterMasterList_ChangeInCoedtoGirls>? ChangeInCoedtoGirlsList { get; set; }
        public List<ApplyNocParameterMasterList_ChangeInGirlstoCoed>? ChangeInGirlstoCoedList { get; set; }
        public List<ApplyNocParameterMasterList_ChangeInCollegeManagement>? ChangeInCollegeManagementList { get; set; }
        public List<ApplyNocParameterMasterList_MergerCollege>? MergerCollegeList { get; set; }

        //DTE
        public ApplyNocParameterMasterList_BankDetails? DTE_BankDetails { get; set; }
        public ApplyNocParameterMasterList_MergerofInstitutions? DTE_MergerofInstitutions { get; set; }
        public ApplyNocParameterMasterList_ChangeinNameofSociety? DTE_ChangeinNameofSociety { get; set; }
        public List<ApplyNocParameterMasterList_IncreaseinIntakeAdditionofCourse>? DTE_IncreaseinIntakeAdditionofCourse_List { get; set; }
        public List<ApplyNocParameterMasterList_AdditionofIntegratedDualDegree>? DTE_AdditionofIntegratedDualDegreeList { get; set; }
        public List<ApplyNocParameterMasterList_ChangeInNameOfCourse>? DTE_ChangeInNameOfCourseList { get; set; }
        public List<ApplyNocParameterMasterList_ReductionInIntake>? DTE_ReductionInIntakeList { get; set; }
        public List<ApplyNocParameterMasterList_TostartNewProgramme>? DTE_TostartNewProgramme_List { get; set; }
        public ApplyNocParameterMasterList_ChangeInNameofInstitution? DTE_ChangeInNameofInstitution { get; set; }
        public ApplyNocParameterMasterList_ChangeofSite_Location? DTE_ChangeofSite_Location { get; set; }
        public List<ApplyNocParameterMasterList_IncreaseInIntake_AdditionofCourse>? DTE_IncreaseInIntake_AdditionofCourse_List { get; set; }


        public List<ApplyNocParameterMasterList_ClosureOfProgram>? DTE_ClosureOfProgramList { get; set; }
        public List<ApplyNocParameterMasterList_ClosureOfCourses>? DTE_ClosureOfCoursesList { get; set; }
        public List<ApplyNocParameterMasterList_MergerOfTheCourse>? DTE_MergerOfTheCourseList { get; set; }

        public List<ApplyNocParameterMasterList_IntroductionOffCampus>? DTE_IntroductionOffCampus_List { get; set; }
        public List<ApplyNocParameterMasterList_CoursesforWorkingProfessionals>? DTE_CoursesforWorkingProfessionals_List { get; set; }



        public List<NOCPdfFileDataModel>? NOCPdfFileDataModel { get; set; }
        public List<DefaulterCollegePenaltyDataModal>? DefaulterCollegePenaltyDetailList { get; set; }
        public List<ApplyNocLateFeeDetailDataModal>? ApplyNocLateFeeDetailList { get; set; }
        public bool? IsOpenNOCApplication { get; set; }
        public string? IsOnlineOfflinePayment { get; set; }


        public string? NodelSSOID { get; set; }
        public string? NodelName { get; set; }
        public string? NodelMobileNo { get; set; }
        public string? NodelCollegeName { get; set; }
        public string? AHInspectionFeeAmount { get; set; }
        public string? AHFDRFeeAmount { get; set; }
        public bool? IsMakeInspectionPayment { get; set; }
        public string? DistrictName { get; set; }
        public string? TehsilName { get; set; }
        public string? NOCStatus { get; set; }
        public string? Status { get; set; }
        public string? RoleName { get; set; }
        public string? SSOID { get; set; }
        public string? NextUser { get; set; }

    }

    public class ApplyNocApplicationParameterDataModel
    {
        public int ApplyNocParameterDetailID { get; set; }
        public int ApplyNocApplicationID { get; set; }
        public int ApplyNocParameterID { get; set; }
        public string ApplyNocFor { get; set; }

        public string? ParameterCode { get; set; }
        public decimal FeeAmount { get; set; }
        public List<ApplyNocApplicationDetailDataModel> ApplyNocApplicationDetailList { get; set; }




    }
    public class ApplyNocApplicationDetailDataModel
    {
        public int ApplyNocApplicationID { get; set; }
        public int ApplyNocParameterID { get; set; }
        public int? CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? SubjectID { get; set; }
        public string? SubjectName { get; set; }

    }

    public class ApplyNocParameterMasterList_ChangeInNameOfCollege
    {
        public int ApplyNocID { get; set; }
        public decimal FeeAmount { get; set; }
        public string NewNameEnglish { get; set; }
        public string NewNameHindi { get; set; }
        public string Dis_DocumentName { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
    }

    public class ApplyNocParameterMasterList_ChangeInPlaceOfCollege
    {
        public int ApplyNocID { get; set; }
        public decimal FeeAmount { get; set; }
        public string PlaceName { get; set; }
        public string Dis_DocumentName { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string Dis_PlaceDocumentName { get; set; }
        public string PlaceDocumentName { get; set; }
        public string PlaceDocumentPath { get; set; }
    }
    public class ApplyNocParameterMasterList_ChangeInCoedtoGirls
    {
        public int ApplyNocID { get; set; }
        public decimal FeeAmount { get; set; }
        public string Dis_ConsentManagementDocument { get; set; }
        public string ConsentManagementDocument { get; set; }
        public string ConsentManagementDocumentPath { get; set; }
    }
    public class ApplyNocParameterMasterList_ChangeInGirlstoCoed
    {
        public int ApplyNocID { get; set; }
        public decimal FeeAmount { get; set; }
        public string Dis_ConsentManagementDocument { get; set; }
        public string ConsentManagementDocument { get; set; }
        public string ConsentManagementDocumentPath { get; set; }
        public string Dis_ConsentStudentDocument { get; set; }
        public string ConsentStudentDocument { get; set; }
        public string ConsentStudentDocumentPath { get; set; }
    }
    public class ApplyNocParameterMasterList_ChangeInCollegeManagement
    {
        public int ApplyNocID { get; set; }
        public string NewSocietyName { get; set; }
        public decimal FeeAmount { get; set; }
        public string Dis_DocumentName { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string Dis_AnnexureDocument { get; set; }
        public string AnnexureDocument { get; set; }
        public string AnnexureDocumentPath { get; set; }
    }
    public class ApplyNocParameterMasterList_MergerCollege
    {
        public int ApplyNocID { get; set; }
        public decimal FeeAmount { get; set; }

        public string Dis_SocietyProposal { get; set; }
        public string SocietyProposal { get; set; }
        public string SocietyProposalPath { get; set; }

        public string Dis_AllNOC { get; set; }
        public string AllNOC { get; set; }
        public string AllNOCPath { get; set; }

        public string Dis_UniversityAffiliation { get; set; }
        public string UniversityAffiliation { get; set; }
        public string UniversityAffiliationPath { get; set; }

        public string Dis_NOCAffiliationUniversity { get; set; }
        public string NOCAffiliationUniversity { get; set; }
        public string NOCAffiliationUniversityPath { get; set; }
        public string Dis_ConsentAffidavit { get; set; }
        public string ConsentAffidavit { get; set; }
        public string ConsentAffidavitPath { get; set; }
        public string Dis_OtherAllNOC { get; set; }
        public string OtherAllNOC { get; set; }
        public string OtherAllNOCPath { get; set; }
        public string Dis_OtherUniversityAffiliation { get; set; }
        public string OtherUniversityAffiliation { get; set; }
        public string OtherUniversityAffiliationPath { get; set; }
        public string Dis_OtherNOCAffiliationUniversity { get; set; }
        public string OtherNOCAffiliationUniversity { get; set; }
        public string OtherNOCAffiliationUniversityPath { get; set; }
        public string Dis_OtherConsentAffidavit { get; set; }
        public string OtherConsentAffidavit { get; set; }
        public string OtherConsentAffidavitPath { get; set; }
        public string Dis_LandTitleCertificate { get; set; }
        public string LandTitleCertificate { get; set; }
        public string LandTitleCertificatePath { get; set; }
        public string Dis_BuildingBluePrint { get; set; }
        public string BuildingBluePrint { get; set; }
        public string BuildingBluePrintPath { get; set; }
        public string Dis_StaffInformation { get; set; }
        public string StaffInformation { get; set; }
        public string StaffInformationPath { get; set; }
    }

    public class ApplyNocParameterFeesDataModel
    {
        public string strCollegeLevel { get; set; }
        public string CollegeLevel { get; set; }
        public decimal FeeAmount { get; set; }
        public int ApplyNocFeeID { get; }
    }

    public class ApplyNocLateFeeDetailDataModal
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public int LateFeeID { get; set; }
        public string FeesType { get; set; }
        public decimal FeesAmount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal? TotalFeesAmount { get; set; }
    }
    public class DefaulterCollegePenaltyDataModal
    {
        public int DepartmentID { get; set; }
        public int PenaltyID { get; set; }
        public int RequestID { get; set; }
        public string Penaltyfor { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal? TotalPenaltyAmount { get; set; }
    }
    public class ApplyNOCCourseSubjectListDataModal
    {
        public int ApplyNocApplicationID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int ApplyNocParameterID { get; set; }
    }
    public class ApplyNOCCourseListDataModal
    {
        public int ApplyNocApplicationID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public List<ApplyNOCSubjectListCourseWiseDataModal> SubjectList { get; set; }
    }
    public class ApplyNOCSubjectListCourseWiseDataModal
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int ApplyNocParameterID { get; set; }
    }

    public class ApplyNocOfflinePaymentModal
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public int ApplyNOCID { get; set; }
        public int CollegeID { get; set; }
        public int PaymentMode { get; set; }
        public string BankName { get; set; }
        public decimal Amount { get; set; }
        public string DateofIssuance { get; set; }
        public string DateofExpiry { get; set; }
        public string FileName { get; set; }
        public string Dis_FileName { get; set; }
        public string FilePath { get; set; }
        public string ActionName { get; set; }
        public string? PaymentType { get; set; }
    }




    //DTE Apply NOC
    public class ApplyNocParameterMasterList_BankDetails
    {
        public int BankDetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string OldBankName { get; set; }
        public string NewBankName { get; set; }
        public string OldBranchName { get; set; }
        public string NewBranchName { get; set; }
        public string OldIFSC { get; set; }
        public string NewIFSC { get; set; }
        public string OldAccountNumber { get; set; }
        public string NewAccountNumber { get; set; }
        public decimal FeeAmount { get; set; }
    }
    public class ApplyNocParameterMasterList_MergerofInstitutions
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int InstituteID1 { get; set; }
        public int InstituteID2 { get; set; }
        public int MergeInstituteID { get; set; }
        public decimal FeeAmount { get; set; }

        public string TrustType { get; set; }
        public string NewTrustName { get; set; }
        public string NewInstituteName { get; set; }
    }
    public class ApplyNocParameterMasterList_ChangeinNameofSociety
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }

        public string CurrentName { get; set; }
        public string NewName { get; set; }
        public decimal FeeAmount { get; set; }

        public string ChangeType { get; set; }
        public string OldAddress { get; set; }
        public string NewAddress { get; set; }
    }

    public class ApplyNocParameterMasterList_IncreaseinIntakeAdditionofCourse
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int Intake { get; set; }
        public decimal FeeAmount { get; set; }

        public string? CourseName { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }

    public class ApplyNocParameterMasterList_AdditionofIntegratedDualDegree
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int Intake { get; set; }
        public decimal FeeAmount { get; set; }


        public string? CourseName { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }
    public class ApplyNocParameterMasterList_ChangeInNameOfCourse
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int NewCourseID { get; set; }
        public decimal FeeAmount { get; set; }
        public string? CourseName { get; set; }
        public string? NewCourseName { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }
    public class ApplyNocParameterMasterList_ReductionInIntake
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int CurrentIntake { get; set; }
        public int ReducedIntake { get; set; }
        public decimal FeeAmount { get; set; }

        public string? CourseName { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }

    public class ApplyNocParameterMasterList_TostartNewProgramme
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string CourseName { get; set; }
        public int CourseID { get; set; }
        public int Intake { get; set; }
        public decimal FeeAmount { get; set; }

        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }
    public class ApplyNocParameterMasterList_ChangeInNameofInstitution
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string CurrentCollegeName { get; set; }
        public string NewCollegeName { get; set; }
        public string NewCollegeNameHi { get; set; }
        public decimal FeeAmount { get; set; }
    }

    public class ApplyNocParameterMasterList_ChangeofSite_Location
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }

        public string CurrentAddress { get; set; }
        public string NewAddress { get; set; }
        public decimal FeeAmount { get; set; }
    }
    public class ApplyNocParameterMasterList_IncreaseInIntake_AdditionofCourse
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string CourseName { get; set; }
        public int CourseID { get; set; }
        public int Intake { get; set; }
        public int UpdatedIntake { get; set; }
        public decimal FeeAmount { get; set; }



        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }

    public class ApplyNocParameterMasterList_ClosureOfProgram
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int StreamID { get; set; }
        public int CourseLevelID { get; set; }
        public decimal FeeAmount { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }

    public class ApplyNocParameterMasterList_ClosureOfCourses
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int CurrentIntake { get; set; }
        public int ReducedIntake { get; set; }
        public decimal FeeAmount { get; set; }
        public string CourseName { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }

    public class ApplyNocParameterMasterList_MergerOfTheCourse
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID1 { get; set; }
        public int CourseID2 { get; set; }
        public int MergerCourseID { get; set; }
        public decimal FeeAmount { get; set; }
        public string CourseName { get; set; }


        public int CourseIntake1 { get; set; }
        public int CourseIntake2 { get; set; }
        public int MergerIntake { get; set; }
        public string? CourseName2 { get; set; }
        public string? MergeCourseName { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }

    public class ApplyNocParameterMasterList_IntroductionOffCampus
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int Intake { get; set; }
        public decimal FeeAmount { get; set; }
        public string DocumentName { get; set; }
        public string? DocumentPath { get; set; }

        public string? CourseName { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }

    public class ApplyNocParameterMasterList_CoursesforWorkingProfessionals
    {
        public int DetailID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int CourseID { get; set; }
        public int Intake { get; set; }
        public decimal FeeAmount { get; set; }
        public string? CourseName { get; set; }
        public string? StreamName { get; set; }
        public string? CourseLevelName { get; set; }
    }
    public class ApplyNoc_MinisterFile
    {
        public int ApplyNocID { get; set; }
        public string? MinisterFile { get; set; }
    }
}