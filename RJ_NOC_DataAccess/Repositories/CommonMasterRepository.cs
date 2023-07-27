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
using Azure.Core;

namespace RJ_NOC_DataAccess.Repositories
{
    public class CommonMasterRepository : ICommonMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CommonMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetCommonMasterList(int DepartmentID)
        {
            string SqlQuery = " exec USP_CommonMaster_GetData";
            SqlQuery += " @DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonMaster.GetCommonMasterList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonMasterDataModel> GetCommonMasterIDWise(int ID)
        {
            string SqlQuery = " exec USP_CommonMaster_GetData '" + ID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonMaster.GetCommonMasterIDWise");

            List<CommonMasterDataModel> dataModels = new List<CommonMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonMasterDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
        public bool SaveData(CommonMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CommonMaster_AddUpdate";

            SqlQuery += " @ID='" + request.ID + "',";
            SqlQuery += " @Type='" + request.Type + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @Name='" + request.Name + "',";
            SqlQuery += " @ActiveStatus='" + request.ActiveStatus + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommonMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int ID)
        {
            string SqlQuery = " Update M_CommonMaster set ActiveStatus=0 , DeleteStatus=1  WHERE ID='" + ID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CommonMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int ID, int DepartmentID, string Type, string Name)
        {
            string SqlQuery = " select Name from M_CommonMaster Where Name='" + Name.Trim() + "'  and DepartmentID ='" + DepartmentID + "' and ID !='" + ID + "' and Type='" + Type + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ParliamentAreaMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}

