using Azure.Core;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IUserManualDocumentMaster
    {
        List<UserManualDocumentMasterDataModel_List> GetUserManualDocumentMasterList(int DepartmentID, string Type);
        List<UserManualDocumentMasterDataModel> GetUserManualDocumentMasterIDWise(int ID);
        bool SaveData(UserManualDocumentMasterDataModel request);
        bool DeleteData(int ID);

         //bool IfExists(int ID,  string Name);
    }
}
