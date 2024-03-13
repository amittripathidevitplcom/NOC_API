using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Azure.Core;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ActivityDetails : UtilityBase, IActivityDetails
    {
        public ActivityDetails(IRepositories unitOfWork) : base(unitOfWork)
        {
        }
        public List<ActivityDetailsDataModels> GetActivityDetailAllList(int CollegeID, int ApplyNOCID)
        {
            return UnitOfWork.ActivityDetailsRepository.GetActivityDetailAllList(CollegeID, ApplyNOCID);
        }
        public List<ActivityDetailsDataModel> GetActivityDetailsByID(int ActivityDetailID, int CollegeID)
        {
            return UnitOfWork.ActivityDetailsRepository.GetActivityDetailsByID(ActivityDetailID,CollegeID);
        }
        public bool SaveData(ActivityDetailsDataModel request)
        {
            return UnitOfWork.ActivityDetailsRepository.SaveData(request);
        }

        public bool DeleteData(int ActivityDetailID)
        {
            return UnitOfWork.ActivityDetailsRepository.DeleteData(ActivityDetailID);
        }
    }
}
