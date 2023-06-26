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
    public class FacilityDetailsRepository : IFacilityDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public FacilityDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool SaveData(FacilityDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Trn_College_FacilityDetails_IU  ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',@FacilityDetailID='" + request.FacilityDetailID + "',@FacilitiesID='" + request.FacilitiesID + "',@FacilitiesUrl='" + request.FacilitiesUrl + "',@MinSize='" + request.MinSize +"'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "FacilityDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<FacilityDetailsDataModels> GetFacilityDetailAllList(int CollegeID)
        {
            string SqlQuery = " exec USP_Trn_College_FacilityDetails_GetData @CollegeID = '" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "FacilityDetails.GetFacilityDetailAllList");

            List<FacilityDetailsDataModels> dataModels = new List<FacilityDetailsDataModels>();
            FacilityDetailsDataModels dataModel = new FacilityDetailsDataModels();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public List<FacilityDetailsDataModel> GetfacilityDetailsByID(int FacilityDetailID,int CollegeID)
        {
            string SqlQuery = " exec USP_Trn_College_FacilityDetails_GetData @FacilityDetailID='" + FacilityDetailID + "', @CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "FacilityDetails.GetfacilityDetailsByID");

            List<FacilityDetailsDataModel> dataModels = new List<FacilityDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<FacilityDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
       
        public bool DeleteData(int FacilityDetailID)
        {
            string SqlQuery = " Update Trn_College_FacilityDetails set ActiveStatus=0 , DeleteStatus=1  WHERE FacilityDetailID='" + FacilityDetailID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "FacilityDetails.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        
    }
}
