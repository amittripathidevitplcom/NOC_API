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
    public class AnimalDocumentScrutiny : UtilityBase, IAnimalDocumentScrutiny
    {
        public AnimalDocumentScrutiny(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID, CollegeID);
        }

        public List<AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID);
        }

        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID);
        }

        public List<AnimalDocuemntScrutinyCommonModel> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument(DepartmentID, CollageID, RoleID, ApplyNOCID, Type);
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID);
        }

        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID);
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID);
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID);
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID);
        }

        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital> DocumentScrutiny_VeterinaryHospital(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_VeterinaryHospital(CollageID, RoleID, ApplyNOCID);
        }

        public List<CommonDataModel_DataTable> GetPhysicalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetPhysicalVerificationAppliationList(request);
        }
        public List<CommonDataModel_DataTable> GetPostVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetPostVerificationAppliationList(request);
        }
        public List<CommonDataModel_DataTable> GetFinalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetFinalVerificationAppliationList(request);
        }
        public List<CommonDataModel_DataTable> GetPreVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetPreVerificationDoneList(request);
        }

        public List<CommonDataModel_DataTable> GetPostVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetPostVerificationDoneList(request);
        }
        public List<CommonDataModel_DataTable> GetFinalVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetFinalVerificationDoneList(request);
        }
        public List<CommonDataModel_DataTable> GetFinalNOCApplicationList(GetPhysicalVerificationAppliationList request)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetFinalNOCApplicationList(request);
        }
        public bool FinalSubmitInspectionCommittee(int ApplyNOCID, int DepartmentID, int UserID, string ActionName)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.FinalSubmitInspectionCommittee(ApplyNOCID, DepartmentID, UserID, ActionName);
        }

        public bool FinalSubmitPreVerification(int ApplyNOCID, int DepartmentID, int UserID, string ActionName,string Remarks)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.FinalSubmitPreVerification(ApplyNOCID, DepartmentID, UserID, ActionName, Remarks);
        }

        public List<CommonDataModel_RNCCheckListData> GetPreVerificationchecklistDetails(string Type, int DepartmentID, int ApplyNOCID, int CreatedBy, int RoleID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetPreVerificationchecklistDetails(Type, DepartmentID, ApplyNOCID, CreatedBy, RoleID);
        }

        public List<ApplyNocApplicationDetails_DataModel> GetApplyNOCApplicationList(int RoleID, int UserID, int DepartmetID, string Action)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetApplyNOCApplicationList(RoleID, UserID, DepartmetID, Action);
        } 
        public List<CommonDataModel_DataTable> GetNOCCourse(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetNOCCourse(ApplyNocID, DepartmentID, CollegeID, Action);
        }

        public List<CommonDataModel_DataTable> GetGeneratePDFData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetGeneratePDFData( ApplyNocID,  DepartmentID,  CollegeID,  Action);
        }

        public bool FinalSavePDFPathandNOC(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark, string Action)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.FinalSavePDFPathandNOC(Path, ApplyNOCID, DepartmentID, RoleID, UserID, NOCIssuedRemark, Action);
        }
        public bool SaveNOCIssueData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.SaveNOCIssueData( ApplyNocID,  DepartmentID,  CollegeID,  Action);
        }        
        public List<ApplyNocApplicationDetails_DataModel> GetDegreeApplyNOCApplicationList(CommonDataModel_ApplicationListFilter request)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.GetDegreeApplyNOCApplicationList(request);
        }     
        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyDepartmentInfrastructure> DocumentScrutiny_DepartmentInfrastructure(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.AnimalDocumentScrutinyRepository.DocumentScrutiny_DepartmentInfrastructure(CollageID, RoleID, ApplyNOCID);
        }
    }
}
