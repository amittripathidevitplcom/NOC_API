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

namespace RJ_NOC_DataAccess.Repository
{
    public class MedicalDocumentScrutinyRepository : IMedicalDocumentScrutinyRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public MedicalDocumentScrutinyRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }


        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LandDetails @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<LandDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<LandDetailsDataModel>>(JsonDataTable_Data);
            dataModels.LandDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<MedicalDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_FacilityDetails @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<MedicalDocumentScrutinyDataModel_DocumentFacilityDetail> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentFacilityDetail>();
            MedicalDocumentScrutinyDataModel_DocumentFacilityDetail dataModels = new MedicalDocumentScrutinyDataModel_DocumentFacilityDetail();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<FacilityDetailsDataModel> FacilityDetailsDataModel_Item = JsonConvert.DeserializeObject<List<FacilityDetailsDataModel>>(JsonDataTable_Data);
            dataModels.FacilityDetails = FacilityDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<MedicalDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_RoomDetails @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<MedicalDocumentScrutinyDataModel_DocumentRoomDetails> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentRoomDetails>();
            MedicalDocumentScrutinyDataModel_DocumentRoomDetails dataModels = new MedicalDocumentScrutinyDataModel_DocumentRoomDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<RoomDetailsDataModel> RoomDetailsDataModel_Item = JsonConvert.DeserializeObject<List<RoomDetailsDataModel>>(JsonDataTable_Data);
            dataModels.RoomDetails = RoomDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<MedicalDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_BuildingDetails @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<MedicalDocumentScrutinyDataModel_DocumentBuildingDetails> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentBuildingDetails>();
            MedicalDocumentScrutinyDataModel_DocumentBuildingDetails dataModels = new MedicalDocumentScrutinyDataModel_DocumentBuildingDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<BuildingDetailsDataModel> BuildingDetailsDataModel_Item = JsonConvert.DeserializeObject<List<BuildingDetailsDataModel>>(JsonDataTable_Data);
            dataModels.BuildingDetails = BuildingDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<MedicalDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_StaffDetails @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<MedicalDocumentScrutinyDataModel_DocumentStaffDetails> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentStaffDetails>();
            MedicalDocumentScrutinyDataModel_DocumentStaffDetails dataModels = new MedicalDocumentScrutinyDataModel_DocumentStaffDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<StaffDetailDataModel> StaffDetailsDataModel_Item = JsonConvert.DeserializeObject<List<StaffDetailDataModel>>(JsonDataTable_Data);
            dataModels.StaffDetails = StaffDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<MedicalDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_OldNOCDetails @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<MedicalDocumentScrutinyDataModel_DocumentOldNOCDetails> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentOldNOCDetails>();
            MedicalDocumentScrutinyDataModel_DocumentOldNOCDetails dataModels = new MedicalDocumentScrutinyDataModel_DocumentOldNOCDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<OldNocDetailsDataModel> OldNOCDetailsDataModel_Item = JsonConvert.DeserializeObject<List<OldNocDetailsDataModel>>(JsonDataTable_Data);
            dataModels.OldNOCDetails = OldNOCDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
    }
}
