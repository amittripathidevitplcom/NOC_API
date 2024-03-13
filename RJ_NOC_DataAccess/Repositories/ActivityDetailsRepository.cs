using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;

namespace RJ_NOC_DataAccess.Repositories
{
    public class ActivityDetailsRepository : IActivityDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ActivityDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool SaveData(ActivityDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Trn_College_ActivityDetails_IU  ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',@ActivityDetailID='" + request.ActivityDetailID + "',@ActivityID='" + request.ActivityID + "',@NoOf='" + request.NoOf + "',@ActivityUrl='" + request.ActivityUrl + "',@MinSize='" + request.MinSize + "',@CreatedBy='" + request.CreatedBy + "',@ModifyBy='" + request.ModifyBy + "',@IPAddress='" + IPAddress + "',@IsAvailable='" + request.IsAvailable + "',@Remark='"+request.Remark + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ActivityDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<ActivityDetailsDataModels> GetActivityDetailAllList(int CollegeID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_Trn_College_ActivityDetails_GetData @CollegeID = '" + CollegeID + "',@ApplyNOCID = '" + ApplyNOCID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ActivityDetails.GetActivityDetailAllList");

            List<ActivityDetailsDataModels> dataModels = new List<ActivityDetailsDataModels>();
            ActivityDetailsDataModels dataModel = new ActivityDetailsDataModels();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public List<ActivityDetailsDataModel> GetActivityDetailsByID(int ActivityDetailID,int CollegeID)
        {
            string SqlQuery = " exec USP_Trn_College_ActivityDetails_GetData @ActivityDetailID='" + ActivityDetailID + "', @CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ActivityDetails.GetActivityDetailsByID");

            List<ActivityDetailsDataModel> dataModels = new List<ActivityDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ActivityDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
       
        public bool DeleteData(int ActivityDetailID)
        {
            string SqlQuery = " Update Trn_College_ActivityDetails set ActiveStatus=0 , DeleteStatus=1  WHERE ActivityDetailID='" + ActivityDetailID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ActivityDetails.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        
    }
}
