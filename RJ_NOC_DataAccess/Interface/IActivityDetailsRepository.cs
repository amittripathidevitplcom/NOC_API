using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using System.Data;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IActivityDetailsRepository
    {
        List<ActivityDetailsDataModels> GetActivityDetailAllList(int CollegeID,int ApplyNOCID);
        List<ActivityDetailsDataModel> GetActivityDetailsByID(int ActivityDetailID, int CollegeID);
        bool SaveData(ActivityDetailsDataModel request);
        bool DeleteData(int ActivityDetailID);
    }
}
