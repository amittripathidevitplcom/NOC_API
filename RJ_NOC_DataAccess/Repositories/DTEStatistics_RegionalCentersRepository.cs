using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_RegionalCentersRepository : IDTEStatistics_RegionalCentersRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_RegionalCentersRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_RegionalCentersDataModel GetByID(int CollegeID)
        {
            string SqlQuery = " exec UPS_DTEStatistics_RegionalCenters_GetByID @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_RegionalCenters.GetByID");

            DTEStatistics_RegionalCentersDataModel dataModels = new DTEStatistics_RegionalCentersDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels = CommonHelper.ConvertDataTable<DTEStatistics_RegionalCentersDataModel>(dataSet.Tables[0]);
            }

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
            List<RegionalCenters_RegionalCentersDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<RegionalCenters_RegionalCentersDetails>>(JsonDataTable_Data);
            dataModels.RegionalCentersDetails = EducationalQualificationDetails_StaffDetail_Item;

            return dataModels;
        }
        public bool SaveData(DTEStatistics_RegionalCentersDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string RegionalCentersDetails_Str = request.RegionalCentersDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.RegionalCentersDetails, "Temp_DTEStatistics_RegionalCenters_RegionalCentersDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_RegionalCenters_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";

            SqlQuery += " @DistanceEducationMode='" + request.DistanceEducationMode + "', ";
            SqlQuery += " @PrivateExternalProgramme='" + request.PrivateExternalProgramme + "', ";
            SqlQuery += " @RegionalCenters='" + request.@RegionalCenters + "', ";
           

            SqlQuery += " @RegionalCentersDetails_Str='" + RegionalCentersDetails_Str + "', ";

            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_RegionalCenters.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
