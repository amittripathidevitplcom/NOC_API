using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails 
    {
        public List<LandDetailsDataModel> LandDetails { get; set; }
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
        public List<HospitalMasterDataModel> HospitalDetails { get; set; }
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


    //public class DocumentScrutiny_Action
    //{
    //    public string Action { get; set; }
    //    public string Remark { get; set; }

    //}
}