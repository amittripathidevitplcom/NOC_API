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
using System.Reflection.Metadata;

namespace RJ_NOC_DataAccess.Repository
{
    public class MGOneDocumentScrutinyRepository : IMGOneDocumentScrutinyRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public MGOneDocumentScrutinyRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }


        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LandDetails_MGOne @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_LandDetails");

            List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails> listdataModels = new List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails>();
            MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails dataModels = new MGOneDocumentScrutinyDataModel_DocumentScrutinyLandDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<LandDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<LandDetailsDataModel>>(JsonDataTable_Data);
            dataModels.LandDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<MGOneDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_BuildingDetails_MGOne @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_BuildingDetails");

            List<MGOneDocumentScrutinyDataModel_DocumentBuildingDetails> listdataModels = new List<MGOneDocumentScrutinyDataModel_DocumentBuildingDetails>();
            MGOneDocumentScrutinyDataModel_DocumentBuildingDetails dataModels = new MGOneDocumentScrutinyDataModel_DocumentBuildingDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<BuildingDetailsDataModel> BuildingDetailsDataModel_Item = JsonConvert.DeserializeObject<List<BuildingDetailsDataModel>>(JsonDataTable_Data);
            dataModels.BuildingDetails = BuildingDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            string SP_Name = Type == "Other Document" ? "USP_DocumentScrutiny_OtherDocument_DCE" : "USP_DocumentScrutiny_RequiredDocument_MGOne";
            string SqlQuery = " exec " + SP_Name + " @DepartmentID=" + DepartmentID + ",@CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + ",@DocumentType='" + Type + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument");

            List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> listdataModels = new List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>();
            MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument dataModels = new MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument();

            List<DataTable> CollegeDocumentDataModel_Item = new List<DataTable>();
            CollegeDocumentDataModel_Item.Add(dataSet.Tables[0]);
            dataModels.CollegeDocument = CollegeDocumentDataModel_Item;

            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;
            listdataModels.Add(dataModels);

            return listdataModels;
        }


        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_HospitalDetail_MGOne @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_HospitalDetail");

            List<MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> listdataModels = new List<MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail>();
            MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail dataModels = new MGOneDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<HospitalMasterDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<HospitalMasterDataModel>>(JsonDataTable_Data);
            dataModels.HospitalDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }


        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeManagementSociety_MGOne @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_CollegeManagementSociety");

            List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> listdataModels = new List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>();
            MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety dataModels = new MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<SocietyMasterDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<SocietyMasterDataModel>>(JsonDataTable_Data);
            dataModels.CollegeManagementSocietys = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LegalEntity_MGOne @CollegeID='" + CollegeID + "',@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_LegalEntity");

            List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> listdataModels = new List<MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>();
            MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity dataModels = new MGOneDocumentScrutinyDataModel_DocumentScrutinyLegalEntity();

            if (dataSet != null)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                    List<LegalEntityModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<LegalEntityModel>>(JsonDataTable_Data);
                    dataModels.legalEntity = LandDetailDataModel_Item.FirstOrDefault();

                    if (dataSet.Tables[1].Rows.Count > 0)
                    {
                        string JsonDataTable_Member = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                        List<LegalEntityMemberDetailsDataModel> LandDetailDataModel_Member = JsonConvert.DeserializeObject<List<LegalEntityMemberDetailsDataModel>>(JsonDataTable_Member);
                        dataModels.legalEntity.MemberDetails = LandDetailDataModel_Member;
                    }
                    if (dataSet.Tables[2].Rows.Count > 0)
                    {
                        string JsonDataTable_Institute = CommonHelper.ConvertDataTable(dataSet.Tables[2]);
                        List<LegalEntityInstituteDetailsDataModel> LandDetailDataModel_Institute = JsonConvert.DeserializeObject<List<LegalEntityInstituteDetailsDataModel>>(JsonDataTable_Institute);
                        dataModels.legalEntity.InstituteDetails = LandDetailDataModel_Institute;
                    }
                }
                if (dataSet.Tables[3].Rows.Count > 0)
                {
                    List<DataTable> dataModel = new List<DataTable>();
                    dataModel.Add(dataSet.Tables[3]);
                    dataModels.DocumentScrutinyFinalRemarkList = dataModel;
                }


                listdataModels.Add(dataModels);
            }

            return listdataModels;
        }


        public List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeDetail_DCE @CollegeID=" + CollegeID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_CollegeDetail");

            List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> listdataModels = new List<MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>();
            MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail dataModels = new MGOneDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail();

            List<DataTable> CollegeDetailDataModel = new List<DataTable>();
            CollegeDetailDataModel.Add(dataSet.Tables[0]);
            dataModels.CollegeDetails = CollegeDetailDataModel;


            List<DataTable> CollegeContactDetailDataModel = new List<DataTable>();
            CollegeContactDetailDataModel.Add(dataSet.Tables[1]);
            dataModels.CollegeContactDetails = CollegeContactDetailDataModel;

            List<DataTable> CollegeNearestDetailDataModel = new List<DataTable>();
            CollegeNearestDetailDataModel.Add(dataSet.Tables[2]);
            dataModels.CollegeNearestHospitalsDetails = CollegeNearestDetailDataModel;

            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[3]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID,int CollegeID)
        {
            string SqlQuery = " exec USP_CheckDocumentScrutinyTabsData @ApplyNOCID ='" + ApplyNOCID + "',@RoleID ='" + RoleID + "',@CollegeID ='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "MedicalDoucmentMaster.CheckDocumentScrutinyTabsData");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }


        //Get Nodal Officer Application
        public List<LOIApplicationDetails_DataModel> GetLOIApplicationList(int RoleID, int UserID, string Status, string ActionName)
        {
            string SqlQuery = " exec USP_GetLOIApplicationList @RoleID='" + RoleID + "',@UserID='" + UserID + "',@Status='" + Status + "',@ActionName='" + ActionName + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "ApplyNOC.GetLOIApplicationList");
            List<LOIApplicationDetails_DataModel> listdataModels = new List<LOIApplicationDetails_DataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            listdataModels = JsonConvert.DeserializeObject<List<LOIApplicationDetails_DataModel>>(JsonDataTable_Data);
            return listdataModels;
        }

        public DataSet GeneratePDF_MedicalGroupLOICData(int LOIFinalSubmitID)
        {
            string SqlQuery = "exec USP_GeneratePDF_MedicalGroupLOIC @LOIFinalSubmitID='"+ LOIFinalSubmitID + "'";
            DataSet dataset = new DataSet();
            dataset = _commonHelper.Fill_DataSet(SqlQuery, "MGOneDocumentScrutinyRepository.GeneratePDF_MedicalGroupLOICData");
            return dataset;
        }

        public List<DataTable> MedicalGroupLOIIssuedReport(int LoginUserID, int RoleID)
        {
            string SqlQuery = " exec USP_MedicalGroupLOICIssuedReport @LoginUserID ='"+ LoginUserID + "',@RoleID='"+ RoleID + "' ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "MGOneDocumentScrutinyRepository.MedicalGroupLOIIssuedReport");

             
            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;


        }
    }
}
