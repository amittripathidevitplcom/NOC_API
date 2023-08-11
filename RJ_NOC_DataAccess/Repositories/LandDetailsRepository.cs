using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RJ_NOC_Model;
using System.Threading.Tasks;
using RJ_NOC_DataAccess.Interface;
using System.Data.SqlClient;
using System.Data;
using RJ_NOC_DataAccess.Common;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Net;

namespace RJ_NOC_DataAccess.Repositories
{
    public class LandDetailsRepository : ILandDetailsRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public LandDetailsRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<CommonDataModel_DataSet> GetLandDetailsList(int SelectedCollageID, int LandDetailID)
        {
            string SqlQuery = " exec USP_LandDetails_GetData @SelectedCollageID='" + SelectedCollageID + "', @LandDetailID='" + LandDetailID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "LandDetails.GetLandDetailsList");

            List<CommonDataModel_DataSet> dataModels = new List<CommonDataModel_DataSet>();
            CommonDataModel_DataSet dataModel = new CommonDataModel_DataSet();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<LandDetailsDataModel> GetLandDetailsIDWise(int LandDetailID, int CollageID)
        {
            string SqlQuery = " exec USP_LandDetails_GetData @LandDetailID='" + LandDetailID + "',@SelectedCollageID='" + CollageID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");
            List<LandDetailsDataModel> listdataModels = new List<LandDetailsDataModel>();
            LandDetailsDataModel dataModels = new LandDetailsDataModel();
            if (LandDetailID == 0)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                listdataModels = JsonConvert.DeserializeObject<List<LandDetailsDataModel>>(JsonDataTable_Data);
            }
            else
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataModels.LandDetailID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LandDetailID"]);
                    dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
                    dataModels.CollegeName = dataSet.Tables[0].Rows[0]["CollegeName"].ToString();
                    dataModels.LandAreaID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LandAreaID"]);
                    dataModels.LandAreaSituatedName = dataSet.Tables[0].Rows[0]["LandAreaSituatedName"].ToString();
                    dataModels.LandDocumentTypeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LandDocumentTypeID"]);
                    dataModels.LandDocumentTypeName = dataSet.Tables[0].Rows[0]["LandDocumentTypeName"].ToString();
                    dataModels.LandConvertedID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LandConvertedID"]);
                    dataModels.LandTypeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LandTypeID"]);
                    dataModels.KhasraNumber = dataSet.Tables[0].Rows[0]["KhasraNumber"].ToString();
                    dataModels.LandArea = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LandArea"]);
                    dataModels.LandOwnerName = dataSet.Tables[0].Rows[0]["LandOwnerName"].ToString();
                    dataModels.BuildingHostelQuartersRoadArea = Convert.ToInt32(dataSet.Tables[0].Rows[0]["BuildingHostelQuartersRoadArea"]);
                    dataModels.LandConversionOrderDate = dataSet.Tables[0].Rows[0]["LandConversionOrderDate"].ToString();
                    dataModels.AffidavitDate = dataSet.Tables[0].Rows[0]["AffidavitDate"].ToString();
                    dataModels.LandConversionOrderNo = dataSet.Tables[0].Rows[0]["LandConversionOrderNo"].ToString();
                    dataModels.IsConvereted = dataSet.Tables[0].Rows[0]["IsConvereted"].ToString();
                    dataModels.ActiveStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ActiveStatus"]);
                    dataModels.DeleteStatus = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["DeleteStatus"]);
                    //Add by Deepak
                    dataModels.LandTypeName = dataSet.Tables[0].Rows[0]["LandTypeName"].ToString();
                    dataModels.Code = dataSet.Tables[0].Rows[0]["Code"].ToString();
                    dataModels.AreaType = dataSet.Tables[0].Rows[0]["AreaType"].ToString();
                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<CommonDataModel_BuildingUploadDoc> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<CommonDataModel_BuildingUploadDoc>>(JsonDataTable_Data);
                    dataModels.LandDetailDocument = LandDetailDataModel_Item;
                    listdataModels.Add(dataModels);
                }
            }
            return listdataModels;
        }

        //public List<LandDetailsDataModel> GetLandDetailsIDWise(int LandDetailID)
        //{
        //    string SqlQuery = " exec USP_LandDetails_GetData '" + LandDetailID + "'";
        //    DataTable dataTable = new DataTable();
        //    dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LandDetails.GetLandDetailsIDWise");

        //    List<LandDetailsDataModel> dataModels = new List<LandDetailsDataModel>();
        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
        //    dataModels = JsonConvert.DeserializeObject<List<LandDetailsDataModel>>(JsonDataTable_Data);
        //    return dataModels;

        //}
        public bool SaveData(LandDetailsDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SchoolLandInformation_Document_Str = CommonHelper.GetDetailsTableQry(request.LandDetailDocument, "Temp_SchoolLandInformation_Document");
            string SqlQuery = " exec USP_LandDetails_AddUpdate";

            SqlQuery += " @LandDetailID='" + request.LandDetailID + "',";
            SqlQuery += " @CollegeID='" + request.CollegeID + "',";
            SqlQuery += " @LandAreaID='" + request.LandAreaID + "',";
            SqlQuery += " @LandDocumentTypeID='" + request.LandDocumentTypeID + "',";
            SqlQuery += " @LandConvertedID='" + request.LandConvertedID + "',";
            SqlQuery += " @LandTypeID='" + request.LandTypeID + "',";
            SqlQuery += " @KhasraNumber='" + request.KhasraNumber + "',";
            SqlQuery += " @LandOwnerName='" + request.LandOwnerName + "',";
            SqlQuery += " @LandArea='" + request.LandArea + "',";
            SqlQuery += " @BuildingHostelQuartersRoadArea='" + request.BuildingHostelQuartersRoadArea + "',";
            SqlQuery += " @LandConversionOrderDate='" + request.LandConversionOrderDate + "',";
            SqlQuery += " @AffidavitDate='" + request.AffidavitDate + "',";
            SqlQuery += " @LandConversionOrderNo='" + request.LandConversionOrderNo + "',";
            SqlQuery += " @IsConvereted='" + request.IsConvereted + "',";
            SqlQuery += " @ActiveStatus='" + request.ActiveStatus + "',";
            SqlQuery += " @IPAddress='" + IPAddress + "',";
            SqlQuery += " @SchoolLandInformation_Document_Str='" + SchoolLandInformation_Document_Str + "'";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "LandDetails.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int LandDetailID)
        {
            string SqlQuery = " Update Trn_CollegeLandInformation set ActiveStatus=0 , DeleteStatus=1  WHERE LandDetailID='" + LandDetailID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "LandDetails.Delete");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(int LandDetailID, int LandAreaID, int CollegeID)
        {
            string SqlQuery = " select LandDetailID from Trn_CollegeLandInformation Where CollegeID='" + CollegeID + "'  and LandAreaID ='" + LandAreaID + "' and LandDetailID !='" + LandDetailID + "' and DeleteStatus=0";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "LandDetails.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}

