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

namespace RJ_NOC_DataAccess.Repository
{
    public class UserMasterRepository : IUserMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public UserMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<UserMasterDataModel> Login(string LoginID, string Password)
        {
            string SqlQuery = " exec USP_UserLogin @LoginID='" + LoginID + "',@Password='"+ Password + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ProjectMaster.GetAllData");
             
            List<UserMasterDataModel> dataModels = new List<UserMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<UserMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }
    }
}
