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
using System.Xml.Linq;

namespace RJ_NOC_DataAccess.Repository
{
    public class CollegeDocumentRepository : ICollegeDocumentRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CollegeDocumentRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetAllData(int DepartmentID, int CollegeID, string Type, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_CollegeDocument @DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@DocumentType='" + Type + "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeDocument.GetAllData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetListLOI(int DepartmentID, int CollegeID, string Type, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_GetLOIDocument @DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@DocumentType='" + Type + "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeDocument.GetListLOI");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }     
        public List<CommonDataModel_DataTable> GetOtherDocumentByID(int OtherDocumentID)
        {
            string SqlQuery = " exec USP_GetOtherDocumentByID @OtherDocumentID='" + OtherDocumentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CollegeDocument.GetOtherDocumentByID");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool Delete(int AID)
        {
            string SqlQuery = " Update Trn_CollegeDocument set ActiveStatus=0,DeleteStatus=1 Where aid='"+ AID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CollegeDocument.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool SaveData(CollegeDocumentDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = " exec USP_CollegeDocument_SaveUpdate  ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @DocumentType='" + request.DocumentType + "',";
            SqlQuery += " @Str_CollegeDocument='" + CommonHelper.GetDetailsTableQry(request.DocumentDetails, "CollegeDocument") + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "CollegeDocument.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
         
    }
}
