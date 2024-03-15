using RJ_NOC_DataAccess.Repositories;
using RJ_NOC_DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJ_NOC_DataAccess.Interface
{
    public interface IRepositories
    {
        ICommonFuncationRepository CommonFuncationRepository { get; }
        IProjectMasterRepository ProjectMasterRepository { get; }
        ILegalEntityRepository LegalEntityRepository { get; }
        IEmployeeLoginRepository EmployeeLoginRepository { get; }
        IEmployeeDashboardRepository EmployeeDashboardRepository { get; }
        IUserMasterRepository UserMasterRepository { get; }
        IMenuRepository MenuRepository { get; }
        ICourseMasterRepository CourseMasterRepository { get; }
        IWorkFlowMasterRepository WorkFlowMasterRepository { get; }         
        ICollegeMasterRepository CollegeMasterRepository { get; }
        IHospitalMasterRepository HospitalMasterRepository { get; }
        ISMSMailRepository SMSMailRepository { get; }
        IParliamentAreaMasterRepository ParliamentAreaMasterRepository { get; }
        ICommonMasterRepository CommonMasterRepository { get; }
        IAssemblyAreaMasterRepository AssemblyAreaMasterRepository { get; }
        IUniversityMasterRepository UniversityMasterRepository { get; }
        ILandAreaSituatedMasterRepository LandAreaSituatedMasterRepository { get; }
        IFacilitiesMasterRepository FacilitiesMasterRepository { get; }
        ISubjectMasterRepository SubjectMasterRepository { get; }
        IQualificationMasterRepository QualificationMasterRepository { get; }
        IDocumentMasterRepository DocumentMasterRepository { get; }
        IAddRoleMasterRepository AddRoleMasterRepository { get; }
        IStaffDetailRepository StaffDetailRepository { get; }
        IHostelDetailRepository HostelDetailRepository { get; }
        ISocietyMasterRepository SocietyMasterRepository { get; }
        IFacilityDetailsRepository FacilityDetailsRepository { get; }
        IAcademicInformationDetailsRepository AcademicInformationDetailsRepository { get; }
        ILandDetailsRepository LandDetailsRepository { get; }
        IRoomDetailsRepository RoomDetailsRepository { get; }
        IOtherInformationRepository OtherInformationRepository { get; }
        ICollegeDocumentRepository CollegeDocumentRepository { get; }
        IOldNOCDetailRepository OldNOCDetailRepository { get; }
        IBuildingDetailsMasterRepository BuildingDetailsMasterRepository { get; }
        ISSOAPIRepository SSOAPIRepository { get; }
        ITrusteeGeneralInfoMasterRepository TrusteeGeneralInfoMasterRepository { get; }
        ICreateUserRepository CreateUserRepository { get; }
        IApplyNOCRepository ApplyNOCRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IApplyNocParameterMasterRepository ApplyNocParameterMasterRepository { get; }
        IGeoTaggingRepository GeoTaggingRepository { get; }
        ICommitteeMasterRepository CommitteeMasterRepository { get; }
        IMedicalDocumentScrutinyRepository MedicalDocumentScrutinyRepository { get; }
        IRNCCheckListMasterRepository RNCCheckListMasterRepository { get; }
        IAnimalMasterRepository AnimalMasterRepository { get; }
        IStreamMasterRepository StreamMasterRepository { get; }

        IStreamSubjectMappingDetailsRepository StreamSubjectMappingDetailsRepository { get; }
        IVeterinaryHospitalRepository VeterinaryHospitalRepository { get; }

        ILoginMasterRepository LoginMasterRepository { get; }
        IFarmLandDetailsRepository FarmLandDetailsRepository { get; }
        IAddCourseMasterRepository AddCourseMasterRepository { get; }

        IParamedicalHospitalRepository ParamedicalHospitalRepository { get; }
        IClassWiseStudentDetailsRepository ClassWiseStudentDetailsRepository { get; }

        IAnimalDocumentScrutinyRepository AnimalDocumentScrutinyRepository { get; }
        IAgricultureDocumentScrutinyRepository AgricultureDocumentScrutinyRepository { get; }

        IDepartmentOfCollegeDocumentScrutinyRepository DepartmentOfCollegeDocumentScrutinyRepository { get; }
        IFireQueryRepository FireQueryRepository { get; }
        IStaffAttendanceRepository StaffAttendanceRepository { get; }
        ILOIFeeMasterRepository LOIFeeMasterRepository { get; }
        ISeatInformationMasterRepository SeatInformationMasterRepository { get; }
        IMGOneDocumentScrutinyRepository MGOneDocumentScrutinyRepository { get; }
        IGrievanceRepository GrievanceRepository { get; }
        IDepartmentOfTechnicalDocumentScrutinyRepository DepartmentOfTechnicalDocumentScrutinyRepository { get; }
        IDTECommitteeMasterRepository DTECommitteeMasterRepository { get; }
        IUserManualDocumentMasterRepository UserManualDocumentMasterRepository { get; }
        IActivityDetailsRepository ActivityDetailsRepository { get; }
        IDTEStatistics_OfficersDetailsRepository DTEStatistics_OfficersDetailsRepository { get; }
        IDTEStatistics_AddressRepository DTEStatistics_AddressRepository { get; }
        IDTEStatistics_ResidentialFacilityRepository DTEStatistics_ResidentialFacilityRepository { get; }
        IDTEStatistics_RegionalCentersRepository DTEStatistics_RegionalCentersRepository { get; }
        IDTEStatistics_OffShoreCenterRepository DTEStatistics_OffShoreCenterRepository { get; }
        IDTEStatistics_FacultyRepository DTEStatistics_FacultyRepository { get; }
        IDTEStatistics_DepartmentRepository DTEStatistics_DepartmentRepository { get; }
        IDTEStatistics_RegularModeRepository DTEStatistics_RegularModeRepository { get; }
    }
}
