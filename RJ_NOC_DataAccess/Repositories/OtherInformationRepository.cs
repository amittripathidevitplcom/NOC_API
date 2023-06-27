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
    public class OtherInformationRepository : IOtherInformationRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public OtherInformationRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool SaveData(OtherInformationDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Trn_College_OtherInformation_IU  ";
            SqlQuery += " @CollegeWiseOtherInfoID='" + request.CollegeWiseOtherInfoID + "',@CollegeID='" + request.CollegeID + "',@CourseID='" + request.CourseID + "',@DepartmentID='" + request.DepartmentID + "',@Width='" + request.Width + "',@Length='" + request.Length + "',@ImageFileName='" + request.ImageFileName + "',@ImageFilePath='" + request.ImageFilePath + "',@BookImageFileName='" + request.BookImageFileName + "',@BookImageFilePath='" + request.BookImageFilePath + "',@NoofBooks='" + request.NoofBooks + "',@ActiveStatus='" + request.ActiveStatus + "',@DeleteStatus='" + request.DeleteStatus + "',@UserID='" + request.UserID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "OtherInformation.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<OtherInformationDataModels> GetOtherInformationAllList(int CollegeID)
        {
            string SqlQuery = " exec USP_Trn_College_OtherInformation_GetData @CollegeID='"+ CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "OtherInformation.GetOtherInformationAllList");

            List<OtherInformationDataModels> dataModels = new List<OtherInformationDataModels>();
            OtherInformationDataModels dataModel = new OtherInformationDataModels();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public List<OtherInformationDataModel> GetOtherInformationByID(int CollegeWiseOtherInfoID, int CollegeID)
        {
            string SqlQuery = " exec USP_Trn_College_OtherInformation_GetData @CollegeWiseOtherInfoID='" + CollegeWiseOtherInfoID + "', @CollegeID='"+ CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "OtherInformation.GetOtherInformationByID");

            List<OtherInformationDataModel> dataModels = new List<OtherInformationDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<OtherInformationDataModel>>(JsonDataTable_Data);
            return dataModels;

        }

        public bool DeleteData(int CollegeWiseOtherInfoID)
        {
            string SqlQuery = " Update Trn_College_OtherInformation set ActiveStatus=0 , DeleteStatus=1  WHERE CollegeWiseOtherInfoID='" + CollegeWiseOtherInfoID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "OtherInformation.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
