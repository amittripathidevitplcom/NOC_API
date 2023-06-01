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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Diagnostics.Metrics;
using Azure.Core;

namespace RJ_NOC_DataAccess.Repository
{
    public class EmployeeDashboardRepository : IEmployeeDashboardRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public EmployeeDashboardRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        
        public List<EmployeeDashboardDataModel_DocumentStatusCounts> EmployeeDocumentStatusCounts(int ProjectID, int EmployeeID)
        {
            string SqlQuery = " exec USP_EmployeeDocumentStatusCounts @ProjectID='" + ProjectID + "', @EmployeeID='" + EmployeeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "EmployeeDashboard.GetDataIDWise");

            List<EmployeeDashboardDataModel_DocumentStatusCounts> dataModels = new List<EmployeeDashboardDataModel_DocumentStatusCounts>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<EmployeeDashboardDataModel_DocumentStatusCounts>>(JsonDataTable_Data);
            return dataModels;
        }

        public bool Save_ProjectWiseEmployeeDocuments(int ProjectID, int EmployeeID, int DID, string DocumentName)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Save_ProjectWiseEmployeeDocuments @ProjectID='"+ ProjectID + "',@EmployeeID='"+ EmployeeID + "',@DID='"+ DID + "',@DocumentName='"+ DocumentName + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "EmployeeDashboardRepository.Save_ProjectWiseEmployeeDocuments");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
