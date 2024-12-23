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
            SqlQuery += " @CollegeWiseOtherInfoID='" + request.CollegeWiseOtherInfoID + "',@CollegeID='" + request.CollegeID + "',@CourseID='" + request.CourseID + "',@DepartmentID='" + request.DepartmentID + "',@Width='" + request.Width + "',@Length='" + request.Length + "',@ImageFileName='" + request.ImageFileName + "',@ImageFilePath='" + request.ImageFilePath + "',@BookImageFileName='" + request.BookImageFileName + "',@BookImageFilePath='" + request.BookImageFilePath + "',@NoofBooks='" + request.NoofBooks + "',@ActiveStatus='" + request.ActiveStatus + "',@DeleteStatus='" + request.DeleteStatus + "',@UserID='" + request.UserID + "',@NoOfRooms='" + request.NoOfRooms + "',@NoofComputers='" + request.NoofComputers + "'";
            SqlQuery += " ,@BookInvoiceFileName='" + request.BookInvoiceFileName + "', @BookInvoiceFilePath='" + request.BookInvoiceFilePath + "', @FloorAreaofLibrary='" + request.FloorAreaofLibrary + "', @Professional='" + request.Professional + "', @Other='" + request.Other + "', @PeriodicalsNo='" + request.PeriodicalsNo + "', @JournalsNo='" + request.JournalsNo + "', @SeatingCapacity='" + request.SeatingCapacity + "', @InternetFacility='" + request.InternetFacility + "', @CounterforSale='" + request.CounterforSale + "', @ComputerPrint='" + request.ComputerPrint + "', @RegistersMaintained='" + request.RegistersMaintained + "', @LibraryTiming='" + request.LibraryTiming + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "OtherInformation.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<OtherInformationDataModels> GetOtherInformationAllList(int CollegeID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_Trn_College_OtherInformation_GetData @CollegeID='" + CollegeID + "',@ApplyNOCID='" + ApplyNOCID + "'";
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
            string SqlQuery = " exec USP_Trn_College_OtherInformation_GetData @CollegeWiseOtherInfoID='" + CollegeWiseOtherInfoID + "', @CollegeID='" + CollegeID + "'";
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
            SqlQuery += "  Delete from Trn_CollegeLabInformation Where   CollegeWiseOtherInfoID   = '" + CollegeWiseOtherInfoID + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "OtherInformation.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }


        public List<CollegeLabInformationDataModel> GetCollegeLabInformationList(int CollegeID, string key)
        {
            string SqlQuery = " exec USP_CollegeWiseLabSubject @CollegeID='" + CollegeID + "',@key='" + key + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "OtherInformation.GetCollegeLabInformationList");

            List<CollegeLabInformationDataModel> dataModels = new List<CollegeLabInformationDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CollegeLabInformationDataModel>>(JsonDataTable_Data);
            return dataModels;

        }

        public bool SaveLabData(PostCollegeLabInformation request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_CollegeLabInformation_AddUpdate";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @OtherID='" + request.OtherID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @CollegeLabInformationDetails='" + CommonHelper.GetDetailsTableQry(request.CollegeLabInformationList, "TempCollegeLabInformationDetail") + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ClassWiseStudentDetailsRepository.SaveLabData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
