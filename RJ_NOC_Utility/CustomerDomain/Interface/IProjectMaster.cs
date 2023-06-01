using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IProjectMaster
    {
        List<CommonDataModel_DataTable> GetAllProject();
     


        List<ProjectMasterDataModel> GetProjectIDWise(int ProjectID);
        bool SaveData(ProjectMasterDataModel request);
        bool SaveProjectCandidateInfo(CandidateDocumentDataModel request);
        bool UpdateData(ProjectMasterDataModel request);
        bool DeleteData(int ProjectID);
        bool IfExists(int ProjectID, string ProjectName);

        List<ProjectMasterDataModel_CandidateInfo> GetProjectCandidateInfo(int ProjectID);
        List<ProjectMasterDataModel_ProjectIPDetails> GetProjectIPDetails(int ProjectID);

        //Document Scrutiny
        List<DataTable> GetDocumentScrutiny_ProjectCandidateInfo(int ProjectID);
        bool DocumentScrutiny_ApprovedReject(ProjectMaster_DocumentScrutiny_ApprovedReject request);
        bool Save_ProjectIPDetails(ProjectMasterDataModel_ProjectIPDetails request);

    }
}