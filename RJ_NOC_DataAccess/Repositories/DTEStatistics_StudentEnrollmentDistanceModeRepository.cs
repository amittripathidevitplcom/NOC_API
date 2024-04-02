using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;
using static iTextSharp.text.pdf.AcroFields;


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
                dataModels.EntryType = dataSet.Tables[0].Rows[0]["EntryType"].ToString();

                List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_ProgrammesDetails>? items = new List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_ProgrammesDetails>();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    DTEStatistics_StudentEnrollmentDistanceModeDataModel_ProgrammesDetails? item = new DTEStatistics_StudentEnrollmentDistanceModeDataModel_ProgrammesDetails();

                    item.AID = Convert.ToInt32(row["AID"]);
                    item.Faculty_School = row["Faculty_School"].ToString();
                    item.Department_Centre = row["Department_Centre"].ToString();
                    item.LevelID = Convert.ToInt32(row["LevelID"]);
                    item.LevelName = row["LevelName"].ToString();
                    item.Discipline = row["Discipline"].ToString();
                    item.Year = Convert.ToInt32(row["Year"]);
                    item.Month = Convert.ToInt32(row["Month"]);


                    item.Category = row["Category"].ToString();
                    item.GeneralCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row["GeneralCategorySeatsEarmarkedAsPerGOI"]);
                    item.GeneralCategoryMale = Convert.ToInt32(row["GeneralCategoryMale"]);
                    item.GeneralCategoryFemale = Convert.ToInt32(row["GeneralCategoryFemale"]);
                    item.GeneralCategoryTransGender = Convert.ToInt32(row["GeneralCategoryTransGender"]);
                    item.EWSCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row["EWSCategorySeatsEarmarkedAsPerGOI"]);
                    item.EWSCategoryMale = Convert.ToInt32(row["EWSCategoryMale"]);
                    item.EWSCategoryFemale = Convert.ToInt32(row["EWSCategoryFemale"]);
                    item.EWSCategoryTransGender = Convert.ToInt32(row["EWSCategoryTransGender"]);
                    item.SCCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row["SCCategorySeatsEarmarkedAsPerGOI"]);
                    item.SCCategoryMale = Convert.ToInt32(row["SCCategoryMale"]);
                    item.SCCategoryFemale = Convert.ToInt32(row["SCCategoryFemale"]);
                    item.SCCategoryTransGender = Convert.ToInt32(row["SCCategoryTransGender"]);
                    item.STCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row["STCategorySeatsEarmarkedAsPerGOI"]);
                    item.STCategoryMale = Convert.ToInt32(row["STCategoryMale"]);
                    item.STCategoryFemale = Convert.ToInt32(row["STCategoryFemale"]);
                    item.STCategoryTransGender = Convert.ToInt32(row["STCategoryTransGender"]);
                    item.OBCCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row["OBCCategorySeatsEarmarkedAsPerGOI"]);
                    item.OBCCategoryMale = Convert.ToInt32(row["OBCCategoryMale"]);
                    item.OBCCategoryFemale = Convert.ToInt32(row["OBCCategoryFemale"]);
                    item.OBCCategoryTransGender = Convert.ToInt32(row["OBCCategoryTransGender"]);
                    item.TotalCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row["TotalCategorySeatsEarmarkedAsPerGOI"]);
                    item.TotalCategoryMale = Convert.ToInt32(row["TotalCategoryMale"]);
                    item.TotalCategoryFemale = Convert.ToInt32(row["TotalCategoryFemale"]);
                    item.TotalCategoryTransGender = Convert.ToInt32(row["TotalCategoryTransGender"]);
                    item.Remark = row["Remark"].ToString();

                    string SqlQuery_StudentDetails = " select top 3 * from Trn_DTEStatistics_StudentEnrollmentDistanceMode ";
                    SqlQuery_StudentDetails += " Where AID>'" + item.AID + "' and EntryID='" + dataModels.EntryID + "' ";
                    DataTable datatable = new DataTable();
                    datatable = _commonHelper.Fill_DataTable(SqlQuery_StudentDetails, "DTEStatistics_RegionalCenters.GetByID");

                    List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails>? item_Student = new List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails>();
                    foreach (DataRow row_Sub in datatable.Rows)
                    {
                        DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails? item_Sub = new DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails();

                        item_Sub.Category = row_Sub["Category"].ToString();
                        item_Sub.GeneralCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row_Sub["GeneralCategorySeatsEarmarkedAsPerGOI"]);
                        item_Sub.GeneralCategoryMale = Convert.ToInt32(row_Sub["GeneralCategoryMale"]);
                        item_Sub.GeneralCategoryFemale = Convert.ToInt32(row_Sub["GeneralCategoryFemale"]);
                        item_Sub.GeneralCategoryTransGender = Convert.ToInt32(row_Sub["GeneralCategoryTransGender"]);
                        item_Sub.EWSCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row_Sub["EWSCategorySeatsEarmarkedAsPerGOI"]);
                        item_Sub.EWSCategoryMale = Convert.ToInt32(row_Sub["EWSCategoryMale"]);
                        item_Sub.EWSCategoryFemale = Convert.ToInt32(row_Sub["EWSCategoryFemale"]);
                        item_Sub.EWSCategoryTransGender = Convert.ToInt32(row_Sub["EWSCategoryTransGender"]);
                        item_Sub.SCCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row_Sub["SCCategorySeatsEarmarkedAsPerGOI"]);
                        item_Sub.SCCategoryMale = Convert.ToInt32(row_Sub["SCCategoryMale"]);
                        item_Sub.SCCategoryFemale = Convert.ToInt32(row_Sub["SCCategoryFemale"]);
                        item_Sub.SCCategoryTransGender = Convert.ToInt32(row_Sub["SCCategoryTransGender"]);
                        item_Sub.STCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row_Sub["STCategorySeatsEarmarkedAsPerGOI"]);
                        item_Sub.STCategoryMale = Convert.ToInt32(row_Sub["STCategoryMale"]);
                        item_Sub.STCategoryFemale = Convert.ToInt32(row_Sub["STCategoryFemale"]);
                        item_Sub.STCategoryTransGender = Convert.ToInt32(row_Sub["STCategoryTransGender"]);
                        item_Sub.OBCCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row_Sub["OBCCategorySeatsEarmarkedAsPerGOI"]);
                        item_Sub.OBCCategoryMale = Convert.ToInt32(row_Sub["OBCCategoryMale"]);
                        item_Sub.OBCCategoryFemale = Convert.ToInt32(row_Sub["OBCCategoryFemale"]);
                        item_Sub.OBCCategoryTransGender = Convert.ToInt32(row_Sub["OBCCategoryTransGender"]);
                        item_Sub.TotalCategorySeatsEarmarkedAsPerGOI = Convert.ToInt32(row_Sub["TotalCategorySeatsEarmarkedAsPerGOI"]);
                        item_Sub.TotalCategoryMale = Convert.ToInt32(row_Sub["TotalCategoryMale"]);
                        item_Sub.TotalCategoryFemale = Convert.ToInt32(row_Sub["TotalCategoryFemale"]);
                        item_Sub.TotalCategoryTransGender = Convert.ToInt32(row_Sub["TotalCategoryTransGender"]);

                        item_Student.Add(item_Sub);
                    }
                    item.StudentDetails = item_Student;
                    items.Add(item);
                }
                dataModels.ProgrammesDetails = items;

            }
            return dataModels;

        }
        public bool SaveData(DTEStatistics_StudentEnrollmentDistanceModeDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data> items = new List<DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data>();

            foreach (var row in request.ProgrammesDetails)
            {
                DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data item = new DTEStatistics_StudentEnrollmentDistanceModeDataModel_StudentDetails_Data();



                item.Faculty_School = row.Faculty_School.ToString();
                item.Department_Centre = row.Department_Centre.ToString();
                item.LevelID = row.LevelID;
                item.LevelName = row.LevelName;
                item.Discipline = row.Discipline.ToString();
                item.Year = row.Year;
                item.Month = row.Month;



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


                    item.Faculty_School = row.Faculty_School.ToString();
                    item.Department_Centre = row.Department_Centre.ToString();
                    item.LevelID = row.LevelID;
                    item.LevelName = row.LevelName;
                    item.Discipline = row.Discipline.ToString();
                    item.Year = row.Year;
                    item.Month = row.Month;

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

                    items.Add(item_Sub);

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
