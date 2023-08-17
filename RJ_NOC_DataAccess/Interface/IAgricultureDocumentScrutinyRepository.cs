using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IAgricultureDocumentScrutinyRepository
    {
        List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocuemntScrutinyCommonModel> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type);
        List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID);
        //List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID);
        //List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID);
        List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID);
        List<AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails> DocumentScrutiny_FarmLandDetails(int CollageID, int RoleID, int ApplyNOCID);

        List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID);
    }
}
