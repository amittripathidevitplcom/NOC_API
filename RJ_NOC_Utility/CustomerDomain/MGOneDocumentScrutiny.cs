using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using System.Data;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class MGOneDocumentScrutiny : UtilityBase, IMGOneDocumentScrutiny
    {
        public MGOneDocumentScrutiny(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.DocumentScrutiny_LandDetails(CollageID, RoleID, ApplyNOCID);
        }
        
        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument(DepartmentID,CollageID, RoleID, ApplyNOCID,Type);
        }
        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.DocumentScrutiny_HospitalDetail(CollageID, RoleID, ApplyNOCID);
        }
        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.DocumentScrutiny_CollegeManagementSociety(CollageID, RoleID, ApplyNOCID);
        }
        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.DocumentScrutiny_LegalEntity(CollegeID, RoleID, ApplyNOCID);
        }
        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.DocumentScrutiny_CollegeDetail(CollegeID, RoleID, ApplyNOCID);
        }
        public List<MGOneDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.DocumentScrutiny_BuildingDetails(CollageID, RoleID, ApplyNOCID);
        }
        
        public List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.CheckDocumentScrutinyTabsData(ApplyNOCID, RoleID,CollegeID);
        }

        public List<LOIApplicationDetails_DataModel> GetLOIApplicationList(int RoleID, int UserID, string Status, string ActionName)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.GetLOIApplicationList(RoleID, UserID, Status, ActionName);
        }

        public DataSet GeneratePDF_MedicalGroupLOICData(GenerateLOIPDFDataModel request)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.GeneratePDF_MedicalGroupLOICData(request);
        }

        public List<DataTable> MedicalGroupLOIIssuedReport(int LoginUserID, int RoleID)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.MedicalGroupLOIIssuedReport(LoginUserID, RoleID);
        }     
        public bool SavePDFPath(string Path, int LOIID, int UserID, string Remark)
        {
            return UnitOfWork.MGOneDocumentScrutinyRepository.SavePDFPath(Path, LOIID,UserID,Remark);
        }
    }
}
