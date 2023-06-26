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
using System.Net;

namespace RJ_NOC_DataAccess.Repositories
{
    public class ParliamentAreaMasterRepository: IParliamentAreaMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ParliamentAreaMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetParliamentAreaList()
        {
            string SqlQuery = " exec USP_ParliamentArea_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ParliamentAreaMaster.GetParliamentAreaList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<ParliamentAreaMasterDataModel> GetParliamentAreaIDWise(int ParliamentAreaID)
        {
            string SqlQuery = " exec USP_ParliamentArea_GetData @ParliamentAreaID ='" + ParliamentAreaID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ParliamentAreaMaster.GetParliamentAreaIDWise");

            List<ParliamentAreaMasterDataModel> dataModels = new List<ParliamentAreaMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<ParliamentAreaMasterDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
        public bool SaveData(ParliamentAreaMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ParliamentArea_AddUpdate";

            SqlQuery += " @ParliamentAreaID='" + request.ParliamentAreaID + "',";
            SqlQuery += " @DistrictID='" + request.DistrictID + "',";
            SqlQuery += " @ParliamentAreaName='" + request.ParliamentAreaName + "',";
            SqlQuery += " @ActiveStatus='" + request.ActiveStatus + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "ParliamentAreaMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int ParliamentAreaID)
        {
            string SqlQuery = " Update M_ParliamentAreaMaster set ActiveStatus=0 , DeleteStatus=1  WHERE ParliamentAreaID='" + ParliamentAreaID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ParliamentAreaMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int ParliamentAreaID, int DistrictID, string ParliamentAreaName)
        {
            string SqlQuery = " select ParliamentAreaName from M_ParliamentAreaMaster Where ParliamentAreaName='" + ParliamentAreaName.Trim() + "' and DistrictID ='" + DistrictID + "' and ParliamentAreaID !='" + ParliamentAreaID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ParliamentAreaMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
