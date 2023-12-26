using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DepartmentOfTechnicalDocumentScrutiny : UtilityBase, IDepartmentOfTechnicalDocumentScrutiny
    {
        public DepartmentOfTechnicalDocumentScrutiny(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID);
        }
        
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument(DepartmentID,CollageID, RoleID, ApplyNOCID,Type);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_OtherInformation(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_HostelDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_AcademicInformation(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_FacilityDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_RoomDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_StaffDetails(CollageID, RoleID, ApplyNOCID);
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.DepartmentOfTechnicalDocumentScrutinyRepository.DocumentScrutiny_OldNOCDetails(CollageID, RoleID, ApplyNOCID);
        }
    }
}
