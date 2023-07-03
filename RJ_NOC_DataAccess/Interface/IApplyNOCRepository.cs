using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IApplyNOCRepository
    {
        List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID);
        bool DocumentScrutiny(int ApplyNOCID, int RoleID, int UserID, string ActionType);
        bool DocumentScrutiny_Temp(DocumentScrutiny_TempDataModel DocumentScrutiny_Temp);
    }
}
