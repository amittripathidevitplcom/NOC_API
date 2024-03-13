using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RJ_NOC_Model;

namespace RJ_NOC_Utility.CustomerDomain.Interface
{
    public interface IActivityDetails
    {
        List<ActivityDetailsDataModels> GetActivityDetailAllList(int CollegeID, int ApplyNOCID);
        List<ActivityDetailsDataModel> GetActivityDetailsByID(int ActivityDetailID,int CollegeID);
        bool SaveData(ActivityDetailsDataModel request);
        bool DeleteData(int ActivityDetailID);
    }
}
