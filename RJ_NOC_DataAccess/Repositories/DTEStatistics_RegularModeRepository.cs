using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_RegularModeRepository : IDTEStatistics_RegularModeRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_RegularModeRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_RegularModeDataModel GetByID(int CollegeID,string EntryType)
        {
            
            string SqlQuery = " exec UPS_DTEStatistics_RegularMode_GetByID @CollegeID='" + CollegeID + "',@EntryType='" + EntryType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_RegionalCenters.GetByID");

            DTEStatistics_RegularModeDataModel dataModels = new DTEStatistics_RegularModeDataModel();
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
            List<DTEStatistics_RegularModeDataModel_ProgrammesDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_RegularModeDataModel_ProgrammesDetails>>(JsonDataTable_Data);
            dataModels.ProgrammesDetails = EducationalQualificationDetails_StaffDetail_Item;
            return dataModels;

        }
        public bool SaveData(DTEStatistics_RegularModeDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string FacultyDetails_Str = request.ProgrammesDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.ProgrammesDetails, "Temp_DTEStatistics_RegularModeDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_RegularMode_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @EntryType='" + request.EntryType + "', ";

            SqlQuery += " @FacultyDetails_Str='" + FacultyDetails_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_RegularMode.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
