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
    public class AnimalDocumentScrutinyRepository : IAnimalDocumentScrutinyRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public AnimalDocumentScrutinyRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LegalEntity_AH @CollegeID='" + CollegeID + "',@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_LegalEntity");

            List<AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity> listdataModels = new List<AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity>();
            AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity dataModels = new AnimalDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity();

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

        public int CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID)
        {
            int Result = 0;
            string SqlQuery = " exec USP_CheckDocumentScrutinyTabsData @ApplyNOCID ='" + ApplyNOCID + "',@RoleID ='" + RoleID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "MedicalDoucmentMaster.CheckDocumentScrutinyTabsData");
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Result = Convert.ToInt32(dataTable.Rows[0]["TotalTabCount"].ToString());
            }
            return Result;
        }


        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LandDetails_AH @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails>();
            AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails dataModels = new AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<LandDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<LandDetailsDataModel>>(JsonDataTable_Data);
            dataModels.LandDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_FacilityDetails_AH @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<AnimalDocumentScrutinyDataModel_DocumentFacilityDetail> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentFacilityDetail>();
            AnimalDocumentScrutinyDataModel_DocumentFacilityDetail dataModels = new AnimalDocumentScrutinyDataModel_DocumentFacilityDetail();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<FacilityDetailsDataModel> FacilityDetailsDataModel_Item = JsonConvert.DeserializeObject<List<FacilityDetailsDataModel>>(JsonDataTable_Data);
            dataModels.FacilityDetails = FacilityDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_RoomDetails_AH @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<AnimalDocumentScrutinyDataModel_DocumentRoomDetails> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentRoomDetails>();
            AnimalDocumentScrutinyDataModel_DocumentRoomDetails dataModels = new AnimalDocumentScrutinyDataModel_DocumentRoomDetails();
            //List<DataTable> RoomDetailsDataModel_Item = new List<DataTable>();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<RoomDetailsDataModel> BuildingDetailsDataModel_Item = JsonConvert.DeserializeObject<List<RoomDetailsDataModel>>(JsonDataTable_Data);
            dataModels.RoomDetails = BuildingDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;

            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_BuildingDetails_AH @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<AnimalDocumentScrutinyDataModel_DocumentBuildingDetails> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentBuildingDetails>();
            AnimalDocumentScrutinyDataModel_DocumentBuildingDetails dataModels = new AnimalDocumentScrutinyDataModel_DocumentBuildingDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<BuildingDetailsDataModel> BuildingDetailsDataModel_Item = JsonConvert.DeserializeObject<List<BuildingDetailsDataModel>>(JsonDataTable_Data);
            dataModels.BuildingDetails = BuildingDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_StaffDetails_AH @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<AnimalDocumentScrutinyDataModel_DocumentStaffDetails> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentStaffDetails>();
            AnimalDocumentScrutinyDataModel_DocumentStaffDetails dataModels = new AnimalDocumentScrutinyDataModel_DocumentStaffDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<StaffDetailDataModel> StaffDetailsDataModel_Item = JsonConvert.DeserializeObject<List<StaffDetailDataModel>>(JsonDataTable_Data);
            dataModels.StaffDetails = StaffDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_OldNOCDetails_AH @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "WorkFlowMaster.GetWorkFlowMasterList");

            List<AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails>();
            AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails dataModels = new AnimalDocumentScrutinyDataModel_DocumentOldNOCDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<OldNocDetailsDataModel> OldNOCDetailsDataModel_Item = JsonConvert.DeserializeObject<List<OldNocDetailsDataModel>>(JsonDataTable_Data);
            dataModels.OldNOCDetails = OldNOCDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<AnimalDocuemntScrutinyCommonModel> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            string SP_Name = Type == "Other Document" ? "USP_DocumentScrutiny_OtherDocument_AH" : "USP_DocumentScrutiny_RequiredDocument_AH";
            string SqlQuery = " exec " + SP_Name + " @DepartmentID=" + DepartmentID + ",@CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + ",@DocumentType='" + Type + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument");

            List<AnimalDocuemntScrutinyCommonModel> listdataModels = new List<AnimalDocuemntScrutinyCommonModel>();
            AnimalDocuemntScrutinyCommonModel dataModels = new AnimalDocuemntScrutinyCommonModel();

            List<DataTable> CollegeDocumentDataModel_Item = new List<DataTable>();
            CollegeDocumentDataModel_Item.Add(dataSet.Tables[0]);
            dataModels.lstDatatable = CollegeDocumentDataModel_Item;

            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.lstFinalRemarkList = dataModel;
            listdataModels.Add(dataModels);

            return listdataModels;
        }

        //public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        //{
        //    string SqlQuery = " exec USP_DocumentScrutiny_OtherInformation @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
        //    DataSet dataSet = new DataSet();
        //    dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_OtherInformation");

        //    List<MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>();
        //    MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation();

        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
        //    List<OtherInformationDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<OtherInformationDataModel>>(JsonDataTable_Data);
        //    dataModels.OtherInformations = LandDetailDataModel_Item;


        //    List<DataTable> dataModel = new List<DataTable>();
        //    dataModel.Add(dataSet.Tables[1]);
        //    dataModels.DocumentScrutinyFinalRemarkList = dataModel;


        //    listdataModels.Add(dataModels);

        //    return listdataModels;
        //}

        //public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> DocumentScrutiny_HostelDetail(int CollageID, int RoleID, int ApplyNOCID)
        //{
        //    string SqlQuery = " exec USP_DocumentScrutiny_HostelDetail @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
        //    DataSet dataSet = new DataSet();
        //    dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_HostelDetail");

        //    List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail>();
        //    MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyHostelDetail();

        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
        //    List<HostelDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<HostelDataModel>>(JsonDataTable_Data);
        //    dataModels.HostelDetails = LandDetailDataModel_Item;


        //    List<DataTable> dataModel = new List<DataTable>();
        //    dataModel.Add(dataSet.Tables[1]);
        //    dataModels.DocumentScrutinyFinalRemarkList = dataModel;


        //    listdataModels.Add(dataModels);

        //    return listdataModels;
        //}


        //public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> DocumentScrutiny_HospitalDetail(int CollageID, int RoleID, int ApplyNOCID)
        //{
        //    string SqlQuery = " exec USP_DocumentScrutiny_HospitalDetail @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
        //    DataSet dataSet = new DataSet();
        //    dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_HospitalDetail");

        //    List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail>();
        //    MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyHospitalDetail();

        //    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
        //    List<HospitalMasterDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<HospitalMasterDataModel>>(JsonDataTable_Data);
        //    dataModels.HospitalDetails = LandDetailDataModel_Item;


        //    List<DataTable> dataModel = new List<DataTable>();
        //    dataModel.Add(dataSet.Tables[1]);
        //    dataModels.DocumentScrutinyFinalRemarkList = dataModel;


        //    listdataModels.Add(dataModels);

        //    return listdataModels;
        //}

        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_AcademicInformation_AH @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_AcademicInformation");

            List<AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>();
            AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation dataModels = new AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<AcademicInformationDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<AcademicInformationDetailsDataModel>>(JsonDataTable_Data);
            dataModels.AcademicInformations = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeManagementSociety_AH @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_CollegeManagementSociety");

            List<AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>();
            AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety dataModels = new AnimalDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<SocietyMasterDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<SocietyMasterDataModel>>(JsonDataTable_Data);
            dataModels.CollegeManagementSocietys = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> DocumentScrutiny_CollegeDetail(int CollegeID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeDetail_AH @CollegeID=" + CollegeID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "MedicalDocumentScrutiny.DocumentScrutiny_CollegeDetail");

            List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail> listdataModels = new List<MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail>();
            MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail dataModels = new MedicalDocumentScrutinyDataModel_DocumentScrutinyCollegeDetail();

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
