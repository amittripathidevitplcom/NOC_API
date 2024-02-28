using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RJ_NOC_Model;
using System.Threading.Tasks;
using RJ_NOC_DataAccess.Interface;
using System.Data.SqlClient;
using System.Data;
using RJ_NOC_DataAccess.Common;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Diagnostics.Metrics;

namespace RJ_NOC_DataAccess.Repositories
{
    public class GeoTaggingRepository : IGeoTaggingRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public GeoTaggingRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        //public List<GeoTaggingDataModels> AppCollegeSSOLogin(string LoginSSOID)
        //{
        //    string SqlQuery = " exec USP_AppSSOLogin @LoginSSOID='" + LoginSSOID + "'";
        //    DataTable dataTable = new DataTable();
        //    dataTable = _commonHelper.Fill_DataTable(SqlQuery, "GeoTagging.GetAllData");

        //    List<GeoTaggingDataModels> dataModels = new List<GeoTaggingDataModels>();
        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
        //    dataModels = JsonConvert.DeserializeObject<List<GeoTaggingDataModels>>(JsonDataTable_Data);
        //    return dataModels;
        //}
        public List<CommonDataModel_DataTable> AppCollegeSSOLogin(string LoginSSOID)
        {
            string SqlQuery = " exec USP_AppSSOLogin @LoginSSOID = '" + LoginSSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "GeoTagging.AppCollegeSSOLogin");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }
        public List<CommonDataModel_DataTable> GetAPPApplicationCollegeList(string LoginSSOID, string Type)
        {
            string SqlQuery = " exec USP_APPApplicationCollegeList @LoginSSOID='" + LoginSSOID + "',@Type='"+ Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "GeoTagging.GetDataList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetAPPApplicationCollege_DashboardCount(string LoginSSOID, string Type)
        {
            string SqlQuery = " exec USP_APPApplicationCollege_DashboardCount @LoginSSOID='" + LoginSSOID + "',@Type='" + Type + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "GeoTagging.GetAPPApplicationCollege_DashboardCount");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool SaveData(GeoTaggingDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@CollegeID='{0}',", request.CollegeID);
            sb.AppendFormat("@Image1='{0}',", request.Image1);
            sb.AppendFormat("@Image2='{0}',", request.Image2);
            sb.AppendFormat("@TGC_Latitude='{0}',", request.TGC_Latitude);
            sb.AppendFormat("@TGC_Longitude='{0}',", request.TGC_Longitude);
            sb.AppendFormat("@Action='{0}'", "UpdateCollegeData");

            string SqlQuery = $" exec USP_APPApplicationCollege_Add  {sb.ToString()}";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "GeoTagging.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool ReadNotification(NotificationDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@NotificationID='{0}'", request.NotificationID);

            string SqlQuery = $" exec USP_UpdateNotification  {sb.ToString()}";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "GeoTagging.ReadNotification");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<CommonDataModel_DataTable> AppNotificationList(string LoginSSOID)
        {
            string SqlQuery = " exec USP_AppNotificationList @LoginSSOID = '" + LoginSSOID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "GeoTagging.AppNotificationList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public bool SaveInspectionGeoTagging(InspectionGeoTaggingDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@ApplicationID='{0}',", request.ApplicationID);
            sb.AppendFormat("@GT_Latitude='{0}',", request.GT_Latitude);
            sb.AppendFormat("@GT_Longitude='{0}',", request.GT_Longitude);
            sb.AppendFormat("@GT_Image1='{0}',", request.GT_Image1);
            sb.AppendFormat("@GT_Image2='{0}',", request.GT_Image2);
            sb.AppendFormat("@GT_CreatedBy='{0}'", request.GT_CreatedBy);
            string SqlQuery = $" exec USP_APPApplicationCollege_Add  {sb.ToString()}";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "GeoTagging.SaveInspectionGeoTagging");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}