using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_InfrastructureDetailsRepository : IDTEStatistics_InfrastructureDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_InfrastructureDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public DTEStatistics_InfrastructureDetailsDataModel InfrastructureDetailsItem(int CollegeID)
        {
            string SqlQuery = " exec USP_InfrastructureDetailsItem @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_InfrastructureDetails.InfrastructureDetailsItem");

            DTEStatistics_InfrastructureDetailsDataModel dataModels = new DTEStatistics_InfrastructureDetailsDataModel();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails>>(JsonDataTable_Data);
            dataModels.InfrastructureDetails_A = EducationalQualificationDetails_StaffDetail_Item;


            string JsonDataTable_Data_B = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails> EducationalQualificationDetails_B = JsonConvert.DeserializeObject<List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails>>(JsonDataTable_Data_B);
            dataModels.InfrastructureDetails_B = EducationalQualificationDetails_B;

            return dataModels;
        }

        public DTEStatistics_InfrastructureDetailsDataModel GetByID(int CollegeID, string EntryType)
        {

            string SqlQuery = " exec UPS_DTEStatistics_InfrastructureDetails_GetByID @CollegeID='" + CollegeID + "',@EntryType='" + EntryType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_InfrastructureDetails.GetByID");

            DTEStatistics_InfrastructureDetailsDataModel dataModels = new DTEStatistics_InfrastructureDetailsDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels.EntryID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["EntryID"]);
                dataModels.EntryDate = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EntryDate"]).ToString("dd/MMM/yyyy");
                dataModels.Department = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Department"]);
                dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
                dataModels.SelectedCollegeEntryTypeName = dataSet.Tables[0].Rows[0]["SelectedCollegeEntryTypeName"].ToString();
                dataModels.FYearID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FYearID"]);
            }
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
            List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails>>(JsonDataTable_Data);
            dataModels.InfrastructureDetails_A = EducationalQualificationDetails_StaffDetail_Item;


            string JsonDataTable_Data_Expenses = CommonHelper.ConvertDataTable(dataSet.Tables[2]);
            List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails> EducationalQualificationDetails__Expenses = JsonConvert.DeserializeObject<List<DTEStatistics_InfrastructureDetailsDataModel_InfrastructureDetails>>(JsonDataTable_Data_Expenses);
            dataModels.InfrastructureDetails_B = EducationalQualificationDetails__Expenses;

            return dataModels;

        }
        public bool SaveData(DTEStatistics_InfrastructureDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string InfrastructureDetails_A_Str = request.InfrastructureDetails_A.Count > 0 ? CommonHelper.GetDetailsTableQry(request.InfrastructureDetails_A, "Temp_DTEStatistics_InfrastructureDetails_A") : "";

            string InfrastructureDetails_B_Str = request.InfrastructureDetails_B.Count > 0 ? CommonHelper.GetDetailsTableQry(request.InfrastructureDetails_B, "Temp_DTEStatistics_InfrastructureDetails_B") : "";

            string SqlQuery = " exec UPS_DTEStatistics_InfrastructureDetails_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @EntryType='" + request.EntryType + "', ";

            SqlQuery += " @InfrastructureDetails_A_Str='" + InfrastructureDetails_A_Str + "', ";
            SqlQuery += " @InfrastructureDetails_B_Str='" + InfrastructureDetails_B_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_InfrastructureDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
