using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class UserManualDocumentMasterRepository : IUserManualDocumentMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;

        public UserManualDocumentMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<UserManualDocumentMasterDataModel_List> GetUserManualDocumentMasterList(int DepartmentID)
        {
            string SqlQuery = " exec USP_UserManualDocumentMaster_GetDataList @DepartmentID='"+ DepartmentID + "'";
           
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "UserManualDocumentMaster.GetUserManualDocumentMasterList"); 

            List<UserManualDocumentMasterDataModel_List> dataModels = new List<UserManualDocumentMasterDataModel_List>();
            UserManualDocumentMasterDataModel_List dataModel = new UserManualDocumentMasterDataModel_List();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }


        public List<UserManualDocumentMasterDataModel> GetUserManualDocumentMasterIDWise(int ID)
        {
            string SqlQuery = " exec USP_GetUserManualDocumentMasterIDWise @ID='" + ID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "UserManualDocumentMaster.GetUserManualDocumentMasterIDWise");

            List<UserManualDocumentMasterDataModel> dataModels = new List<UserManualDocumentMasterDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<UserManualDocumentMasterDataModel>>(JsonDataTable_Data);
            return dataModels;
        }

        public bool SaveData(UserManualDocumentMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_UserManualDocument_AddUpdate";
            SqlQuery += " @ID='" + request.ID + "',";
            SqlQuery += " @UserTypeID='" + request.UserTypeID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
          
            SqlQuery += " @TitleEnglish='" + request.TitleEnglish + "',";
            SqlQuery += " @TitleHindi='" + request.TitleHindi + "',";
            SqlQuery += " @IsShow='" + request.IsShow + "',";
            SqlQuery += " @IsNew='" + request.IsNew + "',";
            SqlQuery += " @DocumentName='" + request.DocumentName + "',";  
            SqlQuery += " @OrderBy='" + request.OrderBy + "'";  
       




            int Rows = _commonHelper.NonQuerry(SqlQuery, "UserManualDocumentMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int ID)
        {
            string SqlQuery = " Update M_UserManualDocumentMaster set ActiveStatus=0 , DeleteStatus=1  WHERE ID='" + ID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "UserManualDocumentMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
