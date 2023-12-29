using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails
    {
        public List<LandDetailsDataModel> LandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument
    {
        public List<DataTable> CollegeDocument { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation
    {
        public List<OtherInformationDataModel> OtherInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }  
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail
    {
        public List<HostelDataModel> HostelDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail
    {
        public List<HospitalMasterDataModel> HospitalDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyParamedicalHospitalDetail
    {
        public List<ParamedicalHospitalDataModel> HospitalDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation
    {
        public List<AcademicInformationDetailsDataModel> AcademicInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety
    {
        public List<SocietyMasterDataModel> CollegeManagementSocietys { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }    
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity
    {
        public LegalEntityModel legalEntity { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail
    {
        //public CollegeMasterDataModel CollegeDetails { get; set; }
        public List<DataTable> CollegeDetails { get; set; }
        public List<DataTable> CollegeContactDetails { get; set; }
        public List<DataTable> CollegeNearestHospitalsDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail
    {
        public List<FacilityDetailsDataModel> FacilityDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails
    {
        public List<RoomDetailsDataModel> RoomDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails
    {
        public List<BuildingDetailsDataModel> BuildingDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails
    {
        public List<StaffDetailDataModel> StaffDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails
    {
        public List<OldNocDetailsDataModel> OldNOCDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyClassWiseStudentDetails
    {
        public List<ClassWiseStudentDetailsDataModel> ClassWiseStudentDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinySubjectWiseStudentDetails
    {
        public List<SubjectWiseStatisticsDetailsDataModel> SubjectWiseStudentDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCourseDetail
    {
        public List<DataTable> CourseDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class GenerateDTENOCPDFDataModel
    {
        public int ApplyNOCID { get; set; }
        public int UserID { get; set; }
        public string Remark { get; set; }
        public int? IsNOCIssued { get; set; }

    }
}