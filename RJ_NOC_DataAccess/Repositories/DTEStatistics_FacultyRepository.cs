using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_FacultyRepository : IDTEStatistics_FacultyRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_FacultyRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_FacultyDataModel GetByID(int CollegeID)
        {
            //string SqlQuery = " exec UPS_DTEStatistics_Faculty_GetByID @CollegeID='" + CollegeID + "'";
            //DataTable dataTable = new DataTable();
            //dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEStatistics_Faculty.GetByID");

            //DTEStatistics_FacultyDataModel dataModels = new DTEStatistics_FacultyDataModel();
            //if (dataTable.Rows.Count > 0)
            //{
            //    dataModels = CommonHelper.ConvertDataTable<DTEStatistics_FacultyDataModel>(dataTable);
            //}
            //return dataModels;

            string SqlQuery = " exec UPS_DTEStatistics_Faculty_GetByID @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_RegionalCenters.GetByID");

            DTEStatistics_FacultyDataModel dataModels = new DTEStatistics_FacultyDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels.EntryID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["EntryID"]);
                dataModels.EntryDate = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EntryDate"]).ToString("dd/MMM/yyyy");
                dataModels.Department = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Department"]);
                dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
                dataModels.SelectedCollegeEntryTypeName = dataSet.Tables[0].Rows[0]["SelectedCollegeEntryTypeName"].ToString();
                dataModels.FYearID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FYearID"]);
            }
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<Faculty_FacultyDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<Faculty_FacultyDetails>>(JsonDataTable_Data);
            dataModels.FacultyDetails = EducationalQualificationDetails_StaffDetail_Item;
            return dataModels;

        }
        public bool SaveData(DTEStatistics_FacultyDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string FacultyDetails_Str = request.FacultyDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.FacultyDetails, "Temp_DTEStatistics_FacultyDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_Faculty_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";

            SqlQuery += " @FacultyDetails_Str='" + FacultyDetails_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_Faculty.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
