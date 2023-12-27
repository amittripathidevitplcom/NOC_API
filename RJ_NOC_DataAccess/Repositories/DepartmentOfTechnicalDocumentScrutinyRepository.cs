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
    public class DepartmentOfTechnicalDocumentScrutinyRepository : IDepartmentOfTechnicalDocumentScrutinyRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DepartmentOfTechnicalDocumentScrutinyRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }


        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LandDetails_DCE @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_LandDetails");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLandDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<LandDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<LandDetailsDataModel>>(JsonDataTable_Data);
            dataModels.LandDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_FacilityDetails_DTE @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_FacilityDetail");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentFacilityDetail();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<FacilityDetailsDataModel> FacilityDetailsDataModel_Item = JsonConvert.DeserializeObject<List<FacilityDetailsDataModel>>(JsonDataTable_Data);
            dataModels.FacilityDetails = FacilityDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_RoomDetails_DCE @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_RoomDetail");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentRoomDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<RoomDetailsDataModel> RoomDetailsDataModel_Item = JsonConvert.DeserializeObject<List<RoomDetailsDataModel>>(JsonDataTable_Data);
            dataModels.RoomDetails = RoomDetailsDataModel_Item;

            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;

            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_BuildingDetails_DCE @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_BuildingDetails");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentBuildingDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<BuildingDetailsDataModel> BuildingDetailsDataModel_Item = JsonConvert.DeserializeObject<List<BuildingDetailsDataModel>>(JsonDataTable_Data);
            dataModels.BuildingDetails = BuildingDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_StaffDetails_DTE @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_StaffDetails");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentStaffDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<StaffDetailDataModel> StaffDetailsDataModel_Item = JsonConvert.DeserializeObject<List<StaffDetailDataModel>>(JsonDataTable_Data);
            dataModels.StaffDetails = StaffDetailsDataModel_Item;

            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;

            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_OldNOCDetails_DCE @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_OldNOCDetails");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentOldNOCDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<OldNocDetailsDataModel> OldNOCDetailsDataModel_Item = JsonConvert.DeserializeObject<List<OldNocDetailsDataModel>>(JsonDataTable_Data);
            dataModels.OldNOCDetails = OldNOCDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            string SP_Name = Type == "Other Document" ? "USP_DocumentScrutiny_OtherDocument_DTE" : "USP_DocumentScrutiny_RequiredDocument_DCE";
            string SqlQuery = " exec " + SP_Name + " @DepartmentID=" + DepartmentID + ",@CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + ",@DocumentType='" + Type + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument();

            List<DataTable> CollegeDocumentDataModel_Item = new List<DataTable>();
            CollegeDocumentDataModel_Item.Add(dataSet.Tables[0]);
            dataModels.CollegeDocument = CollegeDocumentDataModel_Item;

            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;
            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_OtherInformation_DTE @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_OtherInformation");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<OtherInformationDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<OtherInformationDataModel>>(JsonDataTable_Data);
            dataModels.OtherInformations = LandDetailDataModel_Item;
            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;
            listdataModels.Add(dataModels);
            return listdataModels;
        }

        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_HostelDetail_DTE @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_HostelDetail");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<HostelDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<HostelDataModel>>(JsonDataTable_Data);
            dataModels.HostelDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_AcademicInformation_DTE @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_AcademicInformation");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<AcademicInformationDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<AcademicInformationDetailsDataModel>>(JsonDataTable_Data);
            dataModels.AcademicInformations = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeManagementSociety_DCE @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_CollegeManagementSociety");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<SocietyMasterDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<SocietyMasterDataModel>>(JsonDataTable_Data);
            dataModels.CollegeManagementSocietys = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LegalEntity_DTE @CollegeID='" + CollegeID + "',@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DTEDocumentScrutiny.DocumentScrutiny_LegalEntity");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity();

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


        public List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeDetail_DCE @CollegeID=" + CollegeID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "DCEDocumentScrutiny.DocumentScrutiny_CollegeDetail");

            List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> listdataModels = new List<DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>();
            DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail dataModels = new DepartmentOfTechnicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail();

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
    }
}
