using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDepartmentOfCollegeDocumentScrutiny
    {
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyParamedicalHospitalDetail> DocumentScrutiny_ParamedicalHospitalDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID);


        //get list
        //List<ApplyNOCDataModel> GetNodalOfficerApplyNOCApplicationList(int RoleID, int UserID);
        List<CommonDataModel_DataTable> GetPhysicalVerificationAppliationList(GetPhysicalVerificationAppliationList request);
        List<ApplyNocApplicationDetails_DataModel> GetNodalOfficerApplyNOCApplicationList(int RoleID, int UserID);
        List<CommonDataModel_DataTable> GetApplicationPvDetails(int ApplyNOCID);
        bool FinalSubmitInspectionCommittee(int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyClassWiseStudentDetails> DocumentScrutiny_ClassWiseStudentDetail(int CollageID, int RoleID, int ApplyNOCID);
        List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinySubjectWiseStudentDetails> DocumentScrutiny_SubjectWiseStudentDetail(int CollageID, int RoleID, int ApplyNOCID);
    }
}