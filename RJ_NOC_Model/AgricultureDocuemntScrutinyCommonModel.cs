using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class AgricultureDocuemntScrutinyCommonModel
    {
        public List<DataTable> lstDatatable { get; set; }
        public List<DataTable> lstFinalRemarkList { get; set; }
    }

    public class AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity
    {
        public LegalEntityModel legalEntity { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety
    {
        public List<SocietyMasterDataModel> CollegeManagementSocietys { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails
    {
        public List<LandDetailsDataModel> LandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail
    {
        public List<FacilityDetailsDataModel> FacilityDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AgricultureDocumentScrutinyDataModel_DocumentRoomDetails
    {
        public List<RoomDetailsDataModel> RoomDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails
    {
        public List<BuildingDetailsDataModel> BuildingDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AgricultureDocumentScrutinyDataModel_DocumentStaffDetails
    {
        public List<StaffDetailDataModel> StaffDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails
    {
        public List<OldNocDetailsDataModel> OldNOCDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
    public class AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation
    {
        public List<AcademicInformationDetailsDataModel> AcademicInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation
    {
        public List<OtherInformationDataModel> OtherInformations { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }

    public class AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails
    {
        public List<FarmLandDetailsModel> FarmLandDetails { get; set; }
        public List<DataTable> DocumentScrutinyFinalRemarkList { get; set; }
    }
}
