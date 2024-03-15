using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_DepartmentRepository : IDTEStatistics_DepartmentRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_DepartmentRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_DepartmentDataModel GetByID(int CollegeID)
        {
            //string SqlQuery = " exec UPS_DTEStatistics_Department_GetByID @CollegeID='" + CollegeID + "'";
            //DataTable dataTable = new DataTable();
            //dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEStatistics_Department.GetByID");

            //DTEStatistics_DepartmentDataModel dataModels = new DTEStatistics_DepartmentDataModel();
            //if (dataTable.Rows.Count > 0)
            //{
            //    dataModels = CommonHelper.ConvertDataTable<DTEStatistics_DepartmentDataModel>(dataTable);
            //}
            //return dataModels;

            string SqlQuery = " exec UPS_DTEStatistics_Department_GetByID @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_RegionalCenters.GetByID");

            DTEStatistics_DepartmentDataModel dataModels = new DTEStatistics_DepartmentDataModel();
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
            List<DTEStatistics_Department_DepartmentDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_Department_DepartmentDetails>>(JsonDataTable_Data);
            dataModels.DepartmentDetails = EducationalQualificationDetails_StaffDetail_Item;


            return dataModels;

        }
        public bool SaveData(DTEStatistics_DepartmentDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string FacultyDetails_Str = request.DepartmentDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.DepartmentDetails, "Temp_DTEStatistics_DepartmentDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_Department_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";

            SqlQuery += " @FacultyDetails_Str='" + FacultyDetails_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_Department.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
