using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static iTextSharp.text.pdf.events.IndexEvents;


namespace RJ_NOC_DataAccess.Repository
{
    public class DTEStatistics_OfficersDetailsRepository : IDTEStatistics_OfficersDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DTEStatistics_OfficersDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public DTEStatistics_OfficersDetailsDataModel GetByID(int CollegeID)
        {
            string SqlQuery = " exec UPS_DTEStatistics_OfficersDetails_GetByID @CollegeID='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DTEStatistics_OfficersDetails.GetByID");

            DTEStatistics_OfficersDetailsDataModel dataModels = new DTEStatistics_OfficersDetailsDataModel();
            if (dataTable.Rows.Count > 0)
            {
                dataModels = CommonHelper.ConvertDataTable<DTEStatistics_OfficersDetailsDataModel>(dataTable);
            }
            return dataModels;
        }
        public bool SaveData(DTEStatistics_OfficersDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec UPS_DTEStatistics_OfficersDetails_IU";

            SqlQuery += " @EntryID='" + request.EntryID + "', ";
            SqlQuery += " @Department='" + request.Department + "', ";
            SqlQuery += " @CollegeID='" + request.CollegeID + "', ";
            SqlQuery += " @SelectedCollegeEntryTypeName='" + request.SelectedCollegeEntryTypeName + "', ";
            SqlQuery += " @FYearID='" + request.FYearID + "', ";
            SqlQuery += " @NameOfVice='" + request.NameOfVice + "', ";
            SqlQuery += " @DesignationID='" + request.DesignationID + "', ";
            SqlQuery += " @Email='" + request.Email + "', ";
            SqlQuery += " @MobileNo='" + request.MobileNo + "', ";
            SqlQuery += " @TelephoneNo='" + request.TelephoneNo + "', ";
            SqlQuery += " @NameOfNodal='" + request.NameOfNodal + "', ";
            SqlQuery += " @Nodal_DesignationID='" + request.Nodal_DesignationID + "', ";
            SqlQuery += " @Nodal_Email='" + request.Nodal_Email + "', ";
            SqlQuery += " @Nodal_MobileNo='" + request.Nodal_MobileNo + "', ";
            SqlQuery += " @Nodal_TelephoneNo='" + request.Nodal_TelephoneNo + "', ";
            SqlQuery += " @ModifyBy='" + request.ModifyBy + "', ";
            SqlQuery += " @IPAddress='" + IPAddress + "' ";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DTEStatistics_OfficersDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
