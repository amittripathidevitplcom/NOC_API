using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class ApplyNOCRepository : IApplyNOCRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ApplyNOCRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool DocumentScrutiny(int ApplyNOCID, int RoleID, int UserID, string ActionType)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_ApplyNOC_IU  ";
            SqlQuery += "@ApplyNOCID='" + ApplyNOCID + "',@RoleID='" + RoleID + "',@UserID='" + UserID + "',@ActionType='" + ActionType + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ApplyNOC.DocumentScrutiny");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DocumentScrutiny_Temp(DocumentScrutiny_TempDataModel DocumentScrutiny_Temp)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string DocumentScrutiny_TempDetail_Str = CommonHelper.GetDetailsTableQry(DocumentScrutiny_Temp.DocumentScrutiny_TempDetail, "Temp_Trn_DocumentScrutiny_Temp_Details");
            string SqlQuery = " exec USP_Trn_DocumentScrutiny_Temp_IU";

            SqlQuery += " @DocumentScrutinyID='" + DocumentScrutiny_Temp.DocumentScrutinyID + "',";
            SqlQuery += " @DepartmentID='" + DocumentScrutiny_Temp.DepartmentID + "',";
            SqlQuery += " @CollegeID='" + DocumentScrutiny_Temp.CollegeID + "',";
            SqlQuery += " @UserID='" + DocumentScrutiny_Temp.UserID + "',";
            SqlQuery += " @RoleID='" + DocumentScrutiny_Temp.RoleID + "',";
            SqlQuery += " @ActionID='" + DocumentScrutiny_Temp.ActionID + "',";
            SqlQuery += " @Remark='" + DocumentScrutiny_Temp.Remark + "',";
            SqlQuery += " @TabName='" + DocumentScrutiny_Temp.TabName + "',";
            SqlQuery += " @ApplyNOCID='" + DocumentScrutiny_Temp.ApplyNOCID + "',";
            SqlQuery += " @ActionType='" + DocumentScrutiny_Temp.ActionType + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @DocumentScrutiny_TempDetail_Str='" + DocumentScrutiny_TempDetail_Str + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "ApplyNOC.DocumentScrutiny_Temp");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<ApplyNOCDataModel> GetApplyNOCApplicationListByRole(int RoleID)
        {
            string SqlQuery = " exec USP_ApplyNOCApplicationList @RoleID='" + RoleID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "ApplyNOC.GetApplyNOCApplicationListByRole");
            List<ApplyNOCDataModel> listdataModels = new List<ApplyNOCDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            listdataModels = JsonConvert.DeserializeObject<List<ApplyNOCDataModel>>(JsonDataTable_Data);
            return listdataModels;
        }

    }
}
