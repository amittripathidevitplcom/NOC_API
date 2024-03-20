using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_FinancialDetailsRepository : IDTEStatistics_FinancialDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_FinancialDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public DTEStatistics_FinancialDetailsDataModel FinancialDetailsItem(int CollegeID)
        {
            string SqlQuery = " exec USP_FinancialDetailsItem @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_FinancialDetails.FinancialDetailsItem");

            DTEStatistics_FinancialDetailsDataModel dataModels = new DTEStatistics_FinancialDetailsDataModel();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<DTEStatistics_FinancialDetailsDataModel_FinancialDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_FinancialDetailsDataModel_FinancialDetails>>(JsonDataTable_Data);
            dataModels.FinancialDetails_Income = EducationalQualificationDetails_StaffDetail_Item;


            string JsonDataTable_Data_Expenses = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<DTEStatistics_FinancialDetailsDataModel_FinancialDetails> EducationalQualificationDetails__Expenses = JsonConvert.DeserializeObject<List<DTEStatistics_FinancialDetailsDataModel_FinancialDetails>>(JsonDataTable_Data_Expenses);
            dataModels.FinancialDetails_Expenses = EducationalQualificationDetails__Expenses;

            return dataModels;
        }

        public DTEStatistics_FinancialDetailsDataModel GetByID(int CollegeID, string EntryType)
        {

            string SqlQuery = " exec UPS_DTEStatistics_FinancialDetails_GetByID @CollegeID='" + CollegeID + "',@EntryType='" + EntryType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_FinancialDetails.GetByID");

            DTEStatistics_FinancialDetailsDataModel dataModels = new DTEStatistics_FinancialDetailsDataModel();
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
            List<DTEStatistics_FinancialDetailsDataModel_FinancialDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_FinancialDetailsDataModel_FinancialDetails>>(JsonDataTable_Data);
            dataModels.FinancialDetails_Income = EducationalQualificationDetails_StaffDetail_Item;


            string JsonDataTable_Data_Expenses = CommonHelper.ConvertDataTable(dataSet.Tables[2]);
            List<DTEStatistics_FinancialDetailsDataModel_FinancialDetails> EducationalQualificationDetails__Expenses = JsonConvert.DeserializeObject<List<DTEStatistics_FinancialDetailsDataModel_FinancialDetails>>(JsonDataTable_Data_Expenses);
            dataModels.FinancialDetails_Expenses = EducationalQualificationDetails__Expenses;

            return dataModels;

        }
        public bool SaveData(DTEStatistics_FinancialDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string FinancialDetails_Income_Str = request.FinancialDetails_Income.Count > 0 ? CommonHelper.GetDetailsTableQry(request.FinancialDetails_Income, "Temp_DTEStatistics_FinancialDetails_Income") : "";

            string FinancialDetails_Expenses_Str = request.FinancialDetails_Expenses.Count > 0 ? CommonHelper.GetDetailsTableQry(request.FinancialDetails_Expenses, "Temp_DTEStatistics_FinancialDetails_Expenses") : "";

            string SqlQuery = " exec UPS_DTEStatistics_FinancialDetails_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @EntryType='" + request.EntryType + "', ";

            SqlQuery += " @FinancialDetails_Income_Str='" + FinancialDetails_Income_Str + "', ";
            SqlQuery += " @FinancialDetails_Expenses_Str='" + FinancialDetails_Expenses_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_FinancialDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
