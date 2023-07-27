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
    public class QualificationMasterRepository : IQualificationMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public QualificationMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetQualificationMasterList(int DepartmentID)
        {
            string SqlQuery = " exec USP_QualificationMaster_GetData  @DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "QualificationMaster.GetQualificationMasterList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<QualificationMasterDataModel> GetQualificationMasterIDWise(int QualificationID)
        {
            string SqlQuery = " exec USP_QualificationMaster_GetData '" + QualificationID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "QualificationMaster.GetQualificationMasterIDWise");

            List<QualificationMasterDataModel> dataModels = new List<QualificationMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<QualificationMasterDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
        public bool SaveData(QualificationMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_QualificationMaster_AddUpdate";

            SqlQuery += " @QualificationID='" + request.QualificationID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @QualificationName='" + request.QualificationName + "',";
            SqlQuery += " @IsDocCompulsory='" + request.IsDocCompulsory + "',";
            SqlQuery += " @Orderby='" + request.Orderby + "',";
            SqlQuery += " @ActiveStatus='" + request.ActiveStatus + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "QualificationMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int QualificationID)
        {
            string SqlQuery = " Update M_QualificationMaster set ActiveStatus=0 , DeleteStatus=1  WHERE QualificationID='" + QualificationID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "QualificationMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int QualificationID, int DepartmentID, string QualificationName)
        {
            string SqlQuery = " select QualificationName from M_QualificationMaster Where QualificationName='" + QualificationName.Trim() + "'  and DepartmentID ='" + DepartmentID + "' and QualificationID !='" + QualificationID + "' and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "QualificationMaster.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}

