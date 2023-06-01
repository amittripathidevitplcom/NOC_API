using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using System.Linq;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IProjectMasterRepository
    {
        List<CommonDataModel_DataTable> GetAllProject();
        List<ProjectMasterDataModel> GetProjectIDWise(int ProjectID);
        bool SaveData(ProjectMasterDataModel request);
        bool UpdateData(ProjectMasterDataModel request);
        bool DeleteData(int ProjectID);
        bool IfExists(int ProjectID, string ProjectName);
        List<ProjectMasterDataModel_CandidateInfo> GetProjectCandidateInfo(int ProjectID);
        bool SaveProjectCandidateInfo(CandidateDocumentDataModel request);

        //Document Scrutiny
        List<DataTable> GetDocumentScrutiny_ProjectCandidateInfo(int ProjectID);
        bool DocumentScrutiny_ApprovedReject(ProjectMaster_DocumentScrutiny_ApprovedReject request);
        bool Save_ProjectIPDetails(ProjectMasterDataModel_ProjectIPDetails request);
        List<ProjectMasterDataModel_ProjectIPDetails> GetProjectIPDetails(int ProjectID);

    }

}

