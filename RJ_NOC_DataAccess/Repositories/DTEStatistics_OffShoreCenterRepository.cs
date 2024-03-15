using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_OffShoreCenterRepository : IDTEStatistics_OffShoreCenterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_OffShoreCenterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_OffShoreCenterDataModel GetByID(int CollegeID)
        {
            string SqlQuery = " exec UPS_DTEStatistics_OffShoreCenter_GetByID @CollegeID='" + CollegeID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEStatistics_OffShoreCenter.GetByID");

            DTEStatistics_OffShoreCenterDataModel dataModels = new DTEStatistics_OffShoreCenterDataModel();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataModels = CommonHelper.ConvertDataTable<DTEStatistics_OffShoreCenterDataModel>(dataSet.Tables[0]);
            }

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
            List<OffShoreCenter_OffShoreCenterDetails> EducationalQualificationDetails_StaffDetail_Item = JsonConvert.DeserializeObject<List<OffShoreCenter_OffShoreCenterDetails>>(JsonDataTable_Data);
            dataModels.OffShoreCenterDetails = EducationalQualificationDetails_StaffDetail_Item;

            return dataModels;
        }
        public bool SaveData(DTEStatistics_OffShoreCenterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string OffShoreCenterDetails_Str = request.OffShoreCenterDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.OffShoreCenterDetails, "Temp_DTEStatistics_OffShoreCenter_OffShoreCenterDetails") : "";

            string SqlQuery = " exec UPS_DTEStatistics_OffShoreCenter_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";

            SqlQuery += " @NumberOfOffShoreCenter='" + request.NumberOfOffShoreCenter + "', ";

            SqlQuery += " @OffShoreCenterDetails_Str='" + OffShoreCenterDetails_Str + "', ";

            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_OffShoreCenter.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
