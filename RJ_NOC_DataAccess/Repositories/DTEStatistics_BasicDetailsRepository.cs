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
            dataModels.InstituteHeadDetails = CommonHelper.ConvertDataTable<BasicDetails_InstituteHeadDetailsDataModel>(dataSet.Tables[3]);
            dataModels.NodalOfficerDetails = CommonHelper.ConvertDataTable<BasicDetails_NodalOfficerDetailsDataModel>(dataSet.Tables[4]);
            dataModels.AffiliationDetails = CommonHelper.ConvertDataTable<BasicDetails_AffiliationDetailsDataModel>(dataSet.Tables[5]);

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

            SqlQuery += " @IPAddress='" + IPAddress + "', ";

            SqlQuery += " @ManagementOfTheInstitution='" + request.ManagementOfTheInstitution + "', ";
            SqlQuery += " @IsEveningCollege='" + request.IsEveningCollege + "', ";
            SqlQuery += " @AutonomousInstitute='" + request.AutonomousInstitute + "', ";
            SqlQuery += " @MinorityCommunityType='" + request.MinorityCommunityType + "', ";
            SqlQuery += " @EnrolledStudentInNCCOtherInstitute='" + request.EnrolledStudentInNCCOtherInstitute + "', ";
            SqlQuery += " @EnrolledFemaleStudentInNCCOtherInstitute='" + request.EnrolledFemaleStudentInNCCOtherInstitute + "', ";
            SqlQuery += " @SpecialisedUniversity='" + request.SpecialisedUniversity + "', ";
            SqlQuery += " @OtherSpecialisedUniversity='" + request.OtherSpecialisedUniversity + "', ";
            SqlQuery += " @WhetherTheCollegeRunningDiplomaLevelCourse='" + request.WhetherTheCollegeRunningDiplomaLevelCourse + "', ";
            SqlQuery += " @DiplomaLevelCourse='" + request.DiplomaLevelCourse + "', ";
            SqlQuery += " @OtherDiplomaCourse='" + request.OtherDiplomaCourse + "', ";
            SqlQuery += " @WhetherAwardsDegreethroughAnyUniversity='" + request.WhetherAwardsDegreethroughAnyUniversity + "', ";
            SqlQuery += " @YearofRecognition='" + request.YearofRecognition + "', ";

            if (request.InstituteHeadDetails != null)
            {
                SqlQuery += "@InstituteHeadDetails='select ''" + request.InstituteHeadDetails.NameOfUniversityNodalOfficerForAISHE + "''" + " as NameOfUniversityNodalOfficerForAISHE, " +
                    "''" + request.InstituteHeadDetails.Email + "''" + " as Email, " +
                    "''" + request.InstituteHeadDetails.DesignationID + "''" + " as DesignationID, " +
                    "''" + request.InstituteHeadDetails.DesignationName + "''" + " as DesignationName,"+
                    "''" + request.InstituteHeadDetails.MobileNo + "''" + " as MobileNo,"+
                    "''" + request.InstituteHeadDetails.TelephoneNo + "''" + " as TelephoneNo',";
            }     
            if (request.NodalOfficerDetails != null)
            {
                SqlQuery += "@NodalOfficerDetails='select ''" + request.NodalOfficerDetails.NameOfUniversityNodalOfficerForAISHE + "''" + " as NameOfUniversityNodalOfficerForAISHE, " +
                    "''" + request.NodalOfficerDetails.Email + "''" + " as Email, " +
                    "''" + request.NodalOfficerDetails.DesignationID + "''" + " as DesignationID, " +
                    "''" + request.NodalOfficerDetails.DesignationName + "''" + " as DesignationName,"+
                    "''" + request.NodalOfficerDetails.MobileNo + "''" + " as MobileNo,"+
                    "''" + request.NodalOfficerDetails.TelephoneNo + "''" + " as TelephoneNo',";
            }    
            if (request.AffiliationDetails != null)
            {
                SqlQuery += "@AffiliationDetails='select ''" + request.AffiliationDetails.NameStatutorybody + "''" + " as NameStatutorybody, " +
                    "''" + request.AffiliationDetails.AffiliationYear + "''" + " as AffiliationYear, " +
                    "''" + request.AffiliationDetails.AffiliatedOtherUniversity + "''" + " as AffiliatedOtherUniversity' ,";
            }
            SqlQuery += " @OtherUniversityName='" + request.OtherUniversityName + "' ";


            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_RegionalCenters.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
