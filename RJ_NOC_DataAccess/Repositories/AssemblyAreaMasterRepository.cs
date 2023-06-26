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
    public class AssemblyAreaMasterRepository : IAssemblyAreaMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public AssemblyAreaMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAssemblyAreaList()
        {
            string SqlQuery = " exec USP_AssemblyArea_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AssemblyAreaMaster.GetAssemblyAreaList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<AssemblyAreaMasterDataModel> GetAssemblyAreaIDWise(int AssemblyAreaID)
        {
            string SqlQuery = " exec USP_AssemblyArea_GetData @AssemblyAreaID ='" + AssemblyAreaID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AssemblyAreaMaster.GetAssemblyAreaIDWise");

            List<AssemblyAreaMasterDataModel> dataModels = new List<AssemblyAreaMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<AssemblyAreaMasterDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
        public bool SaveData(AssemblyAreaMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_AssemblyArea_AddUpdate";

            SqlQuery += " @AssemblyAreaID='" + request.AssemblyAreaID + "',";
            SqlQuery += " @DistrictID='" + request.DistrictID + "',";
            SqlQuery += " @AssemblyAreaName='" + request.AssemblyAreaName + "',";
            SqlQuery += " @ActiveStatus='" + request.ActiveStatus + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "AssemblyAreaMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int AssemblyAreaID)
        {
            string SqlQuery = " Update M_AssemblyAreaMaster set ActiveStatus=0 , DeleteStatus=1  WHERE AssemblyAreaID='" + AssemblyAreaID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AssemblyAreaMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int AssemblyAreaID,int DistrictID, string AssemblyAreaName)
        {
            string SqlQuery = " select AssemblyAreaName from M_AssemblyAreaMaster Where AssemblyAreaName='" + AssemblyAreaName.Trim() + "' and AssemblyAreaID !='" + AssemblyAreaID + "'  and DistrictID ='" + DistrictID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AssemblyAreaMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        
    }
}
