using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
   
    public interface IDocumentMasterRepository
    {
        List<CommonDataModel_DataTable> GetAllDocument(int DepartmentID);
        List<DocumentMasterDataModel> GetDocumentMasterIDWise(int DocumentMasterID);
        bool SaveData(DocumentMasterDataModel request);
        bool UpdateData(DocumentMasterDataModel request);
        bool DeleteData(int DocumentMasterID);
        bool IfExists(int DocumentMasterID,int DepartmentID, string DocumentName);
    }
}
