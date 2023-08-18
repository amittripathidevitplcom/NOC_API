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
    public class AgricultureDocumentScrutinyRepository : IAgricultureDocumentScrutinyRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public AgricultureDocumentScrutinyRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity> DocumentScrutiny_LegalEntity(int CollegeID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LegalEntity_Agriculture @CollegeID='" + CollegeID + "',@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_LegalEntity");

            List<AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity> listdataModels = new List<AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity>();
            AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity dataModels = new AgricultureDocuemntScrutinyCommonModel_DocumentScrutinyLegalEntity();

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

        public List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID)
        {
            string SqlQuery = " exec USP_CheckDocumentScrutinyTabsData @ApplyNOCID ='" + ApplyNOCID + "',@RoleID ='" + RoleID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AgricultureDocumentScrutinyRepository.CheckDocumentScrutinyTabsData");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }


        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LandDetails_Agriculture @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_LandDetails");

            List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails>();
            AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails dataModels = new AgricultureDocumentScrutinyDataModel_DocumentScrutinyLandDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<LandDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<LandDetailsDataModel>>(JsonDataTable_Data);
            dataModels.LandDetails = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail> DocumentScrutiny_FacilityDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_FacilityDetails_Agriculture @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_FacilityDetail");

            List<AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail>();
            AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail dataModels = new AgricultureDocumentScrutinyDataModel_DocumentFacilityDetail();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<FacilityDetailsDataModel> FacilityDetailsDataModel_Item = JsonConvert.DeserializeObject<List<FacilityDetailsDataModel>>(JsonDataTable_Data);
            dataModels.FacilityDetails = FacilityDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentRoomDetails> DocumentScrutiny_RoomDetail(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_RoomDetails_Agriculture @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_RoomDetail");

            List<AgricultureDocumentScrutinyDataModel_DocumentRoomDetails> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentRoomDetails>();
            AgricultureDocumentScrutinyDataModel_DocumentRoomDetails dataModels = new AgricultureDocumentScrutinyDataModel_DocumentRoomDetails();
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
        public List<AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails> DocumentScrutiny_BuildingDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_BuildingDetails_Agriculture @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_BuildingDetails");

            List<AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails>();
            AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails dataModels = new AgricultureDocumentScrutinyDataModel_DocumentBuildingDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<BuildingDetailsDataModel> BuildingDetailsDataModel_Item = JsonConvert.DeserializeObject<List<BuildingDetailsDataModel>>(JsonDataTable_Data);
            dataModels.BuildingDetails = BuildingDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentStaffDetails> DocumentScrutiny_StaffDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_StaffDetails_Agriculture @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_StaffDetails");

            List<AgricultureDocumentScrutinyDataModel_DocumentStaffDetails> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentStaffDetails>();
            AgricultureDocumentScrutinyDataModel_DocumentStaffDetails dataModels = new AgricultureDocumentScrutinyDataModel_DocumentStaffDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<StaffDetailDataModel> StaffDetailsDataModel_Item = JsonConvert.DeserializeObject<List<StaffDetailDataModel>>(JsonDataTable_Data);
            dataModels.StaffDetails = StaffDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
        public List<AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails> DocumentScrutiny_OldNOCDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_OldNOCDetails_Agriculture @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_OldNOCDetails");

            List<AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails>();
            AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails dataModels = new AgricultureDocumentScrutinyDataModel_DocumentOldNOCDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<OldNocDetailsDataModel> OldNOCDetailsDataModel_Item = JsonConvert.DeserializeObject<List<OldNocDetailsDataModel>>(JsonDataTable_Data);
            dataModels.OldNOCDetails = OldNOCDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<AgricultureDocuemntScrutinyCommonModel> DocumentScrutiny_CollegeDocument(int DepartmentID, int CollageID, int RoleID, int ApplyNOCID, string Type)
        {
            string SP_Name = Type == "Other Document" ? "USP_DocumentScrutiny_OldNOCDetails_Agriculture" : "USP_DocumentScrutiny_RequiredDocument_AH";
            string SqlQuery = " exec " + SP_Name + " @DepartmentID=" + DepartmentID + ",@CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + ",@DocumentType='" + Type + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_CollegeDocument");

            List<AgricultureDocuemntScrutinyCommonModel> listdataModels = new List<AgricultureDocuemntScrutinyCommonModel>();
            AgricultureDocuemntScrutinyCommonModel dataModels = new AgricultureDocuemntScrutinyCommonModel();

            List<DataTable> CollegeDocumentDataModel_Item = new List<DataTable>();
            CollegeDocumentDataModel_Item.Add(dataSet.Tables[0]);
            dataModels.lstDatatable = CollegeDocumentDataModel_Item;

            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.lstFinalRemarkList = dataModel;
            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_OtherInformation_Agriculture @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_OtherInformation");

            List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>();
            AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation dataModels = new AgricultureDocumentScrutinyDataModel_DocumentScrutinyOtherInformation();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<OtherInformationDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<OtherInformationDataModel>>(JsonDataTable_Data);
            dataModels.OtherInformations = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        

        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_AcademicInformation_Agriculture @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_AcademicInformation");

            List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation>();
            AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation dataModels = new AgricultureDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<AcademicInformationDetailsDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<AcademicInformationDetailsDataModel>>(JsonDataTable_Data);
            dataModels.AcademicInformations = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> DocumentScrutiny_CollegeManagementSociety(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeManagementSociety_Agriculture @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_CollegeManagementSociety");

            List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety>();
            AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety dataModels = new AgricultureDocumentScrutinyDataModel_DocumentScrutinyCollegeManagementSociety();

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
            string SqlQuery = " exec USP_DocumentScrutiny_CollegeDetail_Agriculture @CollegeID=" + CollegeID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutinyRepository.DocumentScrutiny_CollegeDetail");

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

        public List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails> DocumentScrutiny_FarmLandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_FarmLandDetails_Agriculture @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AgricultureDocumentScrutiny.DocumentScrutiny_FarmLandDetails");

            List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails> listdataModels = new List<AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails>();
            AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails dataModels = new AgricultureDocumentScrutinyDataModel_DocumentScrutinyFarmLandDetails();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<FarmLandDetailsModel> FarmLandDetailsDataModel_Item = JsonConvert.DeserializeObject<List<FarmLandDetailsModel>>(JsonDataTable_Data);
            dataModels.FarmLandDetails = FarmLandDetailsDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }
    }
}
