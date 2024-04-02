using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_OtherMinorityDataRepository : IDTEStatistics_OtherMinorityDataRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_OtherMinorityDataRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_OtherMinorityDataModel GetByID(int CollegeID, string EntryType)
        {

            string SqlQuery = " exec UPS_DTEStatistics_OtherMinorityData_GetByID @CollegeID='" + CollegeID + "',@EntryType='" + EntryType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_OtherMinorityData_GetByID");

            DTEStatistics_OtherMinorityDataModel dataModels = new DTEStatistics_OtherMinorityDataModel();
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
            List<DTEStatistics_OtherMinorityDataModel_OtherMinorityDetails> OtherMinorityDetails_List = JsonConvert.DeserializeObject<List<DTEStatistics_OtherMinorityDataModel_OtherMinorityDetails>>(JsonDataTable_Data);
            dataModels.OtherMinorityDetails = OtherMinorityDetails_List;
            //List<DTEStatistics_RegularModeDataModel_ProgrammesDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_RegularModeDataModel_ProgrammesDetails>>(JsonDataTable_Data);
            //dataModels.ProgrammesDetails = EducationalQualificationDetails_StaffDetail_Item;
            return dataModels;

        }
        public bool SaveData(DTEStatistics_OtherMinorityDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string OtherMinorityDetails_Str = request.OtherMinorityDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.OtherMinorityDetails, "Temp_DTEStatistics_OtherMinorityDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_OtherMinorityData_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @EntryType='" + request.EntryType + "', ";
                       SqlQuery += " @FacultyDetails_Str='" + OtherMinorityDetails_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_OtherMinorityData.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
