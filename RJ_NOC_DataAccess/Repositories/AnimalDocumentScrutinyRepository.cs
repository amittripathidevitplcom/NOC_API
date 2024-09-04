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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.DocumentScrutiny_LegalEntity");

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

        public List<CommonDataModel_DataTable> CheckDocumentScrutinyTabsData(int ApplyNOCID, int RoleID, int CollegeID)
        {
            string SqlQuery = " exec USP_CheckDocumentScrutinyTabsData @ApplyNOCID ='" + ApplyNOCID + "',@RoleID ='" + RoleID + "',@CollegeID ='" + CollegeID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.CheckDocumentScrutinyTabsData");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }


        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyLandDetails> DocumentScrutiny_LandDetails(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_LandDetails_AH @CollageID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.GetWorkFlowMasterList");

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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.GetWorkFlowMasterList");

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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.GetWorkFlowMasterList");

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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.GetWorkFlowMasterList");

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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.GetWorkFlowMasterList");

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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.GetWorkFlowMasterList");

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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.DocumentScrutiny_CollegeDocument");

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

        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> DocumentScrutiny_OtherInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_OtherInformation_AH @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.DocumentScrutiny_OtherInformation");

            List<AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation>();
            AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation dataModels = new AnimalDocumentScrutinyDataModel_DocumentScrutinyOtherInformation();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<OtherInformationDataModel> LandDetailDataModel_Item = JsonConvert.DeserializeObject<List<OtherInformationDataModel>>(JsonDataTable_Data);
            dataModels.OtherInformations = LandDetailDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }



        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyAcademicInformation> DocumentScrutiny_AcademicInformation(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_AcademicInformation_AH @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.DocumentScrutiny_AcademicInformation");

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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.DocumentScrutiny_CollegeManagementSociety");

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
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.DocumentScrutiny_CollegeDetail");

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

        public List<AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital> DocumentScrutiny_VeterinaryHospital(int CollageID, int RoleID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_DocumentScrutiny_VeterinaryHospital_AH @CollegeID=" + CollageID + ",@RoleID=" + RoleID + ",@ApplyNOCID=" + ApplyNOCID + "";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.DocumentScrutiny_VeterinaryHospital");

            List<AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital> listdataModels = new List<AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital>();
            AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital dataModels = new AnimalDocumentScrutinyDataModel_DocumentScrutinyVeterinaryHospital();

            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            List<VeterinaryHospitalDataModel> VeterinaryHospitaDataModel_Item = JsonConvert.DeserializeObject<List<VeterinaryHospitalDataModel>>(JsonDataTable_Data);
            dataModels.VeterinaryHospitals = VeterinaryHospitaDataModel_Item;


            List<DataTable> dataModel = new List<DataTable>();
            dataModel.Add(dataSet.Tables[1]);
            dataModels.DocumentScrutinyFinalRemarkList = dataModel;


            listdataModels.Add(dataModels);

            return listdataModels;
        }

        public List<CommonDataModel_DataTable> GetPhysicalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            string SqlQuery = " exec USP_GetPhysicalVerificationAppliationList_AH @SSOID ='" + request.SSOID + "',@DepartmentID ='" + request.DepartmentID + "',@UserID ='" + request.UserID + "',@RoleID ='" + request.RoleID + "',@Status ='" + request.Status + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetPhysicalVerificationAppliationList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetPostVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            string SqlQuery = " exec USP_GetPostVerificationAppliationList_AH @SSOID ='" + request.SSOID + "',@DepartmentID ='" + request.DepartmentID + "',@UserID ='" + request.UserID + "',@RoleID ='" + request.RoleID + "',@Status ='" + request.Status + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetPhysicalVerificationAppliationList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetFinalVerificationAppliationList(GetPhysicalVerificationAppliationList request)
        {
            string SqlQuery = " exec USP_GetFinalVerificationAppliationList_AH @SSOID ='" + request.SSOID + "',@DepartmentID ='" + request.DepartmentID + "',@UserID ='" + request.UserID + "',@RoleID ='" + request.RoleID + "',@Status ='" + request.Status + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetFinalVerificationAppliationList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetPreVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            string SqlQuery = " exec USP_GetPreVerificationDoneList_AH @SSOID ='" + request.SSOID + "',@DepartmentID ='" + request.DepartmentID + "',@UserID ='" + request.UserID + "',@RoleID ='" + request.RoleID + "',@Status ='" + request.Status + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetPhysicalVerificationAppliationList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool FinalSubmitInspectionCommittee(int ApplyNOCID, int DepartmentID, int UserID, string ActionName)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_FinalSubmitInspectionCommittee_AH";
            SqlQuery += " @ApplyNOCID='" + ApplyNOCID + "',@DepartmentID='" + DepartmentID + "',@createdBy='" + UserID + "',@ActionName='" + ActionName + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AnimalDocumentScrutiny.FinalSubmitInspectionCommittee");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<CommonDataModel_RNCCheckListData> GetPreVerificationchecklistDetails(string Type, int DepartmentID, int ApplyNOCID, int CreatedBy, int RoleID)
        {
            string SqlQuery = "exec USP_GetPreVerificationchecklistDetails @Type='" + Type + "' ,@DepartmentID='" + DepartmentID + "',@ApplyNOCID='" + ApplyNOCID + "',@CreatedBy='" + CreatedBy + "',@RoleID='" + RoleID + "'";
            DataTable dataTable = new DataTable();

            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetPreVerificationchecklistDetails");
            List<CommonDataModel_RNCCheckListData> dataModels = new List<CommonDataModel_RNCCheckListData>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            dataModels = JsonConvert.DeserializeObject<List<CommonDataModel_RNCCheckListData>>(JsonDataTable_Data);
            return dataModels;
        }

        public bool FinalSubmitPreVerification(int ApplyNOCID, int DepartmentID, int UserID, string ActionName, string Remarks)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_FinalSubmitPreVerification_AH";
            SqlQuery += " @ApplyNOCID='" + ApplyNOCID + "',@DepartmentID='" + DepartmentID + "',@createdBy='" + UserID + "',@ActionName='" + ActionName + "',@Remarks=N'" + Remarks + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "AnimalDocumentScrutiny.FinalSubmitPreVerification");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<ApplyNocApplicationDetails_DataModel> GetApplyNOCApplicationList(int RoleID, int UserID, int DepartmentID, string ActionType)
        {
            string SqlQuery = " exec USP_ApplyNOCApplicationList_AH @RoleID='" + RoleID + "',@UserID='" + UserID + "',@DepartmentID='" + DepartmentID + "',@ActionType='" + ActionType + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "AnimalDocumentScrutiny.GetApplyNOCApplicationList");
            List<ApplyNocApplicationDetails_DataModel> listdataModels = new List<ApplyNocApplicationDetails_DataModel>();
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
            listdataModels = JsonConvert.DeserializeObject<List<ApplyNocApplicationDetails_DataModel>>(JsonDataTable_Data);
            return listdataModels;
        }

        public List<CommonDataModel_DataTable> GetPostVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            string SqlQuery = " exec USP_GetPostVerificationDoneList_AH @SSOID ='" + request.SSOID + "',@DepartmentID ='" + request.DepartmentID + "',@UserID ='" + request.UserID + "',@RoleID ='" + request.RoleID + "',@Status ='" + request.Status + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetPostVerificationDoneList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetFinalVerificationDoneList(GetPhysicalVerificationAppliationList request)
        {
            string SqlQuery = " exec USP_GetFinalVerificationDoneList_AH @SSOID ='" + request.SSOID + "',@DepartmentID ='" + request.DepartmentID + "',@UserID ='" + request.UserID + "',@RoleID ='" + request.RoleID + "',@Status ='" + request.Status + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetFinalVerificationDoneList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public List<CommonDataModel_DataTable> GetFinalNOCApplicationList(GetPhysicalVerificationAppliationList request)
        {
            string SqlQuery = " exec USP_GetFinalNOCList_AH @SSOID ='" + request.SSOID + "',@DepartmentID ='" + request.DepartmentID + "',@UserID ='" + request.UserID + "',@RoleID ='" + request.RoleID + "',@Status ='" + request.Status + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetFinalVerificationDoneList");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetNOCCourse(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            string SqlQuery = " exec USP_GetNOCDetails_AH @ApplyNocID='" + ApplyNocID + "',@departmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@ActionType='" + Action + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "AnimalDocumentScrutiny.GetNOCCourse");
            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public List<CommonDataModel_DataTable> GetGeneratePDFData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            string SqlQuery = " exec USP_GetNOCDetails_AH @ApplyNocID='" + ApplyNocID + "',@departmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@ActionType='" + Action + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ApplyNOC.GeneratePDFForJointSecretary");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool SaveNOCIssueData(int ApplyNocID, int DepartmentID, int CollegeID, string Action)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_GetNOCDetails_AH @ActionType='{Action}',@ApplyNocID={ApplyNocID},@departmentID={DepartmentID},@CollegeID={@CollegeID}";
            int Rows = _commonHelper.ExecuteScalar(SqlQuery, "ApplyNOC.FinalSavePDFPathandNOC");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool FinalSavePDFPathandNOC(string Path, int ApplyNOCID, int DepartmentID, int RoleID, int UserID, string NOCIssuedRemark, string Action)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_UpdateNOCDetails_AH @ActionType='{Action}',@NOCFilePath='{Path}',@ApplyNocID={ApplyNOCID},@departmentID={DepartmentID},@RoleID={RoleID},@userID={UserID},@Remarks='{NOCIssuedRemark}',@IPAddress='{IPAddress}'";
            int Rows = _commonHelper.ExecuteScalar(SqlQuery, "ApplyNOC.FinalSavePDFPathandNOC");
            if (Rows > 0)
                return true;
            else
                return false;
        }



    }
}
