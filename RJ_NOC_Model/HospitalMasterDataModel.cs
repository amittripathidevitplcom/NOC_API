using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class HospitalMasterDataModel
    {
        public int ParentHospitalID { get; set; }        
        public int CollegeID { get; set; }
        public int HospitalID { get; set; }
        public int HospitalAreaID { get; set; }
        public string? HospitalAreaName { get; set; }
        public string HospitalName { get; set; }
        public string HospitalRegNo { get; set; }
        public int HospitalDistance { get; set; }
        public string HospitalContactNo { get; set; }
        public string HospitalEmailID { get; set; }
        public string ManageByName { get; set; }
        public string ManageByPhone { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public int MedicalBeds { get; set; }
        public int SurgicalBeds { get; set; }
        public int ObstAndGynaecologyBeds { get; set; }
        public int PediatricsBeds { get; set; }
        public int OrthoBeds { get; set; }
        public int OccupancyPercentegeBeds { get; set; }
        public int AffiliationPsychiatricBeds { get; set; }
        public int? ParentHospitalRelatedToOtherID { get; set; }
        public string? InstitutionName { get; set; }
        public string? OrganizationPhone { get; set; }

        public int CardioThoracicTotalBeds { get; set; }
        public int CardioThoracicCCUBeds { get; set; }
        public int CardioThoracicICCUBeds { get; set; }
        public int CardioThoracicICUBeds { get; set; }
        public int CriticalCareNursingTotalBeds { get; set; }
        public int CriticalCareNursingCCBeds { get; set; }
        public int CriticalCareNursingICUBeds { get; set; }
        public int MidwiferyNursingTotalBeds { get; set; }
        public int MotherNeonatalUnitsBeds { get; set; }
        public int DeliveriesPerYear { get; set; }
        public int LevelIINeonatalBeds { get; set; }
        public int LevelIIINeonatalBeds { get; set; }
        public int NeuroScienceNursingTotalBeds { get; set; }
        public int OncologyNursingTotalBeds { get; set; }
        public int OncologyNursingMedicalBeds { get; set; }
        public int OncologyNurSingsurgicalBeds { get; set; }
        public int OncologyNursingChemotherapyBeds { get; set; }
        public int OncologyNursingRadiotherapyBeds { get; set; }
        public int OncologyNursingPalliativeBeds { get; set; }
        public int OncologyNursingDiagnosticBeds { get; set; }
        public int OrthopaedicRehabilitationNursingTotalBeds { get; set; }
        public int OrthopaedicRehabilitationNursingOrthopaedicBeds { get; set; }
        public int OrthopaedicRehabilitationNursingRehabilitationBeds { get; set; }
        public int PsychiatricNursingTotalBeds { get; set; }
        public int PsychiatricNursingAcuteBeds { get; set; }
        public int PsychiatricNursingChronicBeds { get; set; }
        public int PsychiatricNursingAdultBeds { get; set; }
        public int PsychiatricNursingChildBeds { get; set; }
        public int PsychiatricNursingDeAddictionBeds { get; set; }
        public int NeonatalNursingTotalBeds { get; set; }
        public int NeonatalNursingLevelIIOrIIINICUBeds { get; set; }
        public int NeonatalNursingNICUBeds { get; set; }
        public int OperationRoomNursingTotalBeds { get; set; }
        public int OperationRoomNursingGeneralSurgeryBeds { get; set; }
        public int OperationRoomNursingPediatricBeds { get; set; }
        public int OperationRoomNursingCardiothoracicBeds { get; set; }
        public int OperationRoomNursingGynaeAndObstetricalBeds { get; set; }
        public int OperationRoomNursingOrthopaedicsBeds { get; set; }
        public int OperationRoomNursingOphthalmicBeds { get; set; }
        public int OperationRoomNursingENTAndNeuroBeds { get; set; }
        public int EmergencyAndDisasterNursingTotalBeds { get; set; }
        public int EmergencyAndDisasterNursingICUBeds { get; set; }
        public int EmergencyAndDisasterNursingEmergencylBeds { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int RuralUrban { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public int TehsilID { get; set; }
        public int PanchayatSamitiID { get; set; }
        public string CityTownVillage { get; set; }
        public int Pincode { get; set; }

        public string AddressLine1_ManageBy { get; set; }
        public string AddressLine2_ManageBy { get; set; }
        public int RuralUrban_ManageBy { get; set; }
        public int DivisionID_ManageBy { get; set; }
        public int DistrictID_ManageBy { get; set; }
        public int TehsilID_ManageBy { get; set; }
        public int PanchayatSamitiID_ManageBy { get; set; }
        public string CityTownVillage_ManageBy { get; set; }
        public int Pincode_ManageBy { get; set; }

        public string AddressLine1_Owner { get; set; }
        public string AddressLine2_Owner { get; set; }
        public int RuralUrban_Owner { get; set; }
        public int DivisionID_Owner { get; set; }
        public int DistrictID_Owner { get; set; }
        public int TehsilID_Owner { get; set; }
        public int PanchayatSamitiID_Owner { get; set; }
        public string CityTownVillage_Owner { get; set; }
        public int Pincode_Owner { get; set; }

        public string? AddressLine1_Other { get; set; }
        public string? AddressLine2_Other { get; set; }
        public int? RuralUrban_Other { get; set; }
        public int? DivisionID_Other { get; set; }
        public int? DistrictID_Other { get; set; }
        public int? TehsilID_Other { get; set; }
        public int? PanchayatSamitiID_Other { get; set; }
        public string? CityTownVillage_Other { get; set; }
        public int? Pincode_Other { get; set; }

        public int? AffiliatedHospitalAffiliationToOtherID { get; set; }
        public string? ParentNotDocument { get; set; }
        public string? ConsentForm { get; set; }

        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }
        public string? IPAddress { get; set; }
    }
    public class HospitalAreaValidation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
