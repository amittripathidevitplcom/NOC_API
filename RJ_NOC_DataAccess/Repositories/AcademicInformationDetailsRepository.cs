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
    public class AcademicInformationDetailsRepository : IAcademicInformationDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public AcademicInformationDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool SaveData(AcademicInformationDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_Trn_School_AcademicInformationDetails_IU  ";
            SqlQuery += " @AcademicInformationID='" + request.AcademicInformationID + "',@YearID='" + request.YearID + "',@CollegeID='" + request.CollegeID + "',@CourseID='" + request.CourseID + "',@ResultID='" + request.ResultID + "',@AdmittedStudent='" + request.AdmittedStudent + "',@AppearedStudent='" + request.AppearedStudent + "',@PassedStudent='" + request.PassedStudent + "',@FailedStudent='" + request.FailedStudent + "',@OtherStudent='" + request.OtherStudent + "',@UserID='" + request.UserID + "',@CourseType='" + request.CourseType + "',@SemesterNo='" + request.SemesterNo + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AcademicInformationDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<AcademicInformationDetailsDataModels> GetAcademicInformationDetailAllList(int CollegeID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_Trn_School_AcademicInformationDetails_GetData @CollegeID='"+ CollegeID + "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AcademicInformationDetails.GetAcademicInformationDetailAllList");

            List<AcademicInformationDetailsDataModels> dataModels = new List<AcademicInformationDetailsDataModels>();
            AcademicInformationDetailsDataModels dataModel = new AcademicInformationDetailsDataModels();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }

        public List<AcademicInformationDetailsDataModel> GetAcademicInformationDetailByID(int AcademicInformationID, int CollegeID)
        {
            string SqlQuery = " exec USP_Trn_School_AcademicInformationDetails_GetData @AcademicInformationID='" + AcademicInformationID + "',@CollegeID='"+ CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AcademicInformationDetails.GetAcademicInformationDetailByID");

            List<AcademicInformationDetailsDataModel> dataModels = new List<AcademicInformationDetailsDataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<AcademicInformationDetailsDataModel>>(JsonDataTable_Data);
            return dataModels;

        }

        public bool DeleteData(int AcademicInformationID)
        {
            string SqlQuery = " Update Trn_School_AcademicInformationDetails set ActiveStatus=0 , DeleteStatus=1  WHERE AcademicInformationID='" + AcademicInformationID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AcademicInformationDetails.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
