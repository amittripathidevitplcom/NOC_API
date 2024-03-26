using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_ScholarshipFellowshipLoanAccRepository : IDTEStatistics_ScholarshipFellowshipLoanAccRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_ScholarshipFellowshipLoanAccRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public DTEStatistics_ScholarshipFellowshipLoanAccDataModel ScholarshipFellowshipLoanAccItem(int CollegeID)
        {
            string SqlQuery = " exec USP_ScholarshipFellowshipLoanAccItem @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_ScholarshipFellowshipLoanAcc.ScholarshipFellowshipLoanAccItem");

            DTEStatistics_ScholarshipFellowshipLoanAccDataModel dataModels = new DTEStatistics_ScholarshipFellowshipLoanAccDataModel();

            //string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            //List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_ScholarshipFellowshipLoanAcc> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_ScholarshipFellowshipLoanAcc>>(JsonDataTable_Data);
            //dataModels.ScholarshipFellowshipLoanAcc_A = EducationalQualificationDetails_StaffDetail_Item;


            //string JsonDataTable_Data_B = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            //List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_ScholarshipFellowshipLoanAcc> EducationalQualificationDetails_B = JsonConvert.DeserializeObject<List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_ScholarshipFellowshipLoanAcc>>(JsonDataTable_Data_B);
            //dataModels.ScholarshipFellowshipLoanAcc_B = EducationalQualificationDetails_B;

            return dataModels;
        }

        public DTEStatistics_ScholarshipFellowshipLoanAccDataModel GetByID(int CollegeID, string EntryType)
        {

            string SqlQuery = " exec UPS_DTEStatistics_ScholarshipFellowshipLoanAcc_GetByID @CollegeID='" + CollegeID + "',@EntryType='" + EntryType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_ScholarshipFellowshipLoanAcc.GetByID");

            DTEStatistics_ScholarshipFellowshipLoanAccDataModel dataModels = new DTEStatistics_ScholarshipFellowshipLoanAccDataModel();
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
            List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship>>(JsonDataTable_Data);
            dataModels.Scholarship = EducationalQualificationDetails_StaffDetail_Item;


            string JsonDataTable_Data_Fellowship = CommonHelper.ConvertDataTable(dataSet.Tables[2]);
            List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship> FellowshipJson = JsonConvert.DeserializeObject<List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship>>(JsonDataTable_Data_Fellowship);
            dataModels.Fellowship = FellowshipJson;

            string JsonDataTable_Data_Loan = CommonHelper.ConvertDataTable(dataSet.Tables[2]);
            List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship> LoanJson = JsonConvert.DeserializeObject<List<DTEStatistics_ScholarshipFellowshipLoanAccDataModel_Scholarship>>(JsonDataTable_Data_Loan);
            dataModels.Loan = LoanJson;


            return dataModels;

        }
        public bool SaveData(DTEStatistics_ScholarshipFellowshipLoanAccDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string ScholarshipFellowshipLoanAcc_Scholarship_Str = request.Scholarship.Count > 0 ? CommonHelper.GetDetailsTableQry(request.Scholarship, "Temp_DTEStatistics_ScholarshipFellowshipLoanAcc_Scholarship") : "";

            string ScholarshipFellowshipLoanAcc_Fellowship_Str = request.Fellowship.Count > 0 ? CommonHelper.GetDetailsTableQry(request.Fellowship, "Temp_DTEStatistics_ScholarshipFellowshipLoanAcc_Fellowship") : "";

            string ScholarshipFellowshipLoanAcc_Loan_Str = request.Loan.Count > 0 ? CommonHelper.GetDetailsTableQry(request.Loan, "Temp_DTEStatistics_ScholarshipFellowshipLoanAcc_Loan") : "";

            string SqlQuery = " exec UPS_DTEStatistics_ScholarshipFellowshipLoanAcc_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @EntryType='" + request.EntryType + "', ";

            SqlQuery += " @ScholarshipFellowshipLoanAcc_Scholarship_Str='" + ScholarshipFellowshipLoanAcc_Scholarship_Str + "', ";
            SqlQuery += " @ScholarshipFellowshipLoanAcc_Fellowship_Str='" + ScholarshipFellowshipLoanAcc_Fellowship_Str + "', ";
            SqlQuery += " @ScholarshipFellowshipLoanAcc_Loan_Str='" + ScholarshipFellowshipLoanAcc_Loan_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_ScholarshipFellowshipLoanAcc.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
