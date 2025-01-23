using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails
    {
        public List<LandDetailsDataModel> LandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument
    {
        public List<DataTable> CollegeDocument { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    
    public class MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail
    {
        public List<HospitalMasterDataModel> HospitalDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety
    {
        public List<SocietyMasterDataModel> CollegeManagementSocietys { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }    
    public class MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity
    {
        public LegalEntityModel legalEntity { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail
    {
        //public CollegeMasterDataModel CollegeDetails { get; set; }
        public List<DataTable> CollegeDetails { get; set; }
        public List<DataTable> CollegeGeoTaggingDetails { get; set; }
        public List<DataTable> CollegeContactDetails { get; set; }
        public List<DataTable> CollegeNearestHospitalsDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MGOneDocumentScrutinyDataModel_DocumentBuildingDetails
    {
        public List<BuildingDetailsDataModel> BuildingDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MGOneDocumentScrutinyDataModel_FDRDetail
    {
        public List<DataTable> FDRDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MGOneDocumentScrutinyDataModel_PaymentDetail
    {
        public List<DataTable> PaymentDetail { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DocumentScrutinySave_DataModel_MGOne
    {
        public int ApplyNOCID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public int ActionID { get; set; }
        public int DepartmentID { get; set; }
        public string? Remark { get; set; }
        public int NextRoleID { get; set; }
        public int NextUserID { get; set; }
        public int NextActionID { get; set; }
        public string? UploadDocument { get; set; }
        public string? MOMDocument { get; set; }        
    }
    public class DocumentSave_DataModel_MGOne
    {
        public int ApplyNOCID { get; set; }
        public string? MeetingScheduleDate { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }
        
    }
    public class InspectionReport_DataModel_MGOne
    {
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public int ApplyNOCID { get; set; }
        public int UserID { get; set; }
        public string UploadDocument { get; set; }
    }
    public class GenerateNOC_DataModel_MGOne
    {
        public int ApplyNOCID { get; set; }
        public int DepartmentID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public string? NOCIssuedRemark { get; set; }
        public string? Status { get; set; }
        public int ActionID { get; set; }
        public int NextRoleID { get; set; }
        public int NextUserID { get; set; }
    }
}