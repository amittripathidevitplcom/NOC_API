using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using System.Xml.Linq;
using System.Data;

namespace FIH_EPR_Utility.CustomerDomain
{
    public class CommonFuncation : UtilityBase, ICommonFuncation
    {
        public CommonFuncation(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public string UploadFilePath()
        {
            return UnitOfWork.CommonFuncationRepository.UploadFilePath();
        }

        public List<CommonDataModel_DocumentMasterList> DocumentMasterList(string DocumentType, int ProjectID)
        {
            return UnitOfWork.CommonFuncationRepository.DocumentMasterList(DocumentType, ProjectID);
        }

        public List<CommonDataModel_EmployeeDocumentList> ProjectWise_EmployeeDocumentList(int ProjectID, int EmployeeID)
        {
            return UnitOfWork.CommonFuncationRepository.ProjectWise_EmployeeDocumentList(ProjectID, EmployeeID);
        }

        public List<DataTable> EmployeeProfileDetails(int EmployeeID)
        {
            return UnitOfWork.CommonFuncationRepository.EmployeeProfileDetails(EmployeeID);
        }
    }
}
