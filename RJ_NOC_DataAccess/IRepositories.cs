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
    }
}
