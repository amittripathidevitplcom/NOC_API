using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ILegalEntityRepository
    {
        List<CommonDataModel_DataTable> GetAllProject();
        bool IfExists(int LegalEntityID, string RegistrationNo, string AadhaarNo,string LegalEntityType);
        bool SaveData(LegalEntityModel request);
        List<LegalEntityListModel> GetLegalEntityList(string SSOID);
        List<LegalEntityListModel> ViewlegalEntityDataByID(int LegalEntityID,string SSOID);
        List<LegalEntityListModel> GetLegalEntityBySSOID(string SSOID);
        List<LegalEntityListModel> GetLegalEntityBySSOIDFForPDF(string SSOID);
        bool CheckExistsLegalEntity(string SSOID, int RoleID);
    }
}
