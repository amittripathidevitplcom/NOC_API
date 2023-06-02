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

        bool SaveData(LegalEntityModel request);
    }
}
