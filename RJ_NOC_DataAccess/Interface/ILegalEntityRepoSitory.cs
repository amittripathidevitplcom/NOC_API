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
        bool IfExists(int LegalEntityID, string RegistrationNo);
        bool SaveData(LegalEntityModel request);
    }
}
