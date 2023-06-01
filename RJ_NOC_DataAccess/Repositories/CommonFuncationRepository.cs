using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RJ_NOC_Model;
using System.Threading.Tasks;
using RJ_NOC_DataAccess.Interface;
using System.Data.SqlClient;
using System.Data;
using FIH_EPR_DataAccess.Common;
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

        public List<CommonDataModel_DocumentMasterList> DocumentMasterList(string DocumentType,int ProjectID)
        {
            string SqlQuery = " Exec USP_DocumentMasterList @DocumentType='"+ DocumentType + "', @ProjectID='" + ProjectID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.DocumentMasterList");

            List<CommonDataModel_DocumentMasterList> dataModels = new List<CommonDataModel_DocumentMasterList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_DocumentMasterList>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<CommonDataModel_EmployeeDocumentList> ProjectWise_EmployeeDocumentList(int ProjectID, int EmployeeID)
        {
            string SqlQuery = " Exec USP_ProjectWise_EmployeeDocumentList @ProjectID='" + ProjectID + "', @EmployeeID='" + EmployeeID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CommonFuncation.ProjectWise_EmployeeDocumentList");

            List<CommonDataModel_EmployeeDocumentList> dataModels = new List<CommonDataModel_EmployeeDocumentList>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_EmployeeDocumentList>>(JsonDataTable_Data);
            return dataModels;
        }

        public List<DataTable> EmployeeProfileDetails(int EmployeeID)
        {
           string SqlQuery = " exec USP_EmployeeProfileDetails @EmployeeID='"+ EmployeeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.GetAllData");

            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
