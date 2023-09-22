using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class DocumentMaster : UtilityBase, IDocumentMaster
    {
        public DocumentMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<CommonDataModel_DataTable> GetAllDocument(int DepartmentID)
        {
            return UnitOfWork.DocumentMasterRepository.GetAllDocument(DepartmentID);
        }
        public List<DocumentMasterDataModel> GetDocumentMasterIDWise(int DocumentMasterID)
        {
            return UnitOfWork.DocumentMasterRepository.GetDocumentMasterIDWise(DocumentMasterID);
        }
        public bool SaveData(DocumentMasterDataModel request)
        {
            return UnitOfWork.DocumentMasterRepository.SaveData(request);
        }
        public bool UpdateData(DocumentMasterDataModel request)
        {
            return UnitOfWork.DocumentMasterRepository.UpdateData(request);
        }
        public bool DeleteData(int DocumentMasterID)
        {
            return UnitOfWork.DocumentMasterRepository.DeleteData(DocumentMasterID);
        }

        public bool IfExists(int DocumentMasterID,int DepartmentID, string DocumentName)
        {
            return UnitOfWork.DocumentMasterRepository.IfExists(DocumentMasterID, DepartmentID, DocumentName);
        }
    }
}
