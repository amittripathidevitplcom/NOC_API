using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_RegularForeignStudentEnrolmentRepository : IDTEStatistics_RegularForeignStudentEnrolmentRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_RegularForeignStudentEnrolmentRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_RegularForeignStudentEnrolmentDataModel GetByID(int CollegeID, string EntryType)
        {

            string SqlQuery = " exec UPS_DTEStatistics_RegularForeignStudentEnrolment_GetByID @CollegeID='" + CollegeID + "',@EntryType='" + EntryType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_RegionalCenters.GetByID");

            DTEStatistics_RegularForeignStudentEnrolmentDataModel dataModels = new DTEStatistics_RegularForeignStudentEnrolmentDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels.EntryID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["EntryID"]);
                dataModels.EntryDate = Convert.ToDateTime(dataSet.Tables[0].Rows[0]["EntryDate"]).ToString("dd/MMM/yyyy");
                dataModels.Department = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Department"]);
                dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
                dataModels.SelectedCollegeEntryTypeName = dataSet.Tables[0].Rows[0]["SelectedCollegeEntryTypeName"].ToString();
                dataModels.FYearID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FYearID"]);

                dataModels.ForeignStudentEnrolledInTheinstitution = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ForeignStudentEnrolledInTheinstitution"]);
                dataModels.ApprovedIntakeCapacityOfInternationalStudents = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ApprovedIntakeCapacityOfInternationalStudents"]);
            }
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<DTEStatistics_RegularForeignStudentEnrolmentDataModel_RegularForeignStudentEnrolment> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<DTEStatistics_RegularForeignStudentEnrolmentDataModel_RegularForeignStudentEnrolment>>(JsonDataTable_Data);
            dataModels.RegularForeignStudentEnrolment = EducationalQualificationDetails_StaffDetail_Item;
            return dataModels;

        }
        public bool SaveData(DTEStatistics_RegularForeignStudentEnrolmentDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string FacultyDetails_Str = request.RegularForeignStudentEnrolment.Count > 0 ? CommonHelper.GetDetailsTableQry(request.RegularForeignStudentEnrolment, "Temp_DTEStatistics_RegularForeignStudentEnrolmentDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_RegularForeignStudentEnrolment_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @EntryType='" + request.EntryType + "', ";

            SqlQuery += " @ForeignStudentEnrolledInTheinstitution='" + request.ForeignStudentEnrolledInTheinstitution + "', ";
            SqlQuery += " @ApprovedIntakeCapacityOfInternationalStudents='" + request.ApprovedIntakeCapacityOfInternationalStudents + "', ";
            SqlQuery += " @AlsoIncludeTemporaryContractualVisitingTeacherData='" + request.AlsoIncludeTemporaryContractualVisitingTeacherData + "', ";
            SqlQuery += " @ForeignRegularStudentEnrollementThroughProgrammesOfferedByInstitution='" + request.ForeignRegularStudentEnrollementThroughProgrammesOfferedByInstitution + "', ";

            SqlQuery += " @FacultyDetails_Str='" + FacultyDetails_Str + "', ";



            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_RegularForeignStudentEnrolment.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;

        }
    }
}
