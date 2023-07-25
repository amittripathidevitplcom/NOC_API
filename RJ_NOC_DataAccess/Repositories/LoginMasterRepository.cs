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

namespace RJ_NOC_DataAccess.Repository
{
    public class LoginMasterRepository : ILoginMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public LoginMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<LoginMasterDataModel> Login(string UserName, string Password)
        {
            string SqlQuery = " exec USP_UsersLogin @LoginID='" + UserName + "',@Password='"+ Password + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LoginMaster.Login");
             
            List<LoginMasterDataModel> dataModels = new List<LoginMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<LoginMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}
