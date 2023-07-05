using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface ISocietyMasterRepository
    {
        List<SocietyMasterDataModels> GetSocietyAllList(int CollegeID);
        List<SocietyMasterDataModel> GetSocietyByID(int SocietyID);
        bool SaveData(SocietyMasterDataModel request);
        bool UpdateData(SocietyMasterDataModel request);
        bool DeleteData(int SocietyID);
        bool IfExists(int SocietyID, string PersonName);
    }
}
