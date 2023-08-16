using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class AnimalDocuemntScrutinyCommonModel
    {
        public List<DataTable> lstDatatable { get; set; }
        public List<DataTable> lstFinalRemarkList { get; set; }
    }

    public class AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity
    {
        public LegalEntityModel legalEntity { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety
    {
        public List<SocietyMasterDataModel> CollegeManagementSocietys { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails
    {
        public List<LandDetailsDataModel> LandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class AnimalDocumentScrutinyDataModel_DocumentFacilityDetail
    {
        public List<FacilityDetailsDataModel> FacilityDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AnimalDocumentScrutinyDataModel_DocumentRoomDetails
    {
        public List<RoomDetailsDataModel> RoomDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AnimalDocumentScrutinyDataModel_DocumentBuildingDetails
    {
        public List<BuildingDetailsDataModel> BuildingDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AnimalDocumentScrutinyDataModel_DocumentStaffDetails
    {
        public List<StaffDetailDataModel> StaffDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails
    {
        public List<OldNocDetailsDataModel> OldNOCDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation
    {
        public List<AcademicInformationDetailsDataModel> AcademicInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation
    {
        public List<OtherInformationDataModel> OtherInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital
    {
        public List<VeterinaryHospitalDataModel> VeterinaryHospitals { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
}
