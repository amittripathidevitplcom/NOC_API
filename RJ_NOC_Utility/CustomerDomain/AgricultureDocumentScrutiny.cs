using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class AgricultureDocumentScrutiny : UtilityBase,IAgricultureDocumentScrutiny
    {
        public AgricultureDocumentScrutiny(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID);
        }

        public List<AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID);
        }

        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID);
        }

        public List<AgricultureDocuemntScrutinyCommonModel> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type);
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID);
        }
        
        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID);
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID);
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID);
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID);
        }

        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails> DocumentScrutiny_FarmLandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.DocumentScrutiny_FarmLandDetails(CollageID, RoleID, ApplyNOCID);
        }

        public List<CommonDataModel_DataTable> GetPhysicalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetPhysicalVerificationAppliationList(request);
        }
        public List<CommonDataModel_DataTable> GetPostVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetPostVerificationAppliationList(request);
        }
        public List<CommonDataModel_DataTable> GetFinalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetFinalVerificationAppliationList(request);
        }
        public List<CommonDataModel_DataTable> GetPreVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetPreVerificationDoneList(request);
        }

        public List<CommonDataModel_DataTable> GetPostVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetPostVerificationDoneList(request);
        }
        public List<CommonDataModel_DataTable> GetFinalVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetFinalVerificationDoneList(request);
        }
        public List<CommonDataModel_DataTable> GetFinalNOCApplicationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetFinalNOCApplicationList(request);
        }
        public bool FinalSubmitInspectionCommittee(int ApplyNOCID, int DepartmentID, int UserID, string ActionName)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.FinalSubmitInspectionCommittee(ApplyNOCID, DepartmentID, UserID, ActionName);
        }

        public bool FinalSubmitPreVerification(int ApplyNOCID, int DepartmentID, int UserID, string ActionName)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.FinalSubmitPreVerification(ApplyNOCID, DepartmentID, UserID, ActionName);
        }

        public List<CommonDataModel_RNCCheckListData> GetPreVerificationchecklistDetails(string Type, int DepartmentID, int ApplyNOCID, int CreatedBy, int RoleID)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetPreVerificationchecklistDetails(Type, DepartmentID, ApplyNOCID, CreatedBy, RoleID);
        }

        public List<ApplyNocApplicationDetails_DataModel> GetApplyNOCApplicationList(int RoleID, int UserID, int DepartmetID, string Action)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetApplyNOCApplicationList(RoleID, UserID, DepartmetID, Action);
        }
        public List<CommonDataModel_DataTable> GetNOCCourse(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetNOCCourse(ApplyNocID, DepartmentID, CollegeID, Action);
        }

        public List<CommonDataModel_DataTable> GetGeneratePDFData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.GetGeneratePDFData(ApplyNocID, DepartmentID, CollegeID, Action);
        }

        public bool FinalSavePDFPathandNOC(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark, string Action)
        {
            return UnitOfWork.AgricultureDocumentScrutinyRepository.FinalSavePDFPathandNOC(Path, ApplyNOCID, DepartmentID, RoleID, UserID, NOCIssuedRemark, Action);
        }

    }
}
