using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ILegalEntity
    {
        List<CommonDataModel_DataTable> GetAllLegalEntity();
        bool IfExists(int LegalEntityID, string RegistrationNo);
        bool SaveData(LegalEntityModel request);
        List<LegalEntityListModel> GetLegalEntityList(string SSOID);
        List<LegalEntityListModel> ViewlegalEntityDataByID(int LegalEntityID,string SSOID);
        List<LegalEntityListModel> GetLegalEntityBySSOID(string SSOID);
        bool CheckExistsLegalEntity(string SSOID, int RoleID);
    }
}
