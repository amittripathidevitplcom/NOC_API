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

    }
}
