using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_StudentEnrollmentDistanceModeRepository : IDTEStatistics_StudentEnrollmentDistanceModeRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_StudentEnrollmentDistanceModeRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_StudentEnrollmentDistanceModeDataModel GetByID(int CollegeID, string EntryType)
        {

            string SqlQuery = " exec UPS_DTEStatistics_StudentEnrollmentDistanceMode_GetByID @CollegeID='" + CollegeID + "',@EntryType='" + EntryType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_RegionalCenters.GetByID");

            DTEStatistics_StudentEnrollmentDistanceModeDataModel dataModels = new DTEStatistics_StudentEnrollmentDistanceModeDataModel();
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
            List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_ProgrammesDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_ProgrammesDetails>>(JsonDataTable_Data);
            dataModels.ProgrammesDetails = EducationalQualificationDetails_StaffDetail_Item;
            return dataModels;

        }
        public bool SaveData(DTEStatistics_StudentEnrollmentDistanceModeDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data> items = new List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data>();

            foreach (var row in request.ProgrammesDetails)
            {
                DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data item = new DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data();

                item.Category = row.Category.ToString();
                item.GeneralCategorySeatsEarmarkedAsPerGOI = row.GeneralCategorySeatsEarmarkedAsPerGOI;
                item.GeneralCategoryMale = row.GeneralCategoryMale;
                item.GeneralCategoryFemale = row.GeneralCategoryFemale;
                item.GeneralCategoryTransGender = row.GeneralCategoryTransGender;
                item.EWSCategorySeatsEarmarkedAsPerGOI = row.EWSCategorySeatsEarmarkedAsPerGOI;
                item.EWSCategoryMale = row.EWSCategoryMale;
                item.EWSCategoryFemale = row.EWSCategoryFemale;
                item.EWSCategoryTransGender = row.EWSCategoryTransGender;
                item.SCCategorySeatsEarmarkedAsPerGOI = row.SCCategorySeatsEarmarkedAsPerGOI;
                item.SCCategoryMale = row.SCCategoryMale;
                item.SCCategoryFemale = row.SCCategoryFemale;
                item.SCCategoryTransGender = row.SCCategoryTransGender;
                item.STCategorySeatsEarmarkedAsPerGOI = row.STCategorySeatsEarmarkedAsPerGOI;
                item.STCategoryMale = row.STCategoryMale;
                item.STCategoryFemale = row.STCategoryFemale;
                item.STCategoryTransGender = row.STCategoryTransGender;
                item.OBCCategorySeatsEarmarkedAsPerGOI = row.OBCCategorySeatsEarmarkedAsPerGOI;
                item.OBCCategoryMale = row.OBCCategoryMale;
                item.OBCCategoryFemale = row.OBCCategoryFemale;
                item.OBCCategoryTransGender = row.OBCCategoryTransGender;
                item.TotalCategorySeatsEarmarkedAsPerGOI = row.TotalCategorySeatsEarmarkedAsPerGOI;
                item.TotalCategoryMale = row.TotalCategoryMale;
                item.TotalCategoryFemale = row.TotalCategoryFemale;
                item.TotalCategoryTransGender = row.TotalCategoryTransGender;
                item.Remark = row.Remark;
                items.Add(item);

                foreach (var row_Sub in row.StudentDetails)
                {
                    DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data item_Sub = new DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data();

                    item_Sub.Category = row_Sub.Category.ToString();

                    item_Sub.GeneralCategorySeatsEarmarkedAsPerGOI = row_Sub.GeneralCategorySeatsEarmarkedAsPerGOI;
                    item_Sub.GeneralCategoryMale = row_Sub.GeneralCategoryMale;
                    item_Sub.GeneralCategoryFemale = row_Sub.GeneralCategoryFemale;
                    item_Sub.GeneralCategoryTransGender = row_Sub.GeneralCategoryTransGender;
                    item_Sub.EWSCategorySeatsEarmarkedAsPerGOI = row_Sub.EWSCategorySeatsEarmarkedAsPerGOI;
                    item_Sub.EWSCategoryMale = row_Sub.EWSCategoryMale;
                    item_Sub.EWSCategoryFemale = row_Sub.EWSCategoryFemale;
                    item_Sub.EWSCategoryTransGender = row_Sub.EWSCategoryTransGender;
                    item_Sub.SCCategorySeatsEarmarkedAsPerGOI = row_Sub.SCCategorySeatsEarmarkedAsPerGOI;
                    item_Sub.SCCategoryMale = row_Sub.SCCategoryMale;
                    item_Sub.SCCategoryFemale = row_Sub.SCCategoryFemale;
                    item_Sub.SCCategoryTransGender = row_Sub.SCCategoryTransGender;
                    item_Sub.STCategorySeatsEarmarkedAsPerGOI = row_Sub.STCategorySeatsEarmarkedAsPerGOI;
                    item_Sub.STCategoryMale = row_Sub.STCategoryMale;
                    item_Sub.STCategoryFemale = row_Sub.STCategoryFemale;
                    item_Sub.STCategoryTransGender = row_Sub.STCategoryTransGender;
                    item_Sub.OBCCategorySeatsEarmarkedAsPerGOI = row_Sub.OBCCategorySeatsEarmarkedAsPerGOI;
                    item_Sub.OBCCategoryMale = row_Sub.OBCCategoryMale;
                    item_Sub.OBCCategoryFemale = row_Sub.OBCCategoryFemale;
                    item_Sub.OBCCategoryTransGender = row_Sub.OBCCategoryTransGender;
                    item_Sub.TotalCategorySeatsEarmarkedAsPerGOI = row_Sub.TotalCategorySeatsEarmarkedAsPerGOI;
                    item_Sub.TotalCategoryMale = row_Sub.TotalCategoryMale;
                    item_Sub.TotalCategoryFemale = row_Sub.TotalCategoryFemale;
                    item_Sub.TotalCategoryTransGender = row_Sub.TotalCategoryTransGender;

                    items.Add(item);

                }
            }

            string FacultyDetails_Str = items.Count > 0 ? CommonHelper.GetDetailsTableQry(items, "Temp_DTEStatistics_StudentEnrollmentDistanceModeDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_StudentEnrollmentDistanceMode_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @EntryType='" + request.EntryType + "', ";

            SqlQuery += " @FacultyDetails_Str='" + FacultyDetails_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_StudentEnrollmentDistanceMode.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
