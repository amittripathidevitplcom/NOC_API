using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_DataAccess.Repositories
{
    public class HostelDetailRepository : IHostelDetailRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public HostelDetailRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public bool IfExists(int HostelDetailID, int CollegeID, string HostelName)
        {
            string SqlQuery = " USP_IfExistsHostelDetail @HostelName='" + HostelName + "',@CollegeID='" + CollegeID + "',@HostelDetailID='" + HostelDetailID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HostelDetail.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool SaveData(HostelDataModel request)
        {
            string ipAddress = CommonHelper.GetVisitorIPAddress();
            string HostelDetail_Str = request.HostelDetails.Count > 0 ? CommonHelper.GetDetailsTableQry(request.HostelDetails, "Temp_HostelDetail_Hostel") : "";
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_SaveHostelDetail_IU  ";
            SqlQuery += "@HostelTypeID='"+request.HostelTypeID+ "',@HostelCategoryID='" + request.HostelCategoryID + "',@HostelDetailID = '"+request.HostelDetailID+"',@IsHostelCampus = '"+request.IsHostelCampus+ "',@IsHostel = '"+request.IsHostel+"',@HostelName = '" + request.HostelName+"',@AddressLine1 = '"+request.AddressLine1+"',@AddressLine2 = '"+request.AddressLine2+"',@IsRuralUrban = '"+request.IsRuralUrban+"',@DivisionId = '"+request.DivisionID+"',@DistrictID = '"+request.DistrictID+"',@TehsilID = '"+request.TehsilID+"',@PanchayatSamitiID = '"+request.PanchayatSamitiID+"',";
            SqlQuery += "@CityTownVillage='" + request.CityTownVillage + "',@Pincode='" + request.Pincode + "',@ContactPersonName='" + request.ContactPersonName + "',@ContactPersonNo='" + request.ContactPersonNo + "',";
            SqlQuery += "@DistanceOfCollege='" + request.DistanceOfCollege + "',@HostelType='" + request.HostelType + "',@OwnerName='" + request.OwnerName + "',@OwnerContactNo='" + request.OwnerContactNo + "',@FromDate='" + request.FromDate + "',@ToDate='" + request.ToDate + "',@RentDocument='" + request.RentDocument + "',@DepartmentID='" + request.DepartmentID + "',@IPAddress ='" + ipAddress + "',@CollegeID='" + request.CollegeID + "',@Furnished='" + request.Furnished + "',@Toilet='" + request.Toilet + "',@Mess='" + request.Mess + "',@Hygiene='" + request.Hygiene + "',@Commonroom='" + request.Commonroom + "',@Visitor='" + request.Visitor + "',@OwnerShhipRentDocument='" + request.OwnerShhipRentDocument + "',";
            SqlQuery += "@HostelDetail_Str='" + HostelDetail_Str + "',@CityID='" + request.CityID + "',@BuiltUpArea='" + request.BuiltUpArea + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "HostelDetail.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<HostelDataModel> GetHostelDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int HostelDetailID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_GetHostelDetailList_DepartmentCollegeWise @HostelDetailID='" + HostelDetailID + "',@DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "StaffDetail.GetStaffDetailList_DepartmentCollegeWise");
            List<HostelDataModel> listdataModels = new List<HostelDataModel>();
            HostelDataModel dataModels = new HostelDataModel();
            if (HostelDetailID == 0)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                listdataModels = JsonConvert.DeserializeObject<List<HostelDataModel>>(JsonDataTable_Data);
            }
            else
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataModels.HostelTypeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["HostelTypeID"]);
                    dataModels.HostelCategoryID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["HostelCategoryID"]);
                    dataModels.HostelDetailID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["HostelDetailID"]);
                    dataModels.IsHostel = dataSet.Tables[0].Rows[0]["IsHostel"].ToString();
                    dataModels.IsHostelCampus = dataSet.Tables[0].Rows[0]["IsHostelCampus"].ToString();
                    dataModels.HostelName = dataSet.Tables[0].Rows[0]["HostelName"].ToString();
                    dataModels.AddressLine1 = dataSet.Tables[0].Rows[0]["AddressLine1"].ToString();
                    dataModels.AddressLine2 = dataSet.Tables[0].Rows[0]["AddressLine2"].ToString();
                    dataModels.IsRuralUrban = dataSet.Tables[0].Rows[0]["IsRuralUrban"].ToString();
                    dataModels.DivisionID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DivisionID"]);
                    dataModels.DistrictID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DistrictID"]);
                    dataModels.TehsilID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["TehsilID"]);
                    dataModels.CityID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CityID"]);
                    dataModels.PanchayatSamitiID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PanchayatSamitiID"]);

                    dataModels.CityTownVillage = dataSet.Tables[0].Rows[0]["CityTownVillage"].ToString();
                    dataModels.Pincode = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Pincode"]);
                    dataModels.ContactPersonName = dataSet.Tables[0].Rows[0]["ContactPersonName"].ToString();
                    dataModels.ContactPersonNo = dataSet.Tables[0].Rows[0]["ContactPersonNo"].ToString();
                    dataModels.DistanceOfCollege = dataSet.Tables[0].Rows[0]["DistanceOfCollege"].ToString();
                    dataModels.HostelType = dataSet.Tables[0].Rows[0]["HostelType"].ToString();
                    dataModels.OwnerName = dataSet.Tables[0].Rows[0]["OwnerName"].ToString();
                    dataModels.OwnerContactNo = dataSet.Tables[0].Rows[0]["OwnerContactNo"].ToString();
                    dataModels.FromDate = dataSet.Tables[0].Rows[0]["FromDate"].ToString();
                    dataModels.ToDate = dataSet.Tables[0].Rows[0]["ToDate"].ToString();
                    dataModels.RentDocument = dataSet.Tables[0].Rows[0]["RentDocument"].ToString();
                    dataModels.RentDocumentPath = dataSet.Tables[0].Rows[0]["RentDocumentPath"].ToString();
                    dataModels.RentDocument_Dis_FileName = dataSet.Tables[0].Rows[0]["RentDocument_Dis_FileName"].ToString();

                    dataModels.OwnerShhipRentDocument = dataSet.Tables[0].Rows[0]["OwnerShhipRentDocument"].ToString();
                    dataModels.OwnerShhipRentDocumentPath = dataSet.Tables[0].Rows[0]["OwnerShhipRentDocumentPath"].ToString();
                    dataModels.OwnerShhipRentDocument_Dis_FileName = dataSet.Tables[0].Rows[0]["OwnerShhipRentDocument_Dis_FileName"].ToString();

                    dataModels.DepartmentID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DepartmentID"]);
                    dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);

                    dataModels.DivisionName = dataSet.Tables[0].Rows[0]["DivisionName"].ToString();
                    dataModels.DistrictName = dataSet.Tables[0].Rows[0]["DistrictName"].ToString();
                    dataModels.TehsilName = dataSet.Tables[0].Rows[0]["TehsilName"].ToString();
                    dataModels.CityName = dataSet.Tables[0].Rows[0]["CityName"].ToString();
                    dataModels.PanchyatSamitiName = dataSet.Tables[0].Rows[0]["PanchyatSamitiName"].ToString();
                    dataModels.HostelCategory = dataSet.Tables[0].Rows[0]["HostelCategory"].ToString();
                    dataModels.HostelCategoryType = dataSet.Tables[0].Rows[0]["HostelCategoryType"].ToString();
                    dataModels.BuiltUpArea = dataSet.Tables[0].Rows[0]["BuiltUpArea"].ToString();
                    dataModels.Furnished = dataSet.Tables[0].Rows[0]["Furnished"].ToString();
                    dataModels.Toilet = dataSet.Tables[0].Rows[0]["Toilet"].ToString();
                    dataModels.Mess = dataSet.Tables[0].Rows[0]["Mess"].ToString();
                    dataModels.Hygiene = dataSet.Tables[0].Rows[0]["Hygiene"].ToString();
                    dataModels.Commonroom = dataSet.Tables[0].Rows[0]["Commonroom"].ToString();
                    dataModels.Visitor = dataSet.Tables[0].Rows[0]["Visitor"].ToString();

                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<HostelDetailsDataModel_Hostel> HostelDetailsDataModel_Hostel_Item = JsonConvert.DeserializeObject<List<HostelDetailsDataModel_Hostel>>(JsonDataTable_Data);
                    dataModels.HostelDetails = HostelDetailsDataModel_Hostel_Item;
                    listdataModels.Add(dataModels);
                }
            }
            return listdataModels;
        }

        public bool DeleteHostelDetail(int HostelDetailID)
        {
            string SqlQuery = "exec USP_DeleteHostelDetail @HostelDetailID='" + HostelDetailID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "HostelDetail.DeleteHostelDetail");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<CommonDataModel_DataSet> GetHostelPdfDetails(int DepartmentID, int CollageID)
        {
            string SqlQuery = " exec USP_GetHostelDetailList_ForPDf @DepartmentID='" + DepartmentID + "',@CollegeID='" + CollageID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "HostelDetail.GetHostelPdfDetails");

            List<CommonDataModel_DataSet> dataModels = new List<CommonDataModel_DataSet>();
            CommonDataModel_DataSet dataModel = new CommonDataModel_DataSet();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
