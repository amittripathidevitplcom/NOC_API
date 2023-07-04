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

namespace RJ_NOC_DataAccess.Repository
{
    public class WorkFlowMasterRepository : IWorkFlowMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public WorkFlowMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool SaveData(WorkFlowMasterDataModel request)
        {
            string WorkFlowMasterDetail_Str = CommonHelper.GetDetailsTableQry(request.WorkFlowMasterDetailList, "Temp_WorkFlowMasterDetail");
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveWorkFlowMaster @WorkFlowMasterID='" + request.WorkFlowMasterID + "',@DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += "@RoleLevelID = '" + request.RoleLevelID + "',@RoleID = '" + request.RoleID + "',@IPAddress = '" + IPAddress + "',@WorkFlowMasterDetail_Str='" + WorkFlowMasterDetail_Str + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "WorkFlowMastreMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool IfExists(int WorkFlowMasterID, int RoleID, int DepartmentID)
        {
            string SqlQuery = " USP_IfExistsWorkFlowMaster @RoleID='" + RoleID + "',@DepartmentID = '" + DepartmentID + "',@WorkFlowMasterID='" + WorkFlowMasterID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "WorkFlowMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public List<WorkFlowMasterDataModel> GetWorkFlowMasterList(int WorkFlowMasterID)
        {
            string SqlQuery = " exec USP_GetWorkFlowMasterList @WorkFlowMasterID='" + WorkFlowMasterID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");
            List<WorkFlowMasterDataModel> listdataModels = new List<WorkFlowMasterDataModel>();
            WorkFlowMasterDataModel dataModels = new WorkFlowMasterDataModel();
            if (WorkFlowMasterID == 0)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                listdataModels = JsonConvert.DeserializeObject<List<WorkFlowMasterDataModel>>(JsonDataTable_Data);
            }
            else
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataModels.WorkFlowMasterID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["WorkFlowMasterID"]);
                    dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DepartmentID"]);
                    dataModels.DepartmentName = dataSet.Tables[0].Rows[0]["DepartmentName"].ToString();
                    dataModels.RoleLevelID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["RoleLevelID"]);
                    dataModels.RoleLevelName = dataSet.Tables[0].Rows[0]["RoleLevelName"].ToString();
                    dataModels.RoleID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["RoleID"]);
                    dataModels.RoleName = dataSet.Tables[0].Rows[0]["RoleName"].ToString();
                    dataModels.ActiveStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ActiveStatus"]);
                    dataModels.DeleteStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["DeleteStatus"]);

                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<WorkFlowMasterDetail> WorkFlowDetailDataModel_Item = JsonConvert.DeserializeObject<List<WorkFlowMasterDetail>>(JsonDataTable_Data);
                    dataModels.WorkFlowMasterDetailList = WorkFlowDetailDataModel_Item;
                    listdataModels.Add(dataModels);
                }
            }
            return listdataModels;
        }

    }
}
