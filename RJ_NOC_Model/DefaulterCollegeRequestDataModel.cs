using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DefaulterCollegeRequestDataModel
    {
        public string SSOID { get; set; }
        public int RequestID { get; set; }
        public int DepartmentID { get; set; }
        public string? EverAppliedNOC { get; set; }
        public string? IsPNOC { get; set; }
        public string? FirstNOCDoc { get; set; }
        public string? FirstNOCDocPath { get; set; }
        public string? FirstNOCDoc_DisName { get; set; }
        public string? LastNOCDoc { get; set; }
        public string? LastNOCDocPath { get; set; }
        public string? LastNOCDoc_DisName { get; set; }
        public string? LatestAffiliationDoc { get; set; }
        public string? LatestAffiliationDocPath { get; set; }
        public string? LatestAffiliationDoc_DisName { get; set; }
        public string? ResultLastSessionDoc { get; set; }
        public string? ResultLastSessionDocPath { get; set; }
        public string? ResultLastSessionDoc_DisName { get; set; }
        public string? LastSessionProofOfExaminationDoc { get; set; }
        public string? LastSessionProofOfExaminationDocPath { get; set; }
        public string? LastSessionProofOfExaminationDoc_DisName { get; set; }
        public string? LastApplicationNo { get; set; }
        public string? LastApplicationSubmittedDate { get; set; }
        public string? CollegeName { get; set; }
        public string? CollegeNameHi { get; set; }
        public string? CollegeEmail { get; set; }
        public string? CollegeMobileNo { get; set; }
        public int? DivisionID { get; set; }
        public string? DivisionName { get; set; }
        public int? DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public int? UniversityID { get; set; }
        public string? UniversityName { get; set; }
        public int? CollegeTypeID { get; set; }
        public string? CollegeType { get; set; }
        public int? CollegeLevelID { get; set; }
        public string? CollegeLevel { get; set; }
        public string? EstablishmentYearID { get; set; }
        public string? EstablishmentYear { get; set; }
        public int? CollegePresentStatusID { get; set; }
        public string? CollegePresentStatus { get; set; }
        public string? CaseOperatedTNOCLevel { get; set; }
        public int? LastSessionOfTNOCID { get; set; }
       
        public string? LastSessionOfTNOC { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int? UserID { get; set; }
        public string? PendingCaseNOC { get; set; }
        public string? PendingCaseDoc { get; set; }
        public string? PendingCaseDocPath { get; set; }
        public string? PendingCaseDoc_DisName { get; set; }
    }
    public class DefaulterCollegeSearchFilterDataModel
    {
        public int? UserID { get; set; }
        public int? DepartmentID { get; set; }
        public int? SessionYear { get; set; }
        public int? RequestID { get; set; }
        public string? SSOID { get; set; }
        public string? ApplicationStatus { get; set; }
    }
}
