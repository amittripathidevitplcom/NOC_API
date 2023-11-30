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
        public List<DataTable> CollegeContactDetails { get; set; }
        public List<DataTable> CollegeNearestHospitalsDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class MGOneDocumentScrutinyDataModel_DocumentBuildingDetails
    {
        public List<BuildingDetailsDataModel> BuildingDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    
}