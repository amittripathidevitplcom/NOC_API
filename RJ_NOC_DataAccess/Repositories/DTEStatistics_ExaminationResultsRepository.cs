using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;
using static iTextSharp.text.pdf.AcroFields;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_ExaminationResultsRepository : IDTEStatistics_ExaminationResultsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_ExaminationResultsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_ExaminationResultsDataModel GetByID(int CollegeID, string EntryType)
        {

            string SqlQuery = " exec UPS_DTEStatistics_ExaminationResults_GetByID @CollegeID='" + CollegeID + "',@EntryType='" + EntryType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_RegionalCenters.GetByID");

            DTEStatistics_ExaminationResultsDataModel dataModels = new DTEStatistics_ExaminationResultsDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels.EntryID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["EntryID"]);
                dataModels.EntryDate = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EntryDate"]).ToString("dd/MMM/yyyy");
                dataModels.Department = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Department"]);
                dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
                dataModels.SelectedCollegeEntryTypeName = dataSet.Tables[0].Rows[0]["SelectedCollegeEntryTypeName"].ToString();
                dataModels.FYearID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FYearID"]);
                dataModels.EntryType = dataSet.Tables[0].Rows[0]["EntryType"].ToString();

                List<DTEStatistics_ExaminationResultsDataModel_ProgrammesDetails>? items = new List<DTEStatistics_ExaminationResultsDataModel_ProgrammesDetails>();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    DTEStatistics_ExaminationResultsDataModel_ProgrammesDetails? item = new DTEStatistics_ExaminationResultsDataModel_ProgrammesDetails();

                    item.AID = Convert.ToInt32(row["AID"]);
                    item.Faculty_School = row["Faculty_School"].ToString();
                    item.Department_Centre = row["Department_Centre"].ToString();
                    item.LevelID = Convert.ToInt32(row["LevelID"]);
                    item.LevelName = row["LevelName"].ToString();
                    item.Discipline = row["Discipline"].ToString();



                    item.AppeardCategory = row["AppeardCategory"].ToString();
                    item.AppeardGeneralCategoryMale = Convert.ToInt32(row["AppeardGeneralCategoryMale"]);
                    item.AppeardGeneralCategoryFemale = Convert.ToInt32(row["AppeardGeneralCategoryFemale"]);
                    item.AppeardGeneralCategoryTransGender = Convert.ToInt32(row["AppeardGeneralCategoryTransGender"]);
                    item.AppeardEWSCategoryMale = Convert.ToInt32(row["AppeardEWSCategoryMale"]);
                    item.AppeardEWSCategoryFemale = Convert.ToInt32(row["AppeardEWSCategoryFemale"]);
                    item.AppeardEWSCategoryTransGender = Convert.ToInt32(row["AppeardEWSCategoryTransGender"]);
                    item.AppeardSCCategoryMale = Convert.ToInt32(row["AppeardSCCategoryMale"]);
                    item.AppeardSCCategoryFemale = Convert.ToInt32(row["AppeardSCCategoryFemale"]);
                    item.AppeardSCCategoryTransGender = Convert.ToInt32(row["AppeardSCCategoryTransGender"]);
                    item.AppeardSTCategoryMale = Convert.ToInt32(row["AppeardSTCategoryMale"]);
                    item.AppeardSTCategoryFemale = Convert.ToInt32(row["AppeardSTCategoryFemale"]);
                    item.AppeardSTCategoryTransGender = Convert.ToInt32(row["AppeardSTCategoryTransGender"]);
                    item.AppeardOBCCategoryMale = Convert.ToInt32(row["AppeardOBCCategoryMale"]);
                    item.AppeardOBCCategoryFemale = Convert.ToInt32(row["AppeardOBCCategoryFemale"]);
                    item.AppeardOBCCategoryTransGender = Convert.ToInt32(row["AppeardOBCCategoryTransGender"]);
                    item.AppeardTotalCategoryMale = Convert.ToInt32(row["AppeardTotalCategoryMale"]);
                    item.AppeardTotalCategoryFemale = Convert.ToInt32(row["AppeardTotalCategoryFemale"]);
                    item.AppeardTotalCategoryTransGender = Convert.ToInt32(row["AppeardTotalCategoryTransGender"]);
                    item.AppeardRemark = row["AppeardRemark"].ToString();

                    item.PassedCategory = row["PassedCategory"].ToString();
                    item.PassedGeneralCategoryMale = Convert.ToInt32(row["PassedGeneralCategoryMale"]);
                    item.PassedGeneralCategoryFemale = Convert.ToInt32(row["PassedGeneralCategoryFemale"]);
                    item.PassedGeneralCategoryTransGender = Convert.ToInt32(row["PassedGeneralCategoryTransGender"]);
                    item.PassedEWSCategoryMale = Convert.ToInt32(row["PassedEWSCategoryMale"]);
                    item.PassedEWSCategoryFemale = Convert.ToInt32(row["PassedEWSCategoryFemale"]);
                    item.PassedEWSCategoryTransGender = Convert.ToInt32(row["PassedEWSCategoryTransGender"]);
                    item.PassedSCCategoryMale = Convert.ToInt32(row["PassedSCCategoryMale"]);
                    item.PassedSCCategoryFemale = Convert.ToInt32(row["PassedSCCategoryFemale"]);
                    item.PassedSCCategoryTransGender = Convert.ToInt32(row["PassedSCCategoryTransGender"]);
                    item.PassedSTCategoryMale = Convert.ToInt32(row["PassedSTCategoryMale"]);
                    item.PassedSTCategoryFemale = Convert.ToInt32(row["PassedSTCategoryFemale"]);
                    item.PassedSTCategoryTransGender = Convert.ToInt32(row["PassedSTCategoryTransGender"]);
                    item.PassedOBCCategoryMale = Convert.ToInt32(row["PassedOBCCategoryMale"]);
                    item.PassedOBCCategoryFemale = Convert.ToInt32(row["PassedOBCCategoryFemale"]);
                    item.PassedOBCCategoryTransGender = Convert.ToInt32(row["PassedOBCCategoryTransGender"]);
                    item.PassedTotalCategoryMale = Convert.ToInt32(row["PassedTotalCategoryMale"]);
                    item.PassedTotalCategoryFemale = Convert.ToInt32(row["PassedTotalCategoryFemale"]);
                    item.PassedTotalCategoryTransGender = Convert.ToInt32(row["PassedTotalCategoryTransGender"]);
                    item.PassedRemark = row["PassedRemark"].ToString();


                    item.OutofTotalPassedCategory = row["OutofTotalPassedCategory"].ToString();
                    item.OutofTotalPassedGeneralCategoryMale = Convert.ToInt32(row["OutofTotalPassedGeneralCategoryMale"]);
                    item.OutofTotalPassedGeneralCategoryFemale = Convert.ToInt32(row["OutofTotalPassedGeneralCategoryFemale"]);
                    item.OutofTotalPassedGeneralCategoryTransGender = Convert.ToInt32(row["OutofTotalPassedGeneralCategoryTransGender"]);
                    item.OutofTotalPassedEWSCategoryMale = Convert.ToInt32(row["OutofTotalPassedEWSCategoryMale"]);
                    item.OutofTotalPassedEWSCategoryFemale = Convert.ToInt32(row["OutofTotalPassedEWSCategoryFemale"]);
                    item.OutofTotalPassedEWSCategoryTransGender = Convert.ToInt32(row["OutofTotalPassedEWSCategoryTransGender"]);
                    item.OutofTotalPassedSCCategoryMale = Convert.ToInt32(row["OutofTotalPassedSCCategoryMale"]);
                    item.OutofTotalPassedSCCategoryFemale = Convert.ToInt32(row["OutofTotalPassedSCCategoryFemale"]);
                    item.OutofTotalPassedSCCategoryTransGender = Convert.ToInt32(row["OutofTotalPassedSCCategoryTransGender"]);
                    item.OutofTotalPassedSTCategoryMale = Convert.ToInt32(row["OutofTotalPassedSTCategoryMale"]);
                    item.OutofTotalPassedSTCategoryFemale = Convert.ToInt32(row["OutofTotalPassedSTCategoryFemale"]);
                    item.OutofTotalPassedSTCategoryTransGender = Convert.ToInt32(row["OutofTotalPassedSTCategoryTransGender"]);
                    item.OutofTotalPassedOBCCategoryMale = Convert.ToInt32(row["OutofTotalPassedOBCCategoryMale"]);
                    item.OutofTotalPassedOBCCategoryFemale = Convert.ToInt32(row["OutofTotalPassedOBCCategoryFemale"]);
                    item.OutofTotalPassedOBCCategoryTransGender = Convert.ToInt32(row["OutofTotalPassedOBCCategoryTransGender"]);
                    item.OutofTotalPassedTotalCategoryMale = Convert.ToInt32(row["OutofTotalPassedTotalCategoryMale"]);
                    item.OutofTotalPassedTotalCategoryFemale = Convert.ToInt32(row["OutofTotalPassedTotalCategoryFemale"]);
                    item.OutofTotalPassedTotalCategoryTransGender = Convert.ToInt32(row["OutofTotalPassedTotalCategoryTransGender"]);
                    item.OutofTotalPassedRemark = row["OutofTotalPassedRemark"].ToString();

                    string SqlQuery_StudentDetails = " select top 3 * from Trn_DTEStatistics_ExaminationResults ";
                    SqlQuery_StudentDetails += " Where AID>'" + item.AID + "' and EntryID='" + dataModels.EntryID + "' ";
                    DataTable datatable = new DataTable();
                    datatable = _commonHelper.Fill_DataTable(SqlQuery_StudentDetails, "DTEStatistics_RegionalCenters.GetByID");

                    List<DTEStatistics_ExaminationResultsDataModel_StudentDetails>? item_Student = new List<DTEStatistics_ExaminationResultsDataModel_StudentDetails>();
                    foreach (DataRow row_Sub in datatable.Rows)
                    {
                        DTEStatistics_ExaminationResultsDataModel_StudentDetails? item_Sub = new DTEStatistics_ExaminationResultsDataModel_StudentDetails();


                        item_Sub.AppeardCategory = row_Sub["AppeardCategory"].ToString();
                        item_Sub.AppeardGeneralCategoryMale = Convert.ToInt32(row_Sub["AppeardGeneralCategoryMale"]);
                        item_Sub.AppeardGeneralCategoryFemale = Convert.ToInt32(row_Sub["AppeardGeneralCategoryFemale"]);
                        item_Sub.AppeardGeneralCategoryTransGender = Convert.ToInt32(row_Sub["AppeardGeneralCategoryTransGender"]);
                        item_Sub.AppeardEWSCategoryMale = Convert.ToInt32(row_Sub["AppeardEWSCategoryMale"]);
                        item_Sub.AppeardEWSCategoryFemale = Convert.ToInt32(row_Sub["AppeardEWSCategoryFemale"]);
                        item_Sub.AppeardEWSCategoryTransGender = Convert.ToInt32(row_Sub["AppeardEWSCategoryTransGender"]);
                        item_Sub.AppeardSCCategoryMale = Convert.ToInt32(row_Sub["AppeardSCCategoryMale"]);
                        item_Sub.AppeardSCCategoryFemale = Convert.ToInt32(row_Sub["AppeardSCCategoryFemale"]);
                        item_Sub.AppeardSCCategoryTransGender = Convert.ToInt32(row_Sub["AppeardSCCategoryTransGender"]);
                        item_Sub.AppeardSTCategoryMale = Convert.ToInt32(row_Sub["AppeardSTCategoryMale"]);
                        item_Sub.AppeardSTCategoryFemale = Convert.ToInt32(row_Sub["AppeardSTCategoryFemale"]);
                        item_Sub.AppeardSTCategoryTransGender = Convert.ToInt32(row_Sub["AppeardSTCategoryTransGender"]);
                        item_Sub.AppeardOBCCategoryMale = Convert.ToInt32(row_Sub["AppeardOBCCategoryMale"]);
                        item_Sub.AppeardOBCCategoryFemale = Convert.ToInt32(row_Sub["AppeardOBCCategoryFemale"]);
                        item_Sub.AppeardOBCCategoryTransGender = Convert.ToInt32(row_Sub["AppeardOBCCategoryTransGender"]);
                        item_Sub.AppeardTotalCategoryMale = Convert.ToInt32(row_Sub["AppeardTotalCategoryMale"]);
                        item_Sub.AppeardTotalCategoryFemale = Convert.ToInt32(row_Sub["AppeardTotalCategoryFemale"]);
                        item_Sub.AppeardTotalCategoryTransGender = Convert.ToInt32(row_Sub["AppeardTotalCategoryTransGender"]);
                        //item_Sub.AppeardRemark = row_Sub["AppeardRemark"].ToString();

                        item_Sub.PassedCategory = row_Sub["PassedCategory"].ToString();
                        item_Sub.PassedGeneralCategoryMale = Convert.ToInt32(row_Sub["PassedGeneralCategoryMale"]);
                        item_Sub.PassedGeneralCategoryFemale = Convert.ToInt32(row_Sub["PassedGeneralCategoryFemale"]);
                        item_Sub.PassedGeneralCategoryTransGender = Convert.ToInt32(row_Sub["PassedGeneralCategoryTransGender"]);
                        item_Sub.PassedEWSCategoryMale = Convert.ToInt32(row_Sub["PassedEWSCategoryMale"]);
                        item_Sub.PassedEWSCategoryFemale = Convert.ToInt32(row_Sub["PassedEWSCategoryFemale"]);
                        item_Sub.PassedEWSCategoryTransGender = Convert.ToInt32(row_Sub["PassedEWSCategoryTransGender"]);
                        item_Sub.PassedSCCategoryMale = Convert.ToInt32(row_Sub["PassedSCCategoryMale"]);
                        item_Sub.PassedSCCategoryFemale = Convert.ToInt32(row_Sub["PassedSCCategoryFemale"]);
                        item_Sub.PassedSCCategoryTransGender = Convert.ToInt32(row_Sub["PassedSCCategoryTransGender"]);
                        item_Sub.PassedSTCategoryMale = Convert.ToInt32(row_Sub["PassedSTCategoryMale"]);
                        item_Sub.PassedSTCategoryFemale = Convert.ToInt32(row_Sub["PassedSTCategoryFemale"]);
                        item_Sub.PassedSTCategoryTransGender = Convert.ToInt32(row_Sub["PassedSTCategoryTransGender"]);
                        item_Sub.PassedOBCCategoryMale = Convert.ToInt32(row_Sub["PassedOBCCategoryMale"]);
                        item_Sub.PassedOBCCategoryFemale = Convert.ToInt32(row_Sub["PassedOBCCategoryFemale"]);
                        item_Sub.PassedOBCCategoryTransGender = Convert.ToInt32(row_Sub["PassedOBCCategoryTransGender"]);
                        item_Sub.PassedTotalCategoryMale = Convert.ToInt32(row_Sub["PassedTotalCategoryMale"]);
                        item_Sub.PassedTotalCategoryFemale = Convert.ToInt32(row_Sub["PassedTotalCategoryFemale"]);
                        item_Sub.PassedTotalCategoryTransGender = Convert.ToInt32(row_Sub["PassedTotalCategoryTransGender"]);
                        //item_Sub.PassedRemark = row_Sub["PassedRemark"].ToString();


                        item_Sub.OutofTotalPassedCategory = row_Sub["OutofTotalPassedCategory"].ToString();
                        item_Sub.OutofTotalPassedGeneralCategoryMale = Convert.ToInt32(row_Sub["OutofTotalPassedGeneralCategoryMale"]);
                        item_Sub.OutofTotalPassedGeneralCategoryFemale = Convert.ToInt32(row_Sub["OutofTotalPassedGeneralCategoryFemale"]);
                        item_Sub.OutofTotalPassedGeneralCategoryTransGender = Convert.ToInt32(row_Sub["OutofTotalPassedGeneralCategoryTransGender"]);
                        item_Sub.OutofTotalPassedEWSCategoryMale = Convert.ToInt32(row_Sub["OutofTotalPassedEWSCategoryMale"]);
                        item_Sub.OutofTotalPassedEWSCategoryFemale = Convert.ToInt32(row_Sub["OutofTotalPassedEWSCategoryFemale"]);
                        item_Sub.OutofTotalPassedEWSCategoryTransGender = Convert.ToInt32(row_Sub["OutofTotalPassedEWSCategoryTransGender"]);
                        item_Sub.OutofTotalPassedSCCategoryMale = Convert.ToInt32(row_Sub["OutofTotalPassedSCCategoryMale"]);
                        item_Sub.OutofTotalPassedSCCategoryFemale = Convert.ToInt32(row_Sub["OutofTotalPassedSCCategoryFemale"]);
                        item_Sub.OutofTotalPassedSCCategoryTransGender = Convert.ToInt32(row_Sub["OutofTotalPassedSCCategoryTransGender"]);
                        item_Sub.OutofTotalPassedSTCategoryMale = Convert.ToInt32(row_Sub["OutofTotalPassedSTCategoryMale"]);
                        item_Sub.OutofTotalPassedSTCategoryFemale = Convert.ToInt32(row_Sub["OutofTotalPassedSTCategoryFemale"]);
                        item_Sub.OutofTotalPassedSTCategoryTransGender = Convert.ToInt32(row_Sub["OutofTotalPassedSTCategoryTransGender"]);
                        item_Sub.OutofTotalPassedOBCCategoryMale = Convert.ToInt32(row_Sub["OutofTotalPassedOBCCategoryMale"]);
                        item_Sub.OutofTotalPassedOBCCategoryFemale = Convert.ToInt32(row_Sub["OutofTotalPassedOBCCategoryFemale"]);
                        item_Sub.OutofTotalPassedOBCCategoryTransGender = Convert.ToInt32(row_Sub["OutofTotalPassedOBCCategoryTransGender"]);
                        item_Sub.OutofTotalPassedTotalCategoryMale = Convert.ToInt32(row_Sub["OutofTotalPassedTotalCategoryMale"]);
                        item_Sub.OutofTotalPassedTotalCategoryFemale = Convert.ToInt32(row_Sub["OutofTotalPassedTotalCategoryFemale"]);
                        item_Sub.OutofTotalPassedTotalCategoryTransGender = Convert.ToInt32(row_Sub["OutofTotalPassedTotalCategoryTransGender"]);
                       // item_Sub.OutofTotalPassedRemark = row_Sub["OutofTotalPassedRemark"].ToString();


                        item_Student.Add(item_Sub);
                    }
                    item.StudentDetails = item_Student;
                    items.Add(item);
                }
                dataModels.ProgrammesDetails = items;

            }
            return dataModels;

        }
        public bool SaveData(DTEStatistics_ExaminationResultsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            List<DTEStatistics_ExaminationResultsDataModel_StudentDetails_Data> items = new List<DTEStatistics_ExaminationResultsDataModel_StudentDetails_Data>();

            foreach (var row in request.ProgrammesDetails)
            {
                DTEStatistics_ExaminationResultsDataModel_StudentDetails_Data item = new DTEStatistics_ExaminationResultsDataModel_StudentDetails_Data();



                item.Faculty_School = row.Faculty_School.ToString();
                item.Department_Centre = row.Department_Centre.ToString();
                item.LevelID = row.LevelID;
                item.LevelName = row.LevelName;
                item.Discipline = row.Discipline.ToString();

                //Appeard
                item.AppeardCategory = row.AppeardCategory.ToString();
                item.AppeardGeneralCategoryMale = row.AppeardGeneralCategoryMale;
                item.AppeardGeneralCategoryFemale = row.AppeardGeneralCategoryFemale;
                item.AppeardGeneralCategoryTransGender = row.AppeardGeneralCategoryTransGender;
                item.AppeardEWSCategoryMale = row.AppeardEWSCategoryMale;
                item.AppeardEWSCategoryFemale = row.AppeardEWSCategoryFemale;
                item.AppeardEWSCategoryTransGender = row.AppeardEWSCategoryTransGender;
                item.AppeardSCCategoryMale = row.AppeardSCCategoryMale;
                item.AppeardSCCategoryFemale = row.AppeardSCCategoryFemale;
                item.AppeardSCCategoryTransGender = row.AppeardSCCategoryTransGender;
                item.AppeardSTCategoryMale = row.AppeardSTCategoryMale;
                item.AppeardSTCategoryFemale = row.AppeardSTCategoryFemale;
                item.AppeardSTCategoryTransGender = row.AppeardSTCategoryTransGender;
                item.AppeardOBCCategoryMale = row.AppeardOBCCategoryMale;
                item.AppeardOBCCategoryFemale = row.AppeardOBCCategoryFemale;
                item.AppeardOBCCategoryTransGender = row.AppeardOBCCategoryTransGender;
                item.AppeardTotalCategoryMale = row.AppeardTotalCategoryMale;
                item.AppeardTotalCategoryFemale = row.AppeardTotalCategoryFemale;
                item.AppeardTotalCategoryTransGender = row.AppeardTotalCategoryTransGender;
                item.AppeardRemark = row.AppeardRemark;
                //Passed
                item.PassedCategory = row.PassedCategory.ToString();
                item.PassedGeneralCategoryMale = row.PassedGeneralCategoryMale;
                item.PassedGeneralCategoryFemale = row.PassedGeneralCategoryFemale;
                item.PassedGeneralCategoryTransGender = row.PassedGeneralCategoryTransGender;
                item.PassedEWSCategoryMale = row.PassedEWSCategoryMale;
                item.PassedEWSCategoryFemale = row.PassedEWSCategoryFemale;
                item.PassedEWSCategoryTransGender = row.PassedEWSCategoryTransGender;
                item.PassedSCCategoryMale = row.PassedSCCategoryMale;
                item.PassedSCCategoryFemale = row.PassedSCCategoryFemale;
                item.PassedSCCategoryTransGender = row.PassedSCCategoryTransGender;
                item.PassedSTCategoryMale = row.PassedSTCategoryMale;
                item.PassedSTCategoryFemale = row.PassedSTCategoryFemale;
                item.PassedSTCategoryTransGender = row.PassedSTCategoryTransGender;
                item.PassedOBCCategoryMale = row.PassedOBCCategoryMale;
                item.PassedOBCCategoryFemale = row.PassedOBCCategoryFemale;
                item.PassedOBCCategoryTransGender = row.PassedOBCCategoryTransGender;
                item.PassedTotalCategoryMale = row.PassedTotalCategoryMale;
                item.PassedTotalCategoryFemale = row.PassedTotalCategoryFemale;
                item.PassedTotalCategoryTransGender = row.PassedTotalCategoryTransGender;
                item.PassedRemark = row.PassedRemark;
                //out of Passed
                item.OutofTotalPassedCategory = row.OutofTotalPassedCategory.ToString();
                item.OutofTotalPassedGeneralCategoryMale = row.OutofTotalPassedGeneralCategoryMale;
                item.OutofTotalPassedGeneralCategoryFemale = row.OutofTotalPassedGeneralCategoryFemale;
                item.OutofTotalPassedGeneralCategoryTransGender = row.OutofTotalPassedGeneralCategoryTransGender;
                item.OutofTotalPassedEWSCategoryMale = row.OutofTotalPassedEWSCategoryMale;
                item.OutofTotalPassedEWSCategoryFemale = row.OutofTotalPassedEWSCategoryFemale;
                item.OutofTotalPassedEWSCategoryTransGender = row.OutofTotalPassedEWSCategoryTransGender;
                item.OutofTotalPassedSCCategoryMale = row.OutofTotalPassedSCCategoryMale;
                item.OutofTotalPassedSCCategoryFemale = row.OutofTotalPassedSCCategoryFemale;
                item.OutofTotalPassedSCCategoryTransGender = row.OutofTotalPassedSCCategoryTransGender;
                item.OutofTotalPassedSTCategoryMale = row.OutofTotalPassedSTCategoryMale;
                item.OutofTotalPassedSTCategoryFemale = row.OutofTotalPassedSTCategoryFemale;
                item.OutofTotalPassedSTCategoryTransGender = row.OutofTotalPassedSTCategoryTransGender;
                item.OutofTotalPassedOBCCategoryMale = row.OutofTotalPassedOBCCategoryMale;
                item.OutofTotalPassedOBCCategoryFemale = row.OutofTotalPassedOBCCategoryFemale;
                item.OutofTotalPassedOBCCategoryTransGender = row.OutofTotalPassedOBCCategoryTransGender;
                item.OutofTotalPassedTotalCategoryMale = row.OutofTotalPassedTotalCategoryMale;
                item.OutofTotalPassedTotalCategoryFemale = row.OutofTotalPassedTotalCategoryFemale;
                item.OutofTotalPassedTotalCategoryTransGender = row.OutofTotalPassedTotalCategoryTransGender;
                item.OutofTotalPassedRemark = row.OutofTotalPassedRemark;

                items.Add(item);

                foreach (var row_Sub in row.StudentDetails)
                {
                    DTEStatistics_ExaminationResultsDataModel_StudentDetails_Data item_Sub = new DTEStatistics_ExaminationResultsDataModel_StudentDetails_Data();

                    item.Faculty_School = row.Faculty_School.ToString();
                    item.Department_Centre = row.Department_Centre.ToString();
                    item.LevelID = row.LevelID;
                    item.LevelName = row.LevelName;
                    item.Discipline = row.Discipline.ToString();

                    //Appeard
                    item_Sub.AppeardCategory = row_Sub.AppeardCategory.ToString();
                    item_Sub.AppeardGeneralCategoryMale = row_Sub.AppeardGeneralCategoryMale;
                    item_Sub.AppeardGeneralCategoryFemale = row_Sub.AppeardGeneralCategoryFemale;
                    item_Sub.AppeardGeneralCategoryTransGender = row_Sub.AppeardGeneralCategoryTransGender;
                    item_Sub.AppeardEWSCategoryMale = row_Sub.AppeardEWSCategoryMale;
                    item_Sub.AppeardEWSCategoryFemale = row_Sub.AppeardEWSCategoryFemale;
                    item_Sub.AppeardEWSCategoryTransGender = row_Sub.AppeardEWSCategoryTransGender;
                    item_Sub.AppeardSCCategoryMale = row_Sub.AppeardSCCategoryMale;
                    item_Sub.AppeardSCCategoryFemale = row_Sub.AppeardSCCategoryFemale;
                    item_Sub.AppeardSCCategoryTransGender = row_Sub.AppeardSCCategoryTransGender;
                    item_Sub.AppeardSTCategoryMale = row_Sub.AppeardSTCategoryMale;
                    item_Sub.AppeardSTCategoryFemale = row_Sub.AppeardSTCategoryFemale;
                    item_Sub.AppeardSTCategoryTransGender = row_Sub.AppeardSTCategoryTransGender;
                    item_Sub.AppeardOBCCategoryMale = row_Sub.AppeardOBCCategoryMale;
                    item_Sub.AppeardOBCCategoryFemale = row_Sub.AppeardOBCCategoryFemale;
                    item_Sub.AppeardOBCCategoryTransGender = row_Sub.AppeardOBCCategoryTransGender;
                    item_Sub.AppeardTotalCategoryMale = row_Sub.AppeardTotalCategoryMale;
                    item_Sub.AppeardTotalCategoryFemale = row_Sub.AppeardTotalCategoryFemale;
                    item_Sub.AppeardTotalCategoryTransGender = row_Sub.AppeardTotalCategoryTransGender;
                    //Passed
                    item_Sub.PassedCategory = row_Sub.PassedCategory.ToString();
                    item_Sub.PassedGeneralCategoryMale = row_Sub.PassedGeneralCategoryMale;
                    item_Sub.PassedGeneralCategoryFemale = row_Sub.PassedGeneralCategoryFemale;
                    item_Sub.PassedGeneralCategoryTransGender = row_Sub.PassedGeneralCategoryTransGender;
                    item_Sub.PassedEWSCategoryMale = row_Sub.PassedEWSCategoryMale;
                    item_Sub.PassedEWSCategoryFemale = row_Sub.PassedEWSCategoryFemale;
                    item_Sub.PassedEWSCategoryTransGender = row_Sub.PassedEWSCategoryTransGender;
                    item_Sub.PassedSCCategoryMale = row_Sub.PassedSCCategoryMale;
                    item_Sub.PassedSCCategoryFemale = row_Sub.PassedSCCategoryFemale;
                    item_Sub.PassedSCCategoryTransGender = row_Sub.PassedSCCategoryTransGender;
                    item_Sub.PassedSTCategoryMale = row_Sub.PassedSTCategoryMale;
                    item_Sub.PassedSTCategoryFemale = row_Sub.PassedSTCategoryFemale;
                    item_Sub.PassedSTCategoryTransGender = row_Sub.PassedSTCategoryTransGender;
                    item_Sub.PassedOBCCategoryMale = row_Sub.PassedOBCCategoryMale;
                    item_Sub.PassedOBCCategoryFemale = row_Sub.PassedOBCCategoryFemale;
                    item_Sub.PassedOBCCategoryTransGender = row_Sub.PassedOBCCategoryTransGender;
                    item_Sub.PassedTotalCategoryMale = row_Sub.PassedTotalCategoryMale;
                    item_Sub.PassedTotalCategoryFemale = row_Sub.PassedTotalCategoryFemale;
                    item_Sub.PassedTotalCategoryTransGender = row_Sub.PassedTotalCategoryTransGender;
                    //out of Passed
                    item_Sub.OutofTotalPassedCategory = row_Sub.OutofTotalPassedCategory.ToString();
                    item_Sub.OutofTotalPassedGeneralCategoryMale = row_Sub.OutofTotalPassedGeneralCategoryMale;
                    item_Sub.OutofTotalPassedGeneralCategoryFemale = row_Sub.OutofTotalPassedGeneralCategoryFemale;
                    item_Sub.OutofTotalPassedGeneralCategoryTransGender = row_Sub.OutofTotalPassedGeneralCategoryTransGender;
                    item_Sub.OutofTotalPassedEWSCategoryMale = row_Sub.OutofTotalPassedEWSCategoryMale;
                    item_Sub.OutofTotalPassedEWSCategoryFemale = row_Sub.OutofTotalPassedEWSCategoryFemale;
                    item_Sub.OutofTotalPassedEWSCategoryTransGender = row_Sub.OutofTotalPassedEWSCategoryTransGender;
                    item_Sub.OutofTotalPassedSCCategoryMale = row_Sub.OutofTotalPassedSCCategoryMale;
                    item_Sub.OutofTotalPassedSCCategoryFemale = row_Sub.OutofTotalPassedSCCategoryFemale;
                    item_Sub.OutofTotalPassedSCCategoryTransGender = row_Sub.OutofTotalPassedSCCategoryTransGender;
                    item_Sub.OutofTotalPassedSTCategoryMale = row_Sub.OutofTotalPassedSTCategoryMale;
                    item_Sub.OutofTotalPassedSTCategoryFemale = row_Sub.OutofTotalPassedSTCategoryFemale;
                    item_Sub.OutofTotalPassedSTCategoryTransGender = row_Sub.OutofTotalPassedSTCategoryTransGender;
                    item_Sub.OutofTotalPassedOBCCategoryMale = row_Sub.OutofTotalPassedOBCCategoryMale;
                    item_Sub.OutofTotalPassedOBCCategoryFemale = row_Sub.OutofTotalPassedOBCCategoryFemale;
                    item_Sub.OutofTotalPassedOBCCategoryTransGender = row_Sub.OutofTotalPassedOBCCategoryTransGender;
                    item_Sub.OutofTotalPassedTotalCategoryMale = row_Sub.OutofTotalPassedTotalCategoryMale;
                    item_Sub.OutofTotalPassedTotalCategoryFemale = row_Sub.OutofTotalPassedTotalCategoryFemale;
                    item_Sub.OutofTotalPassedTotalCategoryTransGender = row_Sub.OutofTotalPassedTotalCategoryTransGender;

                    items.Add(item_Sub);

                }
            }

            string FacultyDetails_Str = items.Count > 0 ? CommonHelper.GetDetailsTableQry(items, "Temp_DTEStatistics_ExaminationResultsDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_ExaminationResults_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @EntryType='" + request.EntryType + "', ";

            SqlQuery += " @FacultyDetails_Str='" + FacultyDetails_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_ExaminationResults.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
