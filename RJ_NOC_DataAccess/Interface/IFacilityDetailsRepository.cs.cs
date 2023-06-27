using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IFacilityDetailsRepository
    {
        List<FacilityDetailsDataModels> GetFacilityDetailAllList();
        List<FacilityDetailsDataModel> GetfacilityDetailsByID(int FacilityDetailID);
        bool SaveData(FacilityDetailsDataModel request);
        bool DeleteData(int FacilityDetailID);
    }
}
