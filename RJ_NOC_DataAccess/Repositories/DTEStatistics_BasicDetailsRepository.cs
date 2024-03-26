using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_BasicDetailsRepository : IDTEStatistics_BasicDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_BasicDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_BasicDetailsDataModel GetByID(int CollegeID)
        {
            string SqlQuery = " exec USP_DTEStatistics_BasicDetails_GetByID @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_BasicDetails.GetByID");

            DTEStatistics_BasicDetailsDataModel dataModels = new DTEStatistics_BasicDetailsDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels = CommonHelper.ConvertDataTable<DTEStatistics_BasicDetailsDataModel>(dataSet.Tables[0]);
            }

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
            List<BasicDetails_SpecialisationDetailsDataModel> SpecialisationDetails = JsonConvert.DeserializeObject<List<BasicDetails_SpecialisationDetailsDataModel>>(JsonDataTable_Data);
            dataModels.SpecialisationDetails = SpecialisationDetails;


            string JsonDataTable_Data1 = CommonHelper.ConvertDataTable(dataSet.Tables[2]);
            List<BasicDetails_CollegeUnderUniversityDetailsDataModel> CollegeUnderUniversityDetails = JsonConvert.DeserializeObject<List<BasicDetails_CollegeUnderUniversityDetailsDataModel>>(JsonDataTable_Data1);
            dataModels.CollegeUnderUniversityDetails = CollegeUnderUniversityDetails;

            return dataModels;
        }
        public bool SaveData(DTEStatistics_BasicDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SpecialisationDetailsStr = request.SpecialisationDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.SpecialisationDetails, "Temp_DTEStatistics_BasicDetails_SpecialisationDetails") : "";
            string CollegeUnderUniversityDetailsStr = request.CollegeUnderUniversityDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.CollegeUnderUniversityDetails, "Temp_DTEStatistics_BasicDetails_CollegeUnderUniversityDetailsStr") : "";

            string SqlQuery = " exec USP_DTEStatistics_BasicDetails_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @CollegeEntryType='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";

            SqlQuery += " @AisheCode='" + request.AisheCode + "', ";
            SqlQuery += " @NameOfInstitution='" + request.Nameofinstitution + "', ";
            SqlQuery += " @YearofEstablishment='" + request.YearofEstablishment + "', ";

            SqlQuery += " @StatusPriorToEstablishment='" + request.StatusPriorToEstablishment + "', ";
            SqlQuery += " @YearDeclaredUniversityInstitute='" + request.YearDeclaredUniversityInstitute + "', ";
            SqlQuery += " @TypeOfInstitution='" + request.TypeOfInstitution + "', ";
            SqlQuery += " @OwnershipStatusOfInstitution='" + request.OwnershipStatusOfInstitution + "', ";

            SqlQuery += " @Institutionfromonegender='" + request.Institutionfromonegender + "', ";
            SqlQuery += " @InstituteUnnatBharatScheme='" + request.InstituteUnnatBharatScheme + "', ";
            SqlQuery += " @MinorityManagedInstitution='" + request.MinorityManagedInstitution + "', ";
            SqlQuery += " @IsInstitutionNCC='" + request.IsInstitutionNCC + "', ";
            SqlQuery += " @EnrolledStudentInNCC='" + request.EnrolledStudentInNCC + "', ";

            SqlQuery += " @EnrolledFemaleStudentInNCC='" + request.EnrolledFemaleStudentInNCC + "', ";
            SqlQuery += " @EnrolledTotalStudentInNCC='" + request.EnrolledTotalStudentInNCC + "', ";
            SqlQuery += " @IsInstitutionNSS='" + request.IsInstitutionNSS + "', ";

            SqlQuery += " @EnrolledStudentInNSS='" + request.EnrolledStudentInNSS + "', ";
            SqlQuery += " @EnrolledFemaleStudentInNSS='" + request.EnrolledFemaleStudentInNSS + "', ";
            SqlQuery += " @EnrolledTotalStudentInNSS='" + request.EnrolledTotalStudentInNSS + "', ";
            SqlQuery += " @IsspecializedUniversity='" + request.IsspecializedUniversity + "', ";
            SqlQuery += " @AffiliatedInstitutions='" + request.AffiliatedInstitutions + "', ";
           

            SqlQuery += " @SpecialisationDetailsStr='" + SpecialisationDetailsStr + "', ";
            SqlQuery += " @CollegeUnderUniversityDetailsStr='" + CollegeUnderUniversityDetailsStr + "', ";

            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_RegionalCenters.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
