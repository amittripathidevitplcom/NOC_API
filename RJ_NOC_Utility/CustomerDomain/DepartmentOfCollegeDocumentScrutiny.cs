using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DepartmentOfCollegeDocumentScrutiny : UtilityBase, IDepartmentOfCollegeDocumentScrutiny
    {
        public DepartmentOfCollegeDocumentScrutiny(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID);
        }

        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_HostelDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_HospitalDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyParamedicalHospitalDetail> DocumentScrutiny_ParamedicalHospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_ParamedicalHospitalDetail(CollageID, RoleID, ApplyNOCID);
        }

        public List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID)
        {
            return UnitOfWork.MedicalDocumentScrutinyRepository.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID, CollegeID);
        }
        public List<CommonDataModel_DataTable> GetPhysicalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetPhysicalVerificationAppliationList(request);
        }

        public List<ApplyNocApplicationDetails_DataModel> GetNodalOfficerApplyNOCApplicationList(int RoleID, int UserID, string Status, string ActionName, int SessionYear)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetNodalOfficerApplyNOCApplicationList(RoleID, UserID, Status, ActionName,SessionYear);
        }
        public bool FinalSubmitInspectionCommittee(int ApplyNOCID, int CreatedBy)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.FinalSubmitInspectionCommittee(ApplyNOCID, CreatedBy);
        }
        public List<CommonDataModel_DataTable> GetApplicationPvDetails(int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetApplicationPvDetails(ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinyClassWiseStudentDetails> DocumentScrutiny_ClassWiseStudentDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_ClassWiseStudentDetail(CollageID, RoleID, ApplyNOCID);
        }

        public List<DepartmentOfCollegeDocumentScrutinyDataModel_DocumentScrutinySubjectWiseStudentDetails> DocumentScrutiny_SubjectWiseStudentDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_SubjectWiseStudentDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<CommonDataModel_DataTable> GetWorkFlowRemarksByApplicationID(int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetWorkFlowRemarksByApplicationID(ApplyNOCID);
        }
        public List<CommonDataModel_DataTable> GetRevertedTabData(int ApplyNOCID, int CollegeID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetRevertedTabData(ApplyNOCID, CollegeID);
        }
        public bool DCEPdfEsign(int ApplyNOCID, int ParameterID, int CreatedBy)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DCEPdfEsign(ApplyNOCID, ParameterID, CreatedBy);
        }
        public List<CommonDataModel_DataTable> GetClassWiseStaticReport(SearchFilterDataModel request)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetClassWiseStaticReport(request);
        }
        public List<CommonDataModel_DataTable> GetSubjectWiseStaticReport(SearchFilterDataModel request)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetSubjectWiseStaticReport(request);
        }
        public List<ApplyNocApplicationDataModel> GetDCENOCReportData(DCENOCReportSearchFilterDataModel request)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetDCENOCReportData(request);
        }


        public List<CommonDataModel_DataTable> GetGrievanceReport(string FromDate, string ToDate)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetGrievanceReport(FromDate, ToDate);
        }
        public List<DataTable> GetRevertApplicationRemarkByDepartment(int DepartmentID, int ApplicationID, int RoleID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetRevertApplicationRemarkByDepartment(DepartmentID, ApplicationID, RoleID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_FDRDetails> DocumentScrutiny_FDRDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_FDRDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfCollegeDocumentScrutinyDataModel_PaymentDetails> DocumentScrutiny_PaymentDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.DocumentScrutiny_PaymentDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DataTable> GetUnlockApplication(int DepartmentID)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.GetUnlockApplication(DepartmentID);
        }    
        public bool OpenApplication(OpenApplicationDataModel request)
        {
            return UnitOfWork.DepartmentOfCollegeDocumentScrutinyRepository.OpenApplication(request);
        }

    }
}
