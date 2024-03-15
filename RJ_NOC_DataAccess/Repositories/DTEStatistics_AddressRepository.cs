using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;
using System.Diagnostics.Metrics;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_AddressRepository : IDTEStatistics_AddressRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_AddressRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_AddressDataModel GetByID(int CollegeID)
        {
            string SqlQuery = " exec UPS_DTEStatistics_Address_GetByID @CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEStatistics_Address.GetByID");

            DTEStatistics_AddressDataModel dataModels = new DTEStatistics_AddressDataModel();
            if (dataTable.Rows.Count > 0)
            {
                dataModels = CommonHelper.ConvertDataTable<DTEStatistics_AddressDataModel>(dataTable);
            }
            return dataModels;
        }
        public bool SaveData(DTEStatistics_AddressDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec UPS_DTEStatistics_Address_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";

            SqlQuery += " @Country='" + request.Country + "', ";
            SqlQuery += " @State='" + request.State + "', ";
            SqlQuery += " @DistrictID='" + request.DistrictID + "', ";
            SqlQuery += " @RuralUrban='" + request.RuralUrban + "', ";
            SqlQuery += " @TehsilID='" + request.TehsilID + "', ";
            SqlQuery += " @CityID='" + request.CityID + "', ";
            SqlQuery += " @PinCode='" + request.PinCode + "', ";
            SqlQuery += " @AddressLine1='" + request.AddressLine1 + "', ";
            SqlQuery += " @AddressLine2='" + request.AddressLine2 + "', ";
            SqlQuery += " @Longitude='" + request.Longitude + "', ";
            SqlQuery += " @Latitude='" + request.Latitude + "', ";
            SqlQuery += " @TotalArea='" + request.TotalArea + "', ";
            SqlQuery += " @TotalConstructedArea='" + request.TotalConstructedArea + "', ";
            SqlQuery += " @Website='" + request.Website + "', ";

            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_Address.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
