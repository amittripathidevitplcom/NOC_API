using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class StreamSubjectMappingDetailsRepository : IStreamSubjectMappingDetailsRepository
    {


        private CommonDataAccessHelper _commonHelper;
        public StreamSubjectMappingDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public bool DeleteData(int StreamMappingID)
        {
            string SqlQuery = " Update M_StreamSubjectMappingDetails set ActiveStatus=0 , DeleteStatus=1  WHERE StreamMappingID='" + StreamMappingID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "CourseMaster.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_DataTable> GetAllStream(StreamSubjectMappingDetailDataModel Model)
        {

            string SqlQuery = "exec USP_StreamSubjectMapping_Get @Key='GetmappingList',@DepartmentID='" + Model.DepartmentID + "',@CourseLevelID='" + Model.CourseLevelID + "',@CourseID='" + Model.CourseID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "Common.GetCollegeBasicDetails");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<StreamSubjectMappingDetailDataModel> GetStreamIDWise(int StreamMappingID, string LoginSSOID)
        {
            string SqlQuery = " exec USP_StreamSubjectMapping_Get @Key='GetDetails',@LoginSSOID ='" + LoginSSOID + "',@StreamMappingID='" + StreamMappingID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "CourseMaster.GetDataIDWise");

            List<StreamSubjectMappingDetailDataModel> listdataModels = new List<StreamSubjectMappingDetailDataModel>();

            StreamSubjectMappingDetailDataModel dataModels = new StreamSubjectMappingDetailDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels.StreamMappingID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["StreamMappingID"]);
                dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DepartmentID"]);
                dataModels.CourseID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CourseID"]);
                dataModels.UserID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CreatedBy"]);
                dataModels.StreamID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["StreamID"]);
                dataModels.CourseLevelID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CourseLevelID"]);


                dataModels.ActiveStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ActiveStatus"]);
                dataModels.DeleteStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["DeleteStatus"]);


                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                List<StreaSubjectDetails> SaleDataModel_Item = JsonConvert.DeserializeObject<List<StreaSubjectDetails>>(JsonDataTable_Data);
                dataModels.SelectedSubjectDetails = SaleDataModel_Item;
                listdataModels.Add(dataModels);
            }

            return listdataModels;

        }

        public bool SaveData(StreamSubjectMappingDetailDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_StreamSubjectMapping_AddUpdate  ";
            SqlQuery += " @StreamMappingID='" + request.StreamMappingID + "',";
            SqlQuery += " @DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += " @CourseLevelID='" + request.CourseLevelID + "',";
            SqlQuery += " @CourseID='" + request.CourseID + "',";
            SqlQuery += " @StreamID='" + request.StreamID + "',";
            SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @CollegeWiseCourse_SubjectDetails='" + CommonHelper.GetDetailsTableQry(request.SelectedSubjectDetails.Where(f=>f.IsChecked), "CollegeWiseCourse_SubjectDetails") + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "StreamSubjectMappingDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
