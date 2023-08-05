using System.Text;
using RJ_NOC_Model;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;

namespace RJ_NOC_DataAccess.Repository
{
    public class ParamedicalHospitalRepository : IParamedicalHospitalRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ParamedicalHospitalRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        public List<HospitalAreaValidation> GetHospitalAreaValidation()
        {
            string SqlQuery = "exec USP_HospitalMaster @Action='GetAllHospitalAreaValidation'";
            var dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ParamedicalHospital.GetHospitalAreaValidation");
            string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
            var dataModels = JsonConvert.DeserializeObject<List<HospitalAreaValidation>>(JsonDataTable_Data);
            return dataModels;
        }
        public bool SaveData(ParamedicalHospitalDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string ParamedicalHospitalBedValidationList_Str= request.ParamedicalHospitalBedValidation.Count > 0 ? CommonHelper.GetDetailsTableQry(request.ParamedicalHospitalBedValidation, "Temp_Bed_ParamedicalHospital") : "";
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

            sb.AppendFormat("@Action='{0}',", "SaveHospitalData");
            sb.AppendFormat("@PollutionUnitID='{0}',", request.PollutionUnitID);
            sb.AppendFormat("@PollutionCertificate='{0}',", request.PollutionCertificate);
            sb.AppendFormat("@HospitalStatus='{0}',", request.HospitalStatus);
            sb.AppendFormat("@CityPopulation='{0}',", request.CityPopulation);
            sb.AppendFormat("@ParamedicalHospitalBedValidationList_Str='{0}'", ParamedicalHospitalBedValidationList_Str);

            string SqlQuery = $" exec USP_ParamedicalHospital_IU  {sb.ToString()}";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ParamedicalHospital.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public ParamedicalHospitalDataModel GetData(int hospitalId)
        {
            string SqlQuery = $"exec USP_ParamedicalHospital_IU @HospitalID={hospitalId},@Action='GetHospitalById'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "ParamedicalHospital.GetData");

            ParamedicalHospitalDataModel hospitalMasterDataModel = new ParamedicalHospitalDataModel();
            if (dt != null)
            {
                hospitalMasterDataModel = CommonHelper.ConvertDataTable<ParamedicalHospitalDataModel>(dt);
            }

            return hospitalMasterDataModel;
        }

        public List<ParamedicalHospitalDataModel> GetDataList(int collegeId)
        {
            string SqlQuery = $"exec USP_ParamedicalHospital_IU @CollegeID={collegeId},@Action='GetHospitalByCollegeId'";
            var dt = _commonHelper.Fill_DataTable(SqlQuery, "ParamedicalHospital.GetDataList");

            List<ParamedicalHospitalDataModel> hospitalMasterDataList = new List<ParamedicalHospitalDataModel>();
            if (dt != null)
            {
                hospitalMasterDataList = CommonHelper.ConvertDataTable<List<ParamedicalHospitalDataModel>>(dt);
            }

            return hospitalMasterDataList;
        }

        public bool DeleteData(int hospitalId, int modifiedBy)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            string SqlQuery = $" exec USP_ParamedicalHospital_IU @Action='DeleteHospitalById',@ModifyBy={modifiedBy},@HospitalID={hospitalId},@IPAddress='{IPAddress}'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "ParamedicalHospital.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public List<ParamedicalHospitalBedValidation> GetParamedicalHospitalBedValidation(int CollegeID, int HospitalID)
        {
            List <ParamedicalHospitalBedValidation> dataModels =new List<ParamedicalHospitalBedValidation> ();
            string SqlQuery = "exec USP_GetParamedicalHospitalBedValidation @CollegeID='"+CollegeID+ "',@HospitalID='"+ HospitalID + "'";
            var dataTable = _commonHelper.Fill_DataTable(SqlQuery, "ParamedicalHospital.GetParamedicalHospitalBedValidation");
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string JsonDataTable_Data = CommonHelper.ConvertDataTable(dataTable);
                 dataModels = JsonConvert.DeserializeObject<List<ParamedicalHospitalBedValidation>>(JsonDataTable_Data);
            }
            return dataModels;
        }
    }
}
