using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using static RJ_NOC_Model.BuildingDetailsDataModel;

namespace RJ_NOC_DataAccess.Repository
{
    public class BuildingDetailsMasterRepository : IBuildingDetailsMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public BuildingDetailsMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }         
       
        public bool SaveData(BuildingDetailsDataModel buildingdetails)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string BuildingDetail_Document_Str = CommonHelper.GetDetailsTableQry(buildingdetails.lstBuildingDocDetails, "Temp_School_BuildingDetails_Document");
            string SqlQuery = " exec USP_Trn_School_BuildingDetails_IU";

            SqlQuery += " @CollegeID='" + buildingdetails.CollegeID + "',";
            SqlQuery += " @SchoolBuildingDetailsID='" + buildingdetails.SchoolBuildingDetailsID + "',";
            SqlQuery += " @BuildingTypeID='" + buildingdetails.BuildingTypeID + "',";
            SqlQuery += " @OwnerName='" + buildingdetails.OwnerName + "',";
            SqlQuery += " @AddressLine1='" + buildingdetails.AddressLine1 + "',";
            SqlQuery += " @AddressLine2='" + buildingdetails.AddressLine2 + "',";
            SqlQuery += " @RuralUrban='" + buildingdetails.RuralUrban + "',";
            SqlQuery += " @DivisionID='" + buildingdetails.DivisionID + "',";
            SqlQuery += " @DistrictID='" + buildingdetails.DistrictID + "',";
            SqlQuery += " @TehsilID='" + buildingdetails.TehsilID + "',";
            SqlQuery += " @PanchayatSamitiID='" + buildingdetails.PanchayatSamitiID + "',";
            SqlQuery += " @CityTownVillage='" + buildingdetails.CityTownVillage + "',";
            SqlQuery += " @Pincode='" + buildingdetails.Pincode + "',";
            SqlQuery += " @BuildingHostelQuartersRoadArea='" + buildingdetails.BuildingHostelQuartersRoadArea + "',";
            SqlQuery += " @OwnBuildingOrderNo='" + buildingdetails.OwnBuildingOrderNo + "',";
            SqlQuery += " @OwnBuildingOrderDate='" + buildingdetails.OwnBuildingOrderDate + "',";
            SqlQuery += " @OwnBuildingFileUpload='" + buildingdetails.OwnBuildingFileUpload + "',";
            SqlQuery += " @RentAgreementFileUpload='" + buildingdetails.RentAgreementFileUpload + "',";
            SqlQuery += " @FromDate='" + buildingdetails.FromDate + "',";
            SqlQuery += " @ToDate='" + buildingdetails.ToDate + "',";
            SqlQuery += " @FireNOCFileUpload='" + buildingdetails.FireNOCFileUpload + "',";
            SqlQuery += " @OrderNo='" + buildingdetails.OrderNo + "',";
            SqlQuery += " @OrderDate='" + buildingdetails.OrderDate + "',";
            SqlQuery += " @ExpiringOn='" + buildingdetails.ExpiringOn + "',";
            SqlQuery += " @PWDNOCFileUpload='" + buildingdetails.PWDNOCFileUpload + "',";

            SqlQuery += " @TotalProjectCost='" + buildingdetails.TotalProjectCost + "',";
            SqlQuery += " @TotalProjectCostFileUpload='" + buildingdetails.TotalProjectCostFileUpload + "',";
            SqlQuery += " @SourceCostAmount='" + buildingdetails.SourceCostAmount + "',";
            SqlQuery += " @SourceCostAmountFileUpload='" + buildingdetails.SourceCostAmountFileUpload + "',";
            SqlQuery += " @AmountDeposited='" + buildingdetails.AmountDeposited + "',";
            SqlQuery += " @AmountDepositedFileUpload='" + buildingdetails.AmountDepositedFileUpload + "',";
            SqlQuery += " @OtherFixedAssetsAndSecurities='" + buildingdetails.OtherFixedAssetsAndSecurities + "',";
            SqlQuery += " @OtherFixedAssetsAndSecuritiesFileUpload='" + buildingdetails.OtherFixedAssetsAndSecuritiesFileUpload + "',";
            SqlQuery += " @GATEYearBalanceSecret='" + buildingdetails.GATEYearBalanceSecret + "',";
            SqlQuery += " @GATEYearBalanceSecretFileUpload='" + buildingdetails.GATEYearBalanceSecretFileUpload + "',";
            SqlQuery += " @OtherFinancialResources='" + buildingdetails.OtherFinancialResources + "',";
            SqlQuery += " @OtherFinancialResourcesFileUpload='" + buildingdetails.OtherFinancialResourcesFileUpload + "',";

            SqlQuery += " @ContactNo='" + buildingdetails.ContactNo + "',";
            SqlQuery += " @UserID='" + buildingdetails.UserID + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @Rentvaliditydate='" + buildingdetails.Rentvaliditydate + "',";
            SqlQuery += " @BuildingDetail_Document_Str='" + BuildingDetail_Document_Str + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "BuildingDetailsMasterService.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<BuildingDetailsDataModelList> GetAllBuildingDetailsList(int CollegeID)
        {
            string SqlQuery = $" exec USP_Trn_School_BuildingDetails_GetData @CollegeID={CollegeID}";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "BuildingDetailsMasterService.GetAllBuildingDetailsList");

            List<BuildingDetailsDataModelList> dataModels = new List<BuildingDetailsDataModelList>();
            BuildingDetailsDataModelList dataModel = new BuildingDetailsDataModelList();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;



        }
        public List<BuildingDetailsDataModelList> GetBuildingDetailsIDWise(int SchoolBuildingDetailsID)
        {
            string SqlQuery = " exec USP_Trn_School_BuildingDetails_GetData @SchoolBuildingDetailsID='" + SchoolBuildingDetailsID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "BuildingDetailsMasterService.GetBuildingDetailsIDWise");

            List<BuildingDetailsDataModelList> dataModels = new List<BuildingDetailsDataModelList>();
            BuildingDetailsDataModelList dataModel = new BuildingDetailsDataModelList();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }

        //public List<BuildingDetailsDataModel> GetBuildingDetailsIDWise(int SchoolBuildingDetailsID)
        //{
        //    string SqlQuery = " exec USP_Trn_School_BuildingDetails_GetData @SchoolBuildingDetailsID='" + SchoolBuildingDetailsID + "'";
        //    DataSet dataSet = new DataSet();
        //    dataSet = _commonHelper.Fill_DataSet(SqlQuery, "BuildingDetailsMasterService.GetBuildingDetailsIDWise");

        //    List<BuildingDetailsDataModel> dataModels = new List<BuildingDetailsDataModel>();
        //    string JsonDataTable_Data = CommonHelper.conver(dataSet);
        //    dataModels = JsonConvert.DeserializeObject<List<BuildingDetailsDataModel>>(JsonDataTable_Data);
        //    return dataModels;
        //}
        public bool DeleteData(int SchoolBuildingDetailsID)
        {
            string SqlQuery = " Update Trn_School_BuildingDetails set ActiveStatus=0 , DeleteStatus=1  WHERE SchoolBuildingDetailsID='" + SchoolBuildingDetailsID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "BuildingDetailsMasterService.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool StatusUpdate(int SchoolBuildingDetailsID, bool ActiveStatus)
        {
            ActiveStatus = (ActiveStatus == false ? true : (ActiveStatus == true ? false : ActiveStatus));
            string SqlQuery = " exec USP_GetUpdateStatusMBuildingDetails";
            SqlQuery += " @SchoolBuildingDetailsID='" + SchoolBuildingDetailsID + "',@ActiveStatus='" + ActiveStatus + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "BuildingDetailsMasterService.StatusUpdate");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int SchoolBuildingDetailsID, string OwnerName)
        {
            string SqlQuery = " select OwnerName from Trn_School_BuildingDetails Where OwnerName='" + OwnerName.Trim() + "'  and SchoolBuildingDetailsID !='" + SchoolBuildingDetailsID + "'  and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "BuildingDetailsMasterService.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
      
    }
}
