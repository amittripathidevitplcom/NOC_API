using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class StaffDetailDataModel
    {
        public int StaffDetailID { get; set; }
        public string TeachingType { get; set; }
        public string SubjectName { get; set; }
        public string RoleName { get; set; }
        public int SubjectID { get; set; }
        public string PersonName { get; set; }
        public int RoleID { get; set; }
        public string MobileNo { get; set; }
        public string? Email { get; set; }
        public int HighestQualification { get; set; }
        public string? HighestQualificationName { get; set; }
        public int NumberofExperience { get; set; }
        public string AadhaarNo { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfAppointment { get; set; }
        public string DateOfJoining { get; set; }
        public string SpecializationSubject { get; set; }
        public string RoleMapping { get; set; }
        public decimal Salary { get; set; }
        public string StaffStatus { get; set; }
        public string PFDeduction { get; set; }
        public string ESINumber { get; set; }
        public string? UANNumber { get; set; }
        public string ResearchGuide { get; set; }
        public int? ProfessionalQualificationID { get; set; }
        public string? StreamSubject { get; set; }
        public string? UniversityBoardInstitutionName { get; set; }
        public int? PassingYearID { get; set; }
        public string Marks { get; set; }
        public string ProfilePhoto { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public string? ProfilePhoto_Dis_FileName { get; set; }
        public string AadhaarCard { get; set; }
        public string? AadhaarCardPath { get; set; }
        public string? AadhaarCard_Dis_FileName { get; set; }
        public string? PANCard { get; set; }
        public string? PANNo { get; set; }
        public string? PANCardPath { get; set; }
        public string? PANCard_Dis_FileName { get; set; }
        public string ExperienceCertificate { get; set; }
        public string? ExperienceCertificatePath { get; set; }
        public string? ExperienceCertificate_Dis_FileName { get; set; }

        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public string? IPAddress { get; set; }

        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string? Action { get; set; }
        public string? Remark { get; set; }

        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }
        public string? Gender { get; set; }
        public string? DesignationRegistrationNo { get; set; }
        public string? DetailofJob { get; set; }
        public int? AHDepartmentID { get; set; }
        public string? NETQualified { get; set; }
        public string? DepartmentName { get; set; }

        public string? HaveCouncilRegistration { get; set; }
        public string? CouncilRegistrationNo { get; set; }
        public string? CouncilRegCertificate { get; set; }
        public string? CouncilRegCertificatePath { get; set; }
        public string? CouncilRegCertificate_Dis { get; set; }
        public string? AppointmentLetter { get; set; }
        public string? AppointmentLetterPath { get; set; }
        public string? AppointmentLetter_Dis { get; set; }
        public string? StaffBankStatement { get; set; }
        public string? StaffBankStatementPath { get; set; }
        public string? StaffBankStatement_Dis { get; set; }

        public List<EducationalQualificationDetails_StaffDetail> EducationalQualificationDetails { get; set; }
    }
    public class StaffDetailDataModel_Excel
    {
        public string FileName { get; set; }
        public List<StaffDetailDataModel> AllStaffExcelData { get; set; }

    }

    public class EducationalQualificationDetails_StaffDetail
    {
        public int EducationalQualificationID { get; set; }
        public int ProfessionalQualificationID { get; set; }
        public string? ProfessionalQualification { get; set; }
        public string StreamSubject { get; set; }
        public string UniversityBoardInstitutionName { get; set; }
        public int PassingYearID { get; set; }
        public string PassingYear { get; set; }
        public string Marks { get; set; }
        public string UploadDocument { get; set; }
        public string? UploadDocumentPath { get; set; }
        public string? UploadDocument_Dis_FileName { get; set; }
    }
}
