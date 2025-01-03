using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RJ_NOC_DataAccess.Repository
{
    public class HospitalMasterRepository : IHospitalMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public HospitalMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<HospitalAreaValidation> GetHospitalAreaValidation()
        {
            string SqlQuery = "exec USP_HospitalMaster @Action='GetAllHospitalAreaValidation'";
            var dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HospitalMasterRepository.GetHospitalAreaValidation");
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            var dataModels = JsonConvert.DeserializeObject<List<HospitalAreaValidation>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(HospitalMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("@HospitalID='{0}',", request.HospitalID);
            sb.AppendFormat("@CollegeID='{0}',", request.CollegeID);
            sb.AppendFormat("@ParentHospitalID='{0}',", request.ParentHospitalID);
            sb.AppendFormat("@HospitalAreaID='{0}',", request.HospitalAreaID);
            sb.AppendFormat("@HospitalName='{0}',", request.HospitalName);
            sb.AppendFormat("@HospitalRegNo='{0}',", request.HospitalRegNo);
            sb.AppendFormat("@HospitalDistance='{0}',", request.HospitalDistance);
            sb.AppendFormat("@HospitalContactNo='{0}',", request.HospitalContactNo);
            sb.AppendFormat("@HospitalEmailID='{0}',", request.HospitalEmailID);
            sb.AppendFormat("@ManageByName='{0}',", request.ManageByName);
            sb.AppendFormat("@ManageByPhone='{0}',", request.ManageByPhone);
            sb.AppendFormat("@OwnerName='{0}',", request.OwnerName);
            sb.AppendFormat("@OwnerPhone='{0}',", request.OwnerPhone);
            sb.AppendFormat("@MedicalBeds='{0}',", request.MedicalBeds);
            sb.AppendFormat("@SurgicalBeds='{0}',", request.SurgicalBeds);
            sb.AppendFormat("@ObstAndGynaecologyBeds='{0}',", request.ObstAndGynaecologyBeds);
            sb.AppendFormat("@PediatricsBeds='{0}',", request.PediatricsBeds);
            sb.AppendFormat("@OrthoBeds='{0}',", request.OrthoBeds);
            sb.AppendFormat("@OccupancyPercentegeBeds='{0}',", request.OccupancyPercentegeBeds);
            sb.AppendFormat("@AffiliationPsychiatricBeds='{0}',", request.AffiliationPsychiatricBeds);
            sb.AppendFormat("@ParentHospitalRelatedToOtherID='{0}',", request.ParentHospitalRelatedToOtherID);
            sb.AppendFormat("@InstitutionName='{0}',", request.InstitutionName);
            sb.AppendFormat("@OrganizationPhone='{0}',", request.OrganizationPhone);
            sb.AppendFormat("@CardioThoracicTotalBeds='{0}',", request.CardioThoracicTotalBeds);
            sb.AppendFormat("@CardioThoracicCCUBeds='{0}',", request.CardioThoracicCCUBeds);
            sb.AppendFormat("@CardioThoracicICCUBeds='{0}',", request.CardioThoracicICCUBeds);
            sb.AppendFormat("@CardioThoracicICUBeds='{0}',", request.CardioThoracicICUBeds);
            sb.AppendFormat("@CriticalCareNursingTotalBeds='{0}',", request.CriticalCareNursingTotalBeds);
            sb.AppendFormat("@CriticalCareNursingCCBeds='{0}',", request.CriticalCareNursingCCBeds);
            sb.AppendFormat("@CriticalCareNursingICUBeds='{0}',", request.CriticalCareNursingICUBeds);
            sb.AppendFormat("@MidwiferyNursingTotalBeds='{0}',", request.MidwiferyNursingTotalBeds);
            sb.AppendFormat("@MotherNeonatalUnitsBeds='{0}',", request.MotherNeonatalUnitsBeds);
            sb.AppendFormat("@DeliveriesPerYear='{0}',", request.DeliveriesPerYear);
            sb.AppendFormat("@LevelIINeonatalBeds='{0}',", request.LevelIINeonatalBeds);
            sb.AppendFormat("@LevelIIINeonatalBeds='{0}',", request.LevelIIINeonatalBeds);
            sb.AppendFormat("@NeuroScienceNursingTotalBeds='{0}',", request.NeuroScienceNursingTotalBeds);
            sb.AppendFormat("@OncologyNursingTotalBeds='{0}',", request.OncologyNursingTotalBeds);
            sb.AppendFormat("@OncologyNursingMedicalBeds='{0}',", request.OncologyNursingMedicalBeds);
            sb.AppendFormat("@OncologyNurSingsurgicalBeds='{0}',", request.OncologyNurSingsurgicalBeds);
            sb.AppendFormat("@OncologyNursingChemotherapyBeds='{0}',", request.OncologyNursingChemotherapyBeds);
            sb.AppendFormat("@OncologyNursingRadiotherapyBeds='{0}',", request.OncologyNursingRadiotherapyBeds);
            sb.AppendFormat("@OncologyNursingPalliativeBeds='{0}',", request.OncologyNursingPalliativeBeds);
            sb.AppendFormat("@OncologyNursingDiagnosticBeds='{0}',", request.OncologyNursingDiagnosticBeds);
            sb.AppendFormat("@OrthopaedicRehabilitationNursingTotalBeds='{0}',", request.OrthopaedicRehabilitationNursingTotalBeds);
            sb.AppendFormat("@OrthopaedicRehabilitationNursingOrthopaedicBeds='{0}',", request.OrthopaedicRehabilitationNursingOrthopaedicBeds);
            sb.AppendFormat("@OrthopaedicRehabilitationNursingRehabilitationBeds='{0}',", request.OrthopaedicRehabilitationNursingRehabilitationBeds);
            sb.AppendFormat("@PsychiatricNursingTotalBeds='{0}',", request.PsychiatricNursingTotalBeds);
            sb.AppendFormat("@PsychiatricNursingAcuteBeds='{0}',", request.PsychiatricNursingAcuteBeds);
            sb.AppendFormat("@PsychiatricNursingChronicBeds='{0}',", request.PsychiatricNursingChronicBeds);
            sb.AppendFormat("@PsychiatricNursingAdultBeds='{0}',", request.PsychiatricNursingAdultBeds);
            sb.AppendFormat("@PsychiatricNursingChildBeds='{0}',", request.PsychiatricNursingChildBeds);
            sb.AppendFormat("@PsychiatricNursingDeAddictionBeds='{0}',", request.PsychiatricNursingDeAddictionBeds);
            sb.AppendFormat("@NeonatalNursingTotalBeds='{0}',", request.NeonatalNursingTotalBeds);
            sb.AppendFormat("@NeonatalNursingLevelIIOrIIINICUBeds='{0}',", request.NeonatalNursingLevelIIOrIIINICUBeds);
            sb.AppendFormat("@NeonatalNursingNICUBeds='{0}',", request.NeonatalNursingNICUBeds);
            sb.AppendFormat("@OperationRoomNursingTotalBeds='{0}',", request.OperationRoomNursingTotalBeds);
            sb.AppendFormat("@OperationRoomNursingGeneralSurgeryBeds='{0}',", request.OperationRoomNursingGeneralSurgeryBeds);
            sb.AppendFormat("@OperationRoomNursingPediatricBeds='{0}',", request.OperationRoomNursingPediatricBeds);
            sb.AppendFormat("@OperationRoomNursingCardiothoracicBeds='{0}',", request.OperationRoomNursingCardiothoracicBeds);
            sb.AppendFormat("@OperationRoomNursingGynaeAndObstetricalBeds='{0}',", request.OperationRoomNursingGynaeAndObstetricalBeds);
            sb.AppendFormat("@OperationRoomNursingOrthopaedicsBeds='{0}',", request.OperationRoomNursingOrthopaedicsBeds);
            sb.AppendFormat("@OperationRoomNursingOphthalmicBeds='{0}',", request.OperationRoomNursingOphthalmicBeds);
            sb.AppendFormat("@OperationRoomNursingENTAndNeuroBeds='{0}',", request.OperationRoomNursingENTAndNeuroBeds);
            sb.AppendFormat("@EmergencyAndDisasterNursingTotalBeds='{0}',", request.EmergencyAndDisasterNursingTotalBeds);
            sb.AppendFormat("@EmergencyAndDisasterNursingICUBeds='{0}',", request.EmergencyAndDisasterNursingICUBeds);
            sb.AppendFormat("@EmergencyAndDisasterNursingEmergencylBeds='{0}',", request.EmergencyAndDisasterNursingEmergencylBeds);
            sb.AppendFormat("@AddressLine1='{0}',", request.AddressLine1);
            sb.AppendFormat("@AddressLine2='{0}',", request.AddressLine2);
            sb.AppendFormat("@RuralUrban='{0}',", request.RuralUrban);
            sb.AppendFormat("@DivisionID='{0}',", request.DivisionID);
            sb.AppendFormat("@DistrictID='{0}',", request.DistrictID);
            sb.AppendFormat("@TehsilID='{0}',", request.TehsilID);
            sb.AppendFormat("@PanchayatSamitiID='{0}',", request.PanchayatSamitiID);
            sb.AppendFormat("@CityTownVillage='{0}',", request.CityTownVillage);
            sb.AppendFormat("@Pincode='{0}',", request.Pincode);
            sb.AppendFormat("@AddressLine1_ManageBy='{0}',", request.AddressLine1_ManageBy);
            sb.AppendFormat("@AddressLine2_ManageBy='{0}',", request.AddressLine2_ManageBy);
            sb.AppendFormat("@RuralUrban_ManageBy='{0}',", request.RuralUrban_ManageBy);
            sb.AppendFormat("@DivisionID_ManageBy='{0}',", request.DivisionID_ManageBy);
            sb.AppendFormat("@DistrictID_ManageBy='{0}',", request.DistrictID_ManageBy);
            sb.AppendFormat("@TehsilID_ManageBy='{0}',", request.TehsilID_ManageBy);
            sb.AppendFormat("@PanchayatSamitiID_ManageBy='{0}',", request.PanchayatSamitiID_ManageBy);
            sb.AppendFormat("@CityTownVillage_ManageBy='{0}',", request.CityTownVillage_ManageBy);
            sb.AppendFormat("@Pincode_ManageBy='{0}',", request.Pincode_ManageBy);
            sb.AppendFormat("@AddressLine1_Owner='{0}',", request.AddressLine1_Owner);
            sb.AppendFormat("@AddressLine2_Owner='{0}',", request.AddressLine2_Owner);
            sb.AppendFormat("@RuralUrban_Owner='{0}',", request.RuralUrban_Owner);
            sb.AppendFormat("@DivisionID_Owner='{0}',", request.DivisionID_Owner);
            sb.AppendFormat("@DistrictID_Owner='{0}',", request.DistrictID_Owner);
            sb.AppendFormat("@TehsilID_Owner='{0}',", request.TehsilID_Owner);
            sb.AppendFormat("@PanchayatSamitiID_Owner='{0}',", request.PanchayatSamitiID_Owner);
            sb.AppendFormat("@CityTownVillage_Owner='{0}',", request.CityTownVillage_Owner);
            sb.AppendFormat("@Pincode_Owner='{0}',", request.Pincode_Owner);
            sb.AppendFormat("@AddressLine1_Other='{0}',", request.AddressLine1_Other);
            sb.AppendFormat("@AddressLine2_Other='{0}',", request.AddressLine2_Other);
            sb.AppendFormat("@RuralUrban_Other='{0}',", request.RuralUrban_Other);
            sb.AppendFormat("@DivisionID_Other='{0}',", request.DivisionID_Other);
            sb.AppendFormat("@DistrictID_Other='{0}',", request.DistrictID_Other);
            sb.AppendFormat("@TehsilID_Other='{0}',", request.TehsilID_Other);
            sb.AppendFormat("@PanchayatSamitiID_Other='{0}',", request.PanchayatSamitiID_Other);
            sb.AppendFormat("@CityTownVillage_Other='{0}',", request.CityTownVillage_Other);
            sb.AppendFormat("@Pincode_Other='{0}',", request.Pincode_Other);

            sb.AppendFormat("@AffiliatedHospitalAffiliationToOtherID='{0}',", request.AffiliatedHospitalAffiliationToOtherID);
            sb.AppendFormat("@ParentNotDocument='{0}',", request.ParentNotDocument);
            sb.AppendFormat("@ConsentForm='{0}',", request.ConsentForm);

            sb.AppendFormat("@CreatedBy='{0}',", request.CreatedBy);
            sb.AppendFormat("@ModifyBy='{0}',", request.ModifyBy);
            sb.AppendFormat("@IPAddress='{0}',", IPAddress);


            sb.AppendFormat("@PollutionUnitID='{0}',", request.PollutionUnitID);
            sb.AppendFormat("@PollutionCertificate='{0}',", request.PollutionCertificate);
            sb.AppendFormat("@HospitalStatus='{0}',", request.HospitalStatus);

            sb.AppendFormat("@CityID='{0}',", request.CityID);
            sb.AppendFormat("@CityID_ManageBy='{0}',", request.CityID_ManageBy);
            sb.AppendFormat("@CityID_Owner='{0}',", request.CityID_Owner);
            sb.AppendFormat("@CityID_Other='{0}',", request.CityID_Other);
            sb.AppendFormat("@IsAffiliatedHospital='{0}',", request.IsAffiliatedHospital);


            sb.AppendFormat("@GeneralMedicinebed='{0}',", request.GeneralMedicinebed);
            sb.AppendFormat("@PaediatricsBed='{0}',", request.PaediatricsBed);
            sb.AppendFormat("@SkinandVDBed='{0}',", request.SkinandVDBed);
            sb.AppendFormat("@PsychiatryBed='{0}',", request.PsychiatryBed);
            sb.AppendFormat("@GeneralSurgeryBed='{0}',", request.GeneralSurgeryBed);
            sb.AppendFormat("@SurgeryOrthopaedicsBed='{0}',", request.SurgeryOrthopaedicsBed);
            sb.AppendFormat("@SurgeryOphthalmologyBed='{0}',", request.SurgeryOphthalmologyBed);
            sb.AppendFormat("@SurgeryOtorhinolaryngologyBed='{0}',", request.SurgeryOtorhinolaryngologyBed);
            sb.AppendFormat("@ObstetricsGynaecologyBed='{0}',", request.ObstetricsGynaecologyBed);
            sb.AppendFormat("@ICUBed='{0}',", request.ICUBed);
            sb.AppendFormat("@ICCUBed='{0}',", request.ICCUBed);
            sb.AppendFormat("@RICUBed='{0}',", request.RICUBed);
            sb.AppendFormat("@SICUBed='{0}',", request.SICUBed);
            sb.AppendFormat("@NICUBed='{0}',", request.NICUBed);
            sb.AppendFormat("@PICUBed='{0}',", request.PICUBed);
            sb.AppendFormat("@ICUGrandTotalBed='{0}',", request.ICUGrandTotalBed);
            sb.AppendFormat("@OTICUBed='{0}',", request.OTICUBed);
            sb.AppendFormat("@CasualtyBeds='{0}',", request.CasualtyBeds);

            // action
            sb.AppendFormat("@Action='{0}'", "SaveHospitalData");

            string SqlQuery = $" exec USP_HospitalMaster  {sb.ToString()}";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "HospitalMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int hospitalId, int modifiedBy)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_HospitalMaster @Action='DeleteHospitalById',@ModifyBy={modifiedBy},@HospitalID={hospitalId},@IPAddress='{IPAddress}'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "HospitalMaster.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public HospitalMasterDataModel GetData(int hospitalId)
        {
            string SqlQuery = $"exec USP_HospitalMaster @HospitalID={hospitalId},@Action='GetHospitalById'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "HospitalMaster.GetData");

            HospitalMasterDataModel hospitalMasterDataModel = new HospitalMasterDataModel();
            if (dt != null)
            {
                hospitalMasterDataModel = CommonHelper.ConvertDataTable<HospitalMasterDataModel>(dt);
            }

            return hospitalMasterDataModel;
        }

        public bool IsSuperSpecialtyHospital(int collegeId)
        {
            string SqlQuery = $"exec USP_CheckSuperHospital @CollegeID={collegeId}";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "IsSuperSpecialtyHospital.IsSuperSpecialtyHospital");

            bool retval = false;
            if (dt != null)
            {
                retval = Convert.ToBoolean(dt.Rows[0]["IsSuperSpecialtyHospital"]);
            }

            return retval;
        }
        public List<HospitalMasterDataModel> GetDataList(int collegeId)
        {
            string SqlQuery = $"exec USP_HospitalMaster @CollegeID={collegeId},@Action='GetHospitalByCollegeId'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "HospitalMaster.GetDataList");

            List<HospitalMasterDataModel> hospitalMasterDataList = new List<HospitalMasterDataModel>();
            if (dt != null)
            {
                hospitalMasterDataList = CommonHelper.ConvertDataTable<List<HospitalMasterDataModel>>(dt);
            }

            return hospitalMasterDataList;
        }

        public List<HospitalMasterDataModel> GetHospitalDataListforPDF(int CollegeID)
        {
            string SqlQuery = $"exec USP_GetHospitalMasterPDFDetail @CollegeID={CollegeID}";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "HospitalMaster.GetHospitalDataListforPDF");

            List<HospitalMasterDataModel> hospitalMasterDataList = new List<HospitalMasterDataModel>();
            if (dt != null)
            {
                hospitalMasterDataList = CommonHelper.ConvertDataTable<List<HospitalMasterDataModel>>(dt);
            }

            return hospitalMasterDataList;
        }



        public bool SaveMGThreeHospitalData(MGThreeHospitalDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            StringBuilder sb = new StringBuilder();
            string Detail_Str = request.MGThreeAffiliatedHospitalList.Count > 0 ? CommonHelper.GetDetailsTableQry(request.MGThreeAffiliatedHospitalList, "Temp_MGThreeAffiliatedHospitalList") : "";
            sb.AppendFormat("@HospitalID='{0}',", request.HospitalID);
            sb.AppendFormat("@CollegeID='{0}',", request.CollegeID);
            sb.AppendFormat("@IsHillytribalArea='{0}',", request.IsHillytribalArea);
            sb.AppendFormat("@IsInstitutionParentHospital='{0}',", request.IsInstitutionParentHospital);
            sb.AppendFormat("@HospitalStatus='{0}',", request.HospitalStatus);
            sb.AppendFormat("@HospitalName='{0}',", request.HospitalName);
            sb.AppendFormat("@RegistrationNo='{0}',", request.RegistrationNo);
            sb.AppendFormat("@HospitalContactNo='{0}',", request.HospitalContactNo);
            sb.AppendFormat("@HospitalEmailID='{0}',", request.HospitalEmailID);
            sb.AppendFormat("@AddressLine1='{0}',", request.AddressLine1);
            sb.AppendFormat("@AddressLine2='{0}',", request.AddressLine2);
            sb.AppendFormat("@RuralUrban='{0}',", request.RuralUrban);
            sb.AppendFormat("@DivisionID='{0}',", request.DivisionID);
            sb.AppendFormat("@DistrictID='{0}',", request.DistrictID);
            sb.AppendFormat("@TehsilID='{0}',", request.TehsilID);
            sb.AppendFormat("@CityID='{0}',", request.CityID);
            sb.AppendFormat("@PanchayatSamitiID='{0}',", request.PanchayatSamitiID);
            sb.AppendFormat("@CityTownVillage='{0}',", request.CityTownVillage);
            sb.AppendFormat("@Pincode='{0}',", request.Pincode);
            sb.AppendFormat("@OwnerName='{0}',", request.OwnerName);
            sb.AppendFormat("@SocietyMemberID='{0}',", request.SocietyMemberID);
            sb.AppendFormat("@HospitalMOU='{0}',", request.HospitalMOU);
            sb.AppendFormat("@BedCapacity='{0}',", request.BedCapacity);
            sb.AppendFormat("@MedicalBeds='{0}',", request.MedicalBeds);
            sb.AppendFormat("@SurgicalBeds='{0}',", request.SurgicalBeds);
            sb.AppendFormat("@ObstetricsBeds='{0}',", request.ObstetricsBeds);
            sb.AppendFormat("@PediatricsBeds='{0}',", request.PediatricsBeds);
            sb.AppendFormat("@OrthoBeds='{0}',", request.OrthoBeds);
            sb.AppendFormat("@EmergencyMedicineBeds='{0}',", request.EmergencyMedicineBeds);
            sb.AppendFormat("@PsychiatryBeds='{0}',", request.PsychiatryBeds);
            sb.AppendFormat("@NumberofDeliveries='{0}',", request.NumberofDeliveries);
            sb.AppendFormat("@CollegeDistance='{0}',", request.CollegeDistance);
            sb.AppendFormat("@BedOccupancy='{0}',", request.BedOccupancy);
            sb.AppendFormat("@FireNOC='{0}',", request.FireNOC);
            sb.AppendFormat("@PollutionCertificate='{0}',", request.PollutionCertificate);
            sb.AppendFormat("@ClinicalEstablishment='{0}',", request.ClinicalEstablishment);
            sb.AppendFormat("@NABH='{0}',", request.NABH);
            sb.AppendFormat("@UndertakingNotAffiliated='{0}',", request.UndertakingNotAffiliated);
            sb.AppendFormat("@StaffInformation='{0}',", request.StaffInformation);

            sb.AppendFormat("@Detail_Str='{0}'", Detail_Str);

            string SqlQuery = $" exec USP_SaveMGThreeHospitalData  {sb.ToString()}";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "HospitalMaster.SaveMGThreeHospitalData");
            if (Rows > 0)
                return true;
            else
                return false;
        }


        public List<MGThreeHospitalDataModel> GetMGThreeHospitalDetailList_DepartmentCollegeWise(int DepartmentID, int CollegeID, int HospitalID, int ApplyNOCID)
        {
            string SqlQuery = " exec USP_GetMGThreeHospitalDetailList_DepartmentCollegeWise @HospitalID='" + HospitalID + "',@DepartmentID='" + DepartmentID + "',@CollegeID='" + CollegeID + "',@ApplyNOCID='" + ApplyNOCID + "'";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "HospitalMaster.GetMGThreeHospitalDetailList_DepartmentCollegeWise");
            List<MGThreeHospitalDataModel> listdataModels = new List<MGThreeHospitalDataModel>();
            List<MGThreeAffiliatedHospitalDataModel> afflistdataModels = new List<MGThreeAffiliatedHospitalDataModel>();
            MGThreeHospitalDataModel dataModels = new MGThreeHospitalDataModel();
            if (HospitalID == 0)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[0]);
                listdataModels = JsonConvert.DeserializeObject<List<MGThreeHospitalDataModel>>(JsonDataTable_Data);
                string item = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                afflistdataModels = JsonConvert.DeserializeObject<List<MGThreeAffiliatedHospitalDataModel>>(item);
                for (int i = 0; i < listdataModels.Count(); i++)
                {
                    var count = afflistdataModels.Where(w => w.MGTHID == listdataModels[i].HospitalID).ToList().Count;
                    if (count > 0)
                    {
                        if (listdataModels[i].MGThreeAffiliatedHospitalList == null)
                        {
                            listdataModels[i].MGThreeAffiliatedHospitalList = new List<MGThreeAffiliatedHospitalDataModel>();
                        }

                        listdataModels[i].MGThreeAffiliatedHospitalList.AddRange(
                             afflistdataModels.Where(w => w.MGTHID == listdataModels[i].HospitalID).Select(s => new MGThreeAffiliatedHospitalDataModel()
                             {
                                 MGTHID = s.MGTHID,
                                 HospitalID = s.HospitalID,
                                 AffiliatedHospitalName = s.AffiliatedHospitalName,
                                 AffiliationReason = s.AffiliationReason,
                                 AffiliationReasonName = s.AffiliationReasonName,
                                 BedCapacity = s.BedCapacity,
                                 BedOccupancy = s.BedOccupancy,
                                 BedOccupancyPath = s.BedOccupancyPath,
                                 ClinicalEstablishment = s.BedOccupancyPath,
                                 ClinicalEstablishmentPath = s.BedOccupancyPath,
                                 CollegeDistance = s.CollegeDistance,
                                 CollegeID = s.CollegeID,
                                 Dis_BedOccupancy = s.Dis_BedOccupancy,
                                 Dis_ClinicalEstablishment = s.Dis_ClinicalEstablishment,
                                 Dis_FireNOC = s.Dis_FireNOC,
                                 Dis_HospitalMOU = s.Dis_HospitalMOU,
                                 Dis_NABH = s.Dis_NABH,
                                 Dis_PollutionCertificate = s.Dis_PollutionCertificate,
                                 Dis_StaffInformation = s.Dis_StaffInformation,
                                 Dis_UndertakingNotAffiliated = s.Dis_UndertakingNotAffiliated,
                                 EmergencyMedicineBeds = s.EmergencyMedicineBeds,
                                 FireNOC = s.FireNOC,
                                 FireNOCPath = s.FireNOCPath,
                                 HospitalMOU = s.HospitalMOU,
                                 HospitalMOUPath = s.HospitalMOUPath,
                                 MedicalBeds = s.MedicalBeds,
                                 NABH = s.NABH,
                                 NABHPath = s.NABHPath,
                                 NumberDeliveries = s.NumberDeliveries,
                                 ObstetricsBeds = s.ObstetricsBeds,
                                 OrthoBeds = s.OrthoBeds,
                                 OwnerName = s.OwnerName,
                                 PediatricsBeds = s.PediatricsBeds,
                                 PollutionCertificate = s.PollutionCertificate,
                                 PollutionCertificatePath = s.PollutionCertificatePath,
                                 PsychiatryBeds = s.PsychiatryBeds,
                                 SpecialtyAffiliation = s.SpecialtyAffiliation,
                                 StaffInformation = s.StaffInformation,
                                 StaffInformationPath = s.StaffInformationPath,
                                 SurgicalBeds = s.SurgicalBeds,
                                 UndertakingNotAffiliated = s.UndertakingNotAffiliated,
                                 UndertakingNotAffiliatedPath = s.UndertakingNotAffiliatedPath
                             }).ToList()
                            );
                    }
                }
            }
            else
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    dataModels.HospitalID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["HospitalID"]);
                    dataModels.CollegeID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeID"]);
                    dataModels.IsHillytribalArea = dataSet.Tables[0].Rows[0]["IsHillytribalArea"].ToString();
                    dataModels.IsInstitutionParentHospital = dataSet.Tables[0].Rows[0]["IsInstitutionParentHospital"].ToString();
                    dataModels.HospitalStatus = dataSet.Tables[0].Rows[0]["HospitalStatus"].ToString();
                    dataModels.HospitalName = dataSet.Tables[0].Rows[0]["HospitalName"].ToString();
                    dataModels.RegistrationNo = dataSet.Tables[0].Rows[0]["RegistrationNo"].ToString();
                    dataModels.HospitalContactNo = dataSet.Tables[0].Rows[0]["HospitalContactNo"].ToString();
                    dataModels.HospitalEmailID = dataSet.Tables[0].Rows[0]["HospitalEmailID"].ToString();
                    dataModels.AddressLine1 = dataSet.Tables[0].Rows[0]["AddressLine1"].ToString();
                    dataModels.AddressLine2 = dataSet.Tables[0].Rows[0]["AddressLine2"].ToString();
                    dataModels.RuralUrban = Convert.ToInt32(dataSet.Tables[0].Rows[0]["RuralUrban"].ToString());
                    dataModels.DivisionID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DivisionID"].ToString());
                    dataModels.DistrictID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DistrictID"].ToString());
                    dataModels.TehsilID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["TehsilID"].ToString());
                    dataModels.CityID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CityID"].ToString());
                    dataModels.PanchayatSamitiID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PanchayatSamitiID"].ToString());
                    dataModels.CityTownVillage = dataSet.Tables[0].Rows[0]["CityTownVillage"].ToString();
                    dataModels.Pincode = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Pincode"].ToString());
                    dataModels.OwnerName = dataSet.Tables[0].Rows[0]["OwnerName"].ToString();
                    dataModels.SocietyMemberID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["SocietyMemberID"].ToString());
                    dataModels.HospitalMOU = dataSet.Tables[0].Rows[0]["HospitalMOU"].ToString();
                    dataModels.Dis_HospitalMOU = dataSet.Tables[0].Rows[0]["Dis_HospitalMOU"].ToString();
                    dataModels.HospitalMOUPath = dataSet.Tables[0].Rows[0]["HospitalMOUPath"].ToString();
                    dataModels.BedCapacity = Convert.ToInt32(dataSet.Tables[0].Rows[0]["BedCapacity"].ToString());
                    dataModels.MedicalBeds = Convert.ToInt32(dataSet.Tables[0].Rows[0]["MedicalBeds"].ToString());
                    dataModels.SurgicalBeds = Convert.ToInt32(dataSet.Tables[0].Rows[0]["SurgicalBeds"].ToString());
                    dataModels.ObstetricsBeds = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ObstetricsBeds"].ToString());
                    dataModels.PediatricsBeds = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PediatricsBeds"].ToString());
                    dataModels.OrthoBeds = Convert.ToInt32(dataSet.Tables[0].Rows[0]["OrthoBeds"].ToString());
                    dataModels.EmergencyMedicineBeds = Convert.ToInt32(dataSet.Tables[0].Rows[0]["EmergencyMedicineBeds"].ToString());
                    dataModels.PsychiatryBeds = Convert.ToInt32(dataSet.Tables[0].Rows[0]["PsychiatryBeds"].ToString());
                    dataModels.NumberofDeliveries = Convert.ToInt32(dataSet.Tables[0].Rows[0]["NumberofDeliveries"].ToString());
                    dataModels.CollegeDistance = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CollegeDistance"].ToString());
                    dataModels.BedOccupancy = dataSet.Tables[0].Rows[0]["BedOccupancy"].ToString();
                    dataModels.Dis_BedOccupancy = dataSet.Tables[0].Rows[0]["Dis_BedOccupancy"].ToString();
                    dataModels.BedOccupancyPath = dataSet.Tables[0].Rows[0]["BedOccupancyPath"].ToString();
                    dataModels.FireNOC = dataSet.Tables[0].Rows[0]["FireNOC"].ToString();
                    dataModels.Dis_FireNOC = dataSet.Tables[0].Rows[0]["Dis_FireNOC"].ToString();
                    dataModels.FireNOCPath = dataSet.Tables[0].Rows[0]["FireNOCPath"].ToString();
                    dataModels.PollutionCertificate = dataSet.Tables[0].Rows[0]["PollutionCertificate"].ToString();
                    dataModels.Dis_PollutionCertificate = dataSet.Tables[0].Rows[0]["Dis_PollutionCertificate"].ToString();
                    dataModels.PollutionCertificatePath = dataSet.Tables[0].Rows[0]["PollutionCertificatePath"].ToString();
                    dataModels.ClinicalEstablishment = dataSet.Tables[0].Rows[0]["ClinicalEstablishment"].ToString();
                    dataModels.Dis_ClinicalEstablishment = dataSet.Tables[0].Rows[0]["Dis_ClinicalEstablishment"].ToString();
                    dataModels.ClinicalEstablishmentPath = dataSet.Tables[0].Rows[0]["ClinicalEstablishmentPath"].ToString();
                    dataModels.NABH = dataSet.Tables[0].Rows[0]["NABH"].ToString();
                    dataModels.Dis_NABH = dataSet.Tables[0].Rows[0]["Dis_NABH"].ToString();
                    dataModels.NABHPath = dataSet.Tables[0].Rows[0]["NABHPath"].ToString();
                    dataModels.UndertakingNotAffiliated = dataSet.Tables[0].Rows[0]["UndertakingNotAffiliated"].ToString();
                    dataModels.Dis_UndertakingNotAffiliated = dataSet.Tables[0].Rows[0]["Dis_UndertakingNotAffiliated"].ToString();
                    dataModels.UndertakingNotAffiliatedPath = dataSet.Tables[0].Rows[0]["UndertakingNotAffiliatedPath"].ToString();
                    dataModels.StaffInformation = dataSet.Tables[0].Rows[0]["StaffInformation"].ToString();
                    dataModels.Dis_StaffInformation = dataSet.Tables[0].Rows[0]["Dis_StaffInformation"].ToString();
                    dataModels.StaffInformationPath = dataSet.Tables[0].Rows[0]["StaffInformationPath"].ToString();

                    dataModels.DivisionName = dataSet.Tables[0].Rows[0]["DivisionName"].ToString();
                    dataModels.DistrictName = dataSet.Tables[0].Rows[0]["DistrictName"].ToString();
                    dataModels.TehsilName = dataSet.Tables[0].Rows[0]["TehsilName"].ToString();
                    dataModels.PanchyatSamitiName = dataSet.Tables[0].Rows[0]["PanchyatSamitiName"].ToString();
                    dataModels.CityName = dataSet.Tables[0].Rows[0]["CityName"].ToString();



                    string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataSet.Tables[1]);
                    List<MGThreeAffiliatedHospitalDataModel> item = JsonConvert.DeserializeObject<List<MGThreeAffiliatedHospitalDataModel>>(JsonDataTable_Data);
                    dataModels.MGThreeAffiliatedHospitalList = item;
                    listdataModels.Add(dataModels);
                }
            }
            return listdataModels;
        }

        public bool DeleteHospitalDetail(int HospitalID)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_DeleteHospitalDetail @HospitalID={HospitalID}";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "HospitalMaster.DeleteHospitalDetail");
            if (Rows > 0)
                return true;
            else
                return false;
        }
    }
}
