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
using System.Xml.Linq;

namespace RJ_NOC_DataAccess.Repository
{
    public class CommonFuncationRepository : ICommonFuncationRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CommonFuncationRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
         
        public string UploadFilePath()
        {
            string uploadFilePath = "";
            string SqlQuery = " select * from V#ImagePath ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery);
            if (dataTable.Rows.Count > 0)
            {
                uploadFilePath = dataTable.Rows[0]["ImagePath"].ToString();
            }
            return uploadFilePath;
        }
          

        public List<CommonDataModel_DepartmentMasterList> GetDepartmentList()
        {
            string SqlQuery = "exec USP_GetDepartmentList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetDepartmentList");

            List<CommonDataModel_DepartmentMasterList> dataModels = new List<CommonDataModel_DepartmentMasterList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DepartmentMasterList>>(JsonDataTable_Data);
            return dataModels;

        }
        public List<CommonDataModel_SchemeListByDepartment> GetSchemeListByDepartment(int DepatmentID)
        {
            string SqlQuery = "exec USP_GetSchemeListByDepartment @DepatmentID=" + DepatmentID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSchemeListByDepartment");

            List<CommonDataModel_SchemeListByDepartment> dataModels = new List<CommonDataModel_SchemeListByDepartment>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SchemeListByDepartment>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_ModuleMasterList> GetModuleList()
        {
            string SqlQuery = "exec USP_GetModuleList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetModuleList");

            List<CommonDataModel_ModuleMasterList> dataModels = new List<CommonDataModel_ModuleMasterList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_ModuleMasterList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_SubModuleListByModule> GetSubModuleListByModule(int ModuleID)
        {
            string SqlQuery = "exec USP_GetSubmoduleListByModule @ModuleID=" + ModuleID;
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetSubModuleListByModule");
            List<CommonDataModel_SubModuleListByModule> dataModels = new List<CommonDataModel_SubModuleListByModule>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_SubModuleListByModule>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_LevelMasterList> GetLevelList()
        {
            string SqlQuery = "exec USP_GetLevelList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetLevelList");

            List<CommonDataModel_LevelMasterList> dataModels = new List<CommonDataModel_LevelMasterList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_LevelMasterList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_RoleListByLevel> GetRoleListByLevel(int LevelID)
        {
            string SqlQuery = "exec USP_GetRoleListByLevel @LevelID=" + LevelID;
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetRoleListByLevel");
            List<CommonDataModel_RoleListByLevel> dataModels = new List<CommonDataModel_RoleListByLevel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_RoleListByLevel>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_ActionHeadList> GetActionHeadList()
        {
            string SqlQuery = "exec USP_GetActionHeadList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionHeadList");

            List<CommonDataModel_ActionHeadList> dataModels = new List<CommonDataModel_ActionHeadList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_ActionHeadList>>(JsonDataTable_Data);
            return dataModels;
        }
        public List<CommonDataModel_ActionListByActionHead> GetActionListByActionHead(int ActionHeadID)
        {
            string SqlQuery = "exec USP_GetActionListByActionHead @ActionHeadID=" + ActionHeadID;
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.GetActionListByActionHead");

         
            List<CommonDataModel_ActionListByActionHead> dataModels = new List<CommonDataModel_ActionListByActionHead>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_ActionListByActionHead>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}
