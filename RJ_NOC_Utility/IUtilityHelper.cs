using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_DataAccess.Repository;
using RJ_NOC_Utility.CustomerDomain;
using RJ_NOC_Utility.CustomerDomain.Interface;

namespace RJ_NOC_Utility
{
    public interface IUtilityHelper
    {
        ICommonFuncation CommonFuncationUtility { get; }
        IProjectMaster ProjectMasterUtility { get; }
        ILegalEntity LegalEntity { get; }
        IEmployeeLogin EmployeeLoginUtility { get; }
        IEmployeeDashboard EmployeeDashboardUtility { get; }
        IUserMaster UserMasterUtility { get; }
        ISSOAPI SSOAPIUtility { get; }
        IMenu MenuUtility { get; }
        ICourseMaster CourseMasterUtility { get; }
        IWorkFlowMaster WorkFlowMasterUtility { get; }
        ICollegeMaster CollegeMasterUtility { get; }
        IHospitalMaster HospitalMasterUtility { get; }
        ISMSMail SMSMailUtility { get; }

        IParliamentAreaMaster ParliamentAreaMasterUtility { get; }
        ICommonMaster CommonMasterUtility { get; }
        IAssemblyAreaMaster AssemblyAreaMasterUtility { get; }
        IUniversityMaster UniversityMasterUtility { get; }
        ILandAreaSituatedMaster LandAreaSituatedMasterUtility { get; }
        IFacilitiesMaster FacilitiesMasterUtility { get; }
        ISubjectMaster SubjectMasterUtility { get; }
        IQualificationMaster QualificationMasterUtility { get; }
        IDocumentMaster DocumentMasterUtility { get; }
        IAddRoleMaster AddRoleMasterUtility { get; }
        IStaffDetail StaffDetailUtility { get; }
        IHostelDetail HostelDetailUtility { get; }
        ISocietyMaster SocietyMasterUtility { get; }
        IFacilityDetails FacilityDetailsUtility { get; }
        IAcademicInformationDetails AcademicInformationDetailsUtility { get; }
        ILandDetails LandDetailsUtility { get; }
        IRoomDetails RoomDetailsUtility { get; }
        IOtherInformation OtherInformationUtility { get; }
        ICollegeDocument CollegeDocumentUtility { get; }
        IOldNOCDetail OldNOCDetailUtility { get; }
        IBuildingDetailsMaster BuildingDetailsMasterUtility { get; }

        ITrusteeGeneralInfoMaster TrusteeGeneralInfoMasterUtility { get; }
        ICreateUser CreateUserUtility { get; }
        IApplyNOC ApplyNOCUtility { get; }
        IPayment PaymentUtility { get; }
        IApplyNocParameterMaster ApplyNocParameterMasterUtility { get; }
        IGeoTagging GeoTaggingUtility { get; }
        ICommitteeMaster CommitteeMasterUtility { get; }
        IMedicalDocumentScrutiny MedicalDocumentScrutinyUtility { get; }
        IRNCCheckListMaster RNCCheckListMasterUtility { get; }
        IAnimalMaster AnimalMasterUtility { get; }
        IStreamMaster StreamMasterUtility { get; }
        IStreamSubjectMaster StreamSubjectMaster { get; }
        ILoginMaster LoginMasterUtility { get; }

        IVeterinaryHospital VeterinaryHospitalUtility { get; }
        IAadharService AadharServiceUtility { get; }
        IFarmLandDetails FarmLandDetailsUtility { get; }
        IAddCourseMaster AddCourseMasterUtility { get; }
        IParamedicalHospital ParamedicalHospitalUtility { get; }
        IClassWiseStudentDetails ClassWiseStudentDetailsUtility { get; }
        IDepartmentOfCollegeDocumentScrutiny DepartmentOfCollegeScrutinyUtility { get; }

        IAnimalDocumentScrutiny AnimalDocumentScrutinyUtility { get; }
        IAgricultureDocumentScrutiny AgricultureDocumentScrutinyUtility { get; }
        IFireQuery FireQueryUtility { get; }
        IStaffAttendance StaffAttendanceUtility { get; }
        ILOIFeeMaster LOIFeeMasterUtility { get; }
        ISeatInformationMaster SeatInformationMasterUtility { get; }
        IMGOneDocumentScrutiny MGOneScrutinyUtility { get; }
        IGrievance GrievanceUtility { get; }

        IDepartmentOfTechnicalDocumentScrutiny DepartmentOfTechnicalScrutinyUtility { get; }
        IDTECommitteeMaster DTECommitteeMasterUtility { get; }
        IUserManualDocumentMaster UserManualDocumentMasterUtility { get; }
        IActivityDetails ActivityDetailsUtility { get; }
        IDTEStatistics_OfficersDetails DTEStatistics_OfficersDetailsUtility { get; }
        IDTEStatistics_Address DTEStatistics_AddressUtility { get; }
        IDTEStatistics_ResidentialFacility DTEStatistics_ResidentialFacilityUtility { get; }
        IDTEStatistics_RegionalCenters DTEStatistics_RegionalCentersUtility { get; }
        IDTEStatistics_OffShoreCenter DTEStatistics_OffShoreCenterUtility { get; }
        IDTEStatistics_Faculty DTEStatistics_FacultyUtility { get; }
        IDTEStatistics_Department DTEStatistics_DepartmentUtility { get; }
        IDTEStatistics_RegularMode DTEStatistics_RegularModeUtility { get; }
        IDTEStatistics_OtherMinorityData DTEStatistics_OtherMinorityDataUtility { get; }
        //IDTEStatistics_PlacementDetails DTEStatistics_PlacementDetailsUtility { get; }
        //IDTEStatistics_FinancialDetails DTEStatistics_FinancialDetailsUtility { get; }
        //IDTEStatistics_RegularMode DTEStatistics_RegularModeUtility { get; }
    }
}
