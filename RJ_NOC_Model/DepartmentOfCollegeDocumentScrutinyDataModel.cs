using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLandDetails
    {
        public List<LandDetailsDataModel> LandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument
    {
        public List<DataTable> CollegeDocument { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyOtherInformation
    {
        public List<OtherInformationDataModel> OtherInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }  
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHostelDetail
    {
        public List<HostelDataModel> HostelDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail
    {
        public List<HospitalMasterDataModel> HospitalDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyParamedicalHospitalDetail
    {
        public List<ParamedicalHospitalDataModel> HospitalDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation
    {
        public List<AcademicInformationDetailsDataModel> AcademicInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety
    {
        public List<SocietyMasterDataModel> CollegeManagementSocietys { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }    
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLegalEntity
    {
        public LegalEntityModel legalEntity { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }   
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail
    {
        //public CollegeMasterDataModel CollegeDetails { get; set; }
        public List<DataTable> CollegeDetails { get; set; }
        public List<DataTable> CollegeContactDetails { get; set; }
        public List<DataTable> CollegeNearestHospitalsDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentFacilityDetail
    {
        public List<FacilityDetailsDataModel> FacilityDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentRoomDetails
    {
        public List<RoomDetailsDataModel> RoomDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentBuildingDetails
    {
        public List<BuildingDetailsDataModel> BuildingDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentStaffDetails
    {
        public List<StaffDetailDataModel> StaffDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentOldNOCDetails
    {
        public List<OldNocDetailsDataModel> OldNOCDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyClassWiseStudentDetails
    {
        public List<ClassWiseStudentDetailsDataModel> ClassWiseStudentDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinySubjectWiseStudentDetails
    {
        public List<SubjectWiseStatisticsDetailsDataModel> SubjectWiseStudentDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class SearchFilterDataModel
    {
        public int InstitutionID { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public int SubdivisionID { get; set; }
        public int TehsilID { get; set; }
        public int ParliamentAreaID { get; set; }

    }
}