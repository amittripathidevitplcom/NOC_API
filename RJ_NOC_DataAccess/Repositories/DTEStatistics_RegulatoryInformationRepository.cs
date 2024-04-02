using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_RegulatoryInformationRepository : IDTEStatistics_RegulatoryInformationRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_RegulatoryInformationRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_RegulatoryInformationDataModel GetByID(int CollegeID)
        {
            string SqlQuery = " exec UPS_DTEStatistics_RegulatoryInformation_GetByID @CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEStatistics_RegulatoryInformation.GetByID");

            DTEStatistics_RegulatoryInformationDataModel dataModels = new DTEStatistics_RegulatoryInformationDataModel();
            if (dataTable.Rows.Count > 0)
            {
                dataModels = CommonHelper.ConvertDataTable<DTEStatistics_RegulatoryInformationDataModel>(dataTable);
            }
            return dataModels;
        }
        public bool SaveData(DTEStatistics_RegulatoryInformationDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec UPS_DTEStatistics_RegulatoryInformation_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";

            SqlQuery += " @UniversityHasUploaded='" + request.UniversityHasUploaded + "', ";
            SqlQuery += " @UniversityIsComplying='" + request.UniversityIsComplying + "', ";
            SqlQuery += " @UniversityHadMinimum='" + request.UniversityHadMinimum + "', ";
            SqlQuery += " @UnderSection='" + request.UnderSection + "', ";
            SqlQuery += " @Date='" + request.Date + "', ";

            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_RegulatoryInformation.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
