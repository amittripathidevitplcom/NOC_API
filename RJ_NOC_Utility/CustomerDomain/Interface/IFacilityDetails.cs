using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IFacilityDetails
    {
        List<FacilityDetailsDataModels> GetFacilityDetailAllList();
        List<FacilityDetailsDataModel> GetfacilityDetailsByID(int FacilityDetailID);
        bool SaveData(FacilityDetailsDataModel request);
        bool DeleteData(int FacilityDetailID);

    }
}
