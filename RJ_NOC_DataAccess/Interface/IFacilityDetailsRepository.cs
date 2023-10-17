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
        List<FacilityDetailsDataModels> GetFacilityDetailAllList(int CollegeID,int ApplyNOCID);
        List<FacilityDetailsDataModel> GetfacilityDetailsByID(int FacilityDetailID, int CollegeID);
        bool SaveData(FacilityDetailsDataModel request);
        bool DeleteData(int FacilityDetailID);
    }
}
