using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IMGOneNOCRepository
    {
        public List<CommonDataModel_DataTable> GetNOCApplicationList(int RoleID, int UserID, string Status, string ActionName);
    }
}
