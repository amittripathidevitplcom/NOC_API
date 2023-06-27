using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IDocumentMaster
    {
        List<CommonDataModel_DataTable> GetAllDocument();
        List<DocumentMasterDataModel> GetDocumentMasterIDWise(int DocumentMasterID);
        bool SaveData(DocumentMasterDataModel request);
        bool UpdateData(DocumentMasterDataModel request);
        bool DeleteData(int DocumentMasterID);
        bool IfExists(int DocumentMasterID, string DocumentName);
    }
}
