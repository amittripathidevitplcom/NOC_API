using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;

namespace RJ_NOC_DataAccess.Repositories
{
    public class RoomDetailsRepository : IRoomDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public RoomDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool SaveData(RoomDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Trn_College_RoomDetails_IU  ";
            SqlQuery += " @CollegeWiseRoomID='" + request.CollegeWiseRoomID + "',@CourseID='" + request.CourseID + "',@DepartmentID='" + request.DepartmentID + "',@Width='" + request.Width + "',@Length='" + request.Length + "',@StudentCapacity='" + request.StudentCapacity + "',@ImageFileName='" + request.ImageFileName + "',@ImageFilePath='" + request.ImageFilePath + "',@ActiveStatus='" + request.ActiveStatus + "',@DeleteStatus='" + request.DeleteStatus + "',@UserID='" + request.UserID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "RoomDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<RoomDetailsDataModels> GetRoomDetailAllList()
        {
            string SqlQuery = " exec USP_Trn_College_RoomDetails_GetData";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "RoomDetails.GetRoomDetailAllList");

            List<RoomDetailsDataModels> dataModels = new List<RoomDetailsDataModels>();
            RoomDetailsDataModels dataModel = new RoomDetailsDataModels();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public List<RoomDetailsDataModel> GetRoomDetailsByID(int CollegeWiseRoomID)
        {
            string SqlQuery = " exec USP_Trn_College_RoomDetails_GetData @CollegeWiseRoomID='" + CollegeWiseRoomID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "RoomDetails.GetRoomDetailsByID");

            List<RoomDetailsDataModel> dataModels = new List<RoomDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<RoomDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;

        }

        public bool DeleteData(int CollegeWiseRoomID)
        {
            string SqlQuery = " Update Trn_College_RoomDetails set ActiveStatus=0 , DeleteStatus=1  WHERE CollegeWiseRoomID='" + CollegeWiseRoomID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "RoomDetails.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
