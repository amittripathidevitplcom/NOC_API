using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Data;

namespace FIH_EPR_Utility.CustomerDomain
{
    public class ProjectMaster : UtilityBase, IProjectMaster
    {
        public ProjectMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllProject()
        {
            return UnitOfWork.ProjectMasterRepository.GetAllProject();
        }
        public List<ProjectMasterDataModel> GetProjectIDWise(int ProjectID)
        {
            return UnitOfWork.ProjectMasterRepository.GetProjectIDWise(ProjectID);
        }
        public bool SaveData(ProjectMasterDataModel request)
        {
            return UnitOfWork.ProjectMasterRepository.SaveData(request);
        }
        public bool UpdateData(ProjectMasterDataModel request)
        {
            return UnitOfWork.ProjectMasterRepository.UpdateData(request);
        }
        public bool DeleteData(int ProjectID)
        {
            return UnitOfWork.ProjectMasterRepository.DeleteData(ProjectID);
        }
        
        public bool IfExists(int ProjectID, string ProjectName)
        {
            return UnitOfWork.ProjectMasterRepository.IfExists(ProjectID, ProjectName);
        }

        public List<ProjectMasterDataModel_CandidateInfo> GetProjectCandidateInfo(int ProjectID)
        {
            return UnitOfWork.ProjectMasterRepository.GetProjectCandidateInfo(ProjectID);
        }

        public bool SaveProjectCandidateInfo(CandidateDocumentDataModel request)
        {
            return UnitOfWork.ProjectMasterRepository.SaveProjectCandidateInfo(request);
        }

        //Document Scrutiny
        public List<DataTable> GetDocumentScrutiny_ProjectCandidateInfo(int ProjectID)
        {
            return UnitOfWork.ProjectMasterRepository.GetDocumentScrutiny_ProjectCandidateInfo(ProjectID);
        }

        public bool DocumentScrutiny_ApprovedReject(ProjectMaster_DocumentScrutiny_ApprovedReject request)
        {
            return UnitOfWork.ProjectMasterRepository.DocumentScrutiny_ApprovedReject(request);
        }

        public bool Save_ProjectIPDetails(ProjectMasterDataModel_ProjectIPDetails request)
        {
            return UnitOfWork.ProjectMasterRepository.Save_ProjectIPDetails(request);
        }

        public List<ProjectMasterDataModel_ProjectIPDetails> GetProjectIPDetails(int ProjectID)
        {
            return UnitOfWork.ProjectMasterRepository.GetProjectIPDetails(ProjectID);
        }
    }
}
