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

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            string SP_Name = Type == "Other Document" ? "USP_DocumentScrutiny_OtherDocument" : "USP_DocumentScrutiny_RequiredDocument";
            string SqlQuery = " exec " + SP_Name + " @DepartmentID=" + DepartmentID + ",@CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + ",@DocumentType='" + Type + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDocument();

            List<DataTable> CollegeDocumentDataModel_Item = new List<DataTable>();
            CollegeDocumentDataModel_Item.Add(dataSet.Tables[0]);
            dataModels.CollegeDocument = CollegeDocumentDataModel_Item;

            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;
            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_OtherInformation @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_OtherInformation");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<OtherInformationDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<OtherInformationDataModel>>(JsonDataTable_Data);
            dataModels.OtherInformations = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_HostelDetail @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_HostelDetail");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<HostelDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<HostelDataModel>>(JsonDataTable_Data);
            dataModels.HostelDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }


        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_HospitalDetail @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_HospitalDetail");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<HospitalMasterDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<HospitalMasterDataModel>>(JsonDataTable_Data);
            dataModels.HospitalDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_AcademicInformation @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_AcademicInformation");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<AcademicInformationDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<AcademicInformationDetailsDataModel>>(JsonDataTable_Data);
            dataModels.AcademicInformations = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeManagementSociety @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_CollegeManagementSociety");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<SocietyMasterDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<SocietyMasterDataModel>>(JsonDataTable_Data);
            dataModels.CollegeManagementSocietys = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(string SSOID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LegalEntity @SSOID='" + SSOID + "',@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_LegalEntity");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyLegalEntity();

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


        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeDetail @CollegeID=" + CollegeID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_CollegeDetail");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail();

            List<DataTable> CollegeDetailDataModel = new List<DataTable>();
            CollegeDetailDataModel.Add(dataSet.Tables[0]);
            dataModels.CollegeDetails= CollegeDetailDataModel;


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
        public List<CommonDataModel_DataTable> GetDocumentScrutinyReportCompleted(int UserID)
        {
            string SqlQuery = " exec USP_GetDocumentScrutinyCompletedReport @UserID ='" + UserID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "MedicalDoucmentMaster.GetDocumentScrutinyReportCompleted");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
