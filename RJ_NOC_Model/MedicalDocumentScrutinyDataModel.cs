using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails 
    {
        public List<DataTable> LandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument
    {
        public List<DataTable> CollegeDocument { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation
    {
        public List<OtherInformationDataModel> OtherInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }  
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail
    {
        public List<HostelDataModel> HostelDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail
    {
        public List<DataTable> HospitalDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyParamedicalHospitalDetail
    {
        public List<ParamedicalHospitalDataModel> HospitalDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation
    {
        public List<AcademicInformationDetailsDataModel> AcademicInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety
    {
        public List<SocietyMasterDataModel> CollegeManagementSocietys { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }    
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity
    {
        public LegalEntityModel legalEntity { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail
    {
        //public CollegeMasterDataModel CollegeDetails { get; set; }
        public List<DataTable> CollegeDetails { get; set; }
        public List<DataTable> CollegeContactDetails { get; set; }
        public List<DataTable> CollegeNearestHospitalsDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentFacilityDetail
    {
        public List<FacilityDetailsDataModel> FacilityDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentRoomDetails
    {
        public List<RoomDetailsDataModel> RoomDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentBuildingDetails
    {
        public List<BuildingDetailsDataModel> BuildingDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentStaffDetails
    {
        public List<StaffDetailDataModel> StaffDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentOldNOCDetails
    {
        public List<OldNocDetailsDataModel> OldNOCDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital
    {
        public List<VeterinaryHospitalDataModel> VeterinaryHospitals { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails
    {
        public List<FarmLandDetailsModel> FarmLandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }    
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyCourtCase
    {
        public List<DataTable> CourtCase { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class GenerateLOIPDFDataModel
    {
        public int LOIID { get; set; }
        public int UserID { get; set; }
        public string Remark { get; set; }
        public int? IsLOIIssued { get; set; }

    }
}