using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_ResidentialFacilityRepository : IDTEStatistics_ResidentialFacilityRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_ResidentialFacilityRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_ResidentialFacilityDataModel GetByID(int CollegeID)
        {
            string SqlQuery = " exec UPS_DTEStatistics_ResidentialFacility_GetByID @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_ResidentialFacility.GetByID");

            DTEStatistics_ResidentialFacilityDataModel dataModels = new DTEStatistics_ResidentialFacilityDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels = CommonHelper.ConvertDataTable<DTEStatistics_ResidentialFacilityDataModel>(dataSet.Tables[0]);
            }

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
            List<ResidentialFacility_HostelDetailsDataModel> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<ResidentialFacility_HostelDetailsDataModel>>(JsonDataTable_Data);
            dataModels.HostelDetails = EducationalQualificationDetails_StaffDetail_Item;

            return dataModels;
        }
        public bool SaveData(DTEStatistics_ResidentialFacilityDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string HostalDetails_Str = request.HostelDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.HostelDetails, "Temp_DTEStatistics_ResidentialFacility_HostelDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_ResidentialFacility_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";

            SqlQuery += " @IsStaffQuarterAvailable='" + request.IsStaffQuarterAvailable + "', ";
            SqlQuery += " @TeachingStaff='" + request.TeachingStaff + "', ";
            SqlQuery += " @NonTeachingStaff='" + request.NonTeachingStaff + "', ";
            SqlQuery += " @TotalStaffQuarter='" + request.TotalStaffQuarter + "', ";
            SqlQuery += " @IsStudentsHostelAvailable='" + request.IsStudentsHostelAvailable + "', ";
            SqlQuery += " @HostalDetails_Str='" + HostalDetails_Str + "', ";

            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_ResidentialFacility.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
