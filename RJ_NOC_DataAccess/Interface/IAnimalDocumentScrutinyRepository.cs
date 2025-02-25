using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IAnimalDocumentScrutinyRepository
    {
        List<AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocuemntScrutinyCommonModel> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type);
        List<AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID);
        //List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID);
        //List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID);
        List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID);
        List<AnimalDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital> DocumentScrutiny_VeterinaryHospital(int CollageID, int RoleID, int ApplyNOCID);

        List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID);

        List<CommonDataModel_DataTable> GetPhysicalVerificationAppliationList(GetPhysicalVerificationAppliationList request);
        List<CommonDataModel_DataTable> GetPostVerificationAppliationList(GetPhysicalVerificationAppliationList request);
        List<CommonDataModel_DataTable> GetFinalVerificationAppliationList(GetPhysicalVerificationAppliationList request);
        List<CommonDataModel_DataTable> GetPreVerificationDoneList(GetPhysicalVerificationAppliationList request);
        List<CommonDataModel_DataTable> GetPostVerificationDoneList(GetPhysicalVerificationAppliationList request);
        List<CommonDataModel_DataTable> GetFinalVerificationDoneList(GetPhysicalVerificationAppliationList request);
        List<CommonDataModel_DataTable> GetFinalNOCApplicationList(GetPhysicalVerificationAppliationList request);
        bool FinalSubmitInspectionCommittee(int ApplyNOCID, int DepartmentID, int UserID, string ActionName);
        bool FinalSubmitPreVerification(int ApplyNOCID, int DepartmentID, int UserID, string ActionName, string Remarks);

        List<CommonDataModel_RNCCheckListData> GetPreVerificationchecklistDetails(string Type, int DepartmentID, int ApplyNOCID, int CreatedBy, int RoleID);
        List<ApplyNocApplicationDetails_DataModel> GetApplyNOCApplicationList(int RoleID, int UserID, int DepartmentID, string Action);
        List<CommonDataModel_DataTable> GetNOCCourse(int ApplyNocID, int DepartmentID, int CollegeID, string Action);

        List<CommonDataModel_DataTable> GetGeneratePDFData(int ApplyNocID, int DepartmentID, int CollegeID, string Action);
        bool FinalSavePDFPathandNOC(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark, string Action);
        public bool SaveNOCIssueData(int ApplyNocID, int DepartmentID, int CollegeID, string Action);

        List<ApplyNocApplicationDetails_DataModel> GetDegreeApplyNOCApplicationList(CommonDataModel_ApplicationListFilter request);
        List<AnimalDocumentScrutinyDataModel_DocumentScrutinyDepartmentInfrastructure> DocumentScrutiny_DepartmentInfrastructure(int CollageID, int RoleID, int ApplyNOCID);
    }
}
