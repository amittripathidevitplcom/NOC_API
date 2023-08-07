using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface ISocietyMaster
    {
        List<SocietyMasterDataModels> GetSocietyAllList(int CollegeID);
        List<SocietyMasterDataModel> GetSocietyByID(int SocietyID);
        bool SaveData(SocietyMasterDataModel request);
        bool UpdateData(SocietyMasterDataModel request);
        bool DeleteData(int SocietyID);
        bool IfExists(int SocietyID, string PersonName);

        List<CommonDataModel_DataTable> Check30Female(int CollegeID);
    }
}