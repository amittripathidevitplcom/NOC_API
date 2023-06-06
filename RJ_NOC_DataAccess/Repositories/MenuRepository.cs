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
    public class MenuRepository : IMenuRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public MenuRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<MenuDataModel_List> GetAllMenu()
        {
           // string SqlQuery = " select * from V#AllMenuList order by MenuName asc";
            string SqlQuery = " exec USP_AllMenuList ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery);

            List<MenuDataModel_List> dataModels = new List<MenuDataModel_List>();
            MenuDataModel_List dataModel = new MenuDataModel_List();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
            
        }
         public List<MenuDataModel_List> GetUserWiseMenu(int UserID)
        {
            string SqlQuery = " exec Usp_MenuUserWise @UserID="+ UserID + "";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery);

            List<MenuDataModel_List> dataModels = new List<MenuDataModel_List>();
            MenuDataModel_List dataModel = new MenuDataModel_List();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
            
        }

        public List<MenuDataModel> GetMenuIDWise(int AccountID)
        {
            string SqlQuery = " select MenuId as 'MenuId',MenuName as 'GroupName',ShortName,UnderMenuId as 'UnderGroupId' from M_Menu Where MenuId='" + AccountID+"'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery);
             
            List<MenuDataModel> dataModels = new List<MenuDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<MenuDataModel>>(JsonDataTable_Data);
            return dataModels;

        }

        public bool SaveData(MenuDataModel request)
        {

            //string SqlQuery = " INSERT INTO M_Menu ";
            //SqlQuery += System.Environment.NewLine + "(MenuId,MenuName,ShortName,UnderMenuId, ";
            //SqlQuery += System.Environment.NewLine + " ModifyBy,ModifyRTS,IPAddress,ActiveStatus)  " + System.Environment.NewLine;

            //SqlQuery += System.Environment.NewLine + " SELECT  ISNULL(MAX(MenuId), 0) + 1,'" + request.GroupName + "','" + request.ShortName + "','" + request.UnderGroupId + "',";
            //SqlQuery += System.Environment.NewLine + " '" + request.ModifyBy + "',(left(switchoffset(sysdatetimeoffset(),'+05:30'),(23))),'0.0.0.0','Y' from M_Menu ";

            //int Rows = _commonHelper.NonQuerry(SqlQuery);
            //if (Rows > 0)
            //    return true;
            //else
                return false;
        }

        public bool UpdateData(MenuDataModel request)
        {
            //string SqlQuery = " UPDATE M_Menu SET";
            //SqlQuery += System.Environment.NewLine + " MenuName='" + request.GroupName + "',ShortName='" + request.ShortName + "',UnderMenuId='" + request.UnderGroupId + "', ";
            //SqlQuery += " ActiveStatus='Y',ModifyBy='" + request.ModifyBy + "',ModifyRTS=(left(switchoffset(sysdatetimeoffset(),'+05:30'),(23))),IPAddress='0.0.0.0'  " + System.Environment.NewLine;
            //SqlQuery += " WHERE MenuId='" + request.MenuId + "'";
            //int Rows = _commonHelper.NonQuerry(SqlQuery);
            //if (Rows > 0)
            //    return true;
            //else
                return false;
        }
        public bool DeleteData(int AccountID)
        {

            string SqlQuery = " delete M_Menu ";
            SqlQuery += " WHERE MenuId='" + AccountID + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery);
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool IfExists(int AccountID, string AccountName)
        {
            string SqlQuery = " select MenuName from M_Menu Where MenuName='" + AccountName.Trim() + "'  and MenuId !='" + AccountID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery);
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
