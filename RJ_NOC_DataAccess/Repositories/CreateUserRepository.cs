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
    public class CreateUserRepository : ICreateUserRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public CreateUserRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataTable> GetUserList()
        {
            string SqlQuery = " exec USP_CreateUser_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CreateUser.GetUserList");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CreateUserDataModel> GetUserByIDWise(int UId)
        {
            string SqlQuery = " exec USP_CreateUser_GetData '" + UId + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CreateUser.GetUserByIDWise");

            List<CreateUserDataModel> dataModels = new List<CreateUserDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CreateUserDataModel>>(JsonDataTable_Data);
            return dataModels;

        }
        public bool SaveData(CreateUserDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CreateUser_AddUpdate";

            SqlQuery += " @UId='" + request.UId + "',";
            SqlQuery += " @SSOID='" + request.SSOID + "',";
            SqlQuery += " @MobileNumber='" + request.MobileNumber + "',";
            SqlQuery += " @EmailAddress='" + request.EmailAddress + "',";
            SqlQuery += " @Name='" + request.Name + "',";
            SqlQuery += " @DesignationID='" + request.DesignationID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @RoleID='" + request.RoleID + "',";
            SqlQuery += " @MemberType='" + request.MemberType + "',";
            SqlQuery += " @StateID='" + request.StateID + "',";
            SqlQuery += " @DistrictID='" + request.DistrictID + "',";
            SqlQuery += " @TehsilID='" + request.TehsilID + "',";
            SqlQuery += " @ActiveStatus='" + request.ActiveStatus + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "CreateUser.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int UId)
        {
            string SqlQuery = " Update M_UserMaster set ActiveStatus=0 , DeleteStatus=1  WHERE UId='" + UId + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CreateUser.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int UId, string SSOID, string Name)
        {
            string SqlQuery = " select Name from M_UserMaster Where Name='" + Name.Trim() + "'  and SSOID ='" + SSOID + "' and UId !='" + UId + "' and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CreateUser.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}

