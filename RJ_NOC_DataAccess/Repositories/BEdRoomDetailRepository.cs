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
    public class BEdRoomDetailRepository : IBEdRoomDetailRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public BEdRoomDetailRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<BEdRoomDetailDetailsDataModel> GetBEdRoomDetailList(int DepartmentID, int CollegeID)
        {
            string SqlQuery = " exec USP_Trn_BEd_RoomDetails_IU_GetData @DepartmentID = '" + DepartmentID + "',@CollegeID = '" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "BEdRoomDetail.GetBEdRoomDetailList");

            List<BEdRoomDetailDetailsDataModel> dataModels = new List<BEdRoomDetailDetailsDataModel>();
            BEdRoomDetailDetailsDataModel dataModel = new BEdRoomDetailDetailsDataModel();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }
        public bool Delete(int BEdRoomDetailID)
        {
            string SqlQuery = " Update Trn_BEd_RoomDetails set ActiveStatus=0 , DeleteStatus=1  WHERE [B.EdRoomDetailID]='" + BEdRoomDetailID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "BEdRoomDetail.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool SaveData(BEdRoomDetailDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_Trn_BEd_RoomDetails_AddUpdate";
            SqlQuery += " @BEdRoomDetailID='" + request.BEdRoomDetailID + "',@CollegeID='" + request.CollegeID + "',@DepartmentID='" + request.DepartmentID + "',@NoOfClasses='" + request.NoOfClasses + "',@ActiveStatus='" + request.ActiveStatus + "',@DeleteStatus='" + request.DeleteStatus + "',@UserID='" + request.UserID + "',@CreatedBy='" + request.CreatedBy + "',@ModifyBy='" + request.ModifyBy + "',@IPAddress='" + IPAddress + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "BEdRoomDetail.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

    }
}
