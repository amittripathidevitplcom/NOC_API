using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using RJ_NOC_DataAccess.Common;
using RJ_NOC_DataAccess.Repositories;
using System.Diagnostics;

namespace RJ_NOC_DataAccess.Repository
{
    public class CoreRepositories : IRepositories
    {

        protected CommonDataAccessHelper CommonHelper { get; set; }
        public CoreRepositories(IConfiguration configuration)
        {
            CommonHelper = new CommonDataAccessHelper(configuration);
            IntializeRepositories(CommonHelper);
        }




        private ICommonFuncationRepository commonFuncationRepository;
        public ICommonFuncationRepository CommonFuncationRepository
        {
            get { return commonFuncationRepository; }
        }
        private IProjectMasterRepository projectMasterRepository;
        public IProjectMasterRepository ProjectMasterRepository
        {
            get { return projectMasterRepository; }
        }

        private IEmployeeLoginRepository employeeLoginRepository;
        public IEmployeeLoginRepository EmployeeLoginRepository
        {
            get { return employeeLoginRepository; }
        }


        private IEmployeeDashboardRepository employeeDashboardRepository;
        public IEmployeeDashboardRepository EmployeeDashboardRepository
        {
            get { return employeeDashboardRepository; }
        }


        private IUserMasterRepository userMasterRepository;
        public IUserMasterRepository UserMasterRepository
        {
            get { return userMasterRepository; }
        }

        private IMenuRepository menuRepository;
        public IMenuRepository MenuRepository
        {
            get { return menuRepository; }
        }

        private ICollegeMasterRepository _collegeMasterRepository;
        public ICollegeMasterRepository CollegeMasterRepository
        {
            get
            {
                if (_collegeMasterRepository == null)
                    _collegeMasterRepository = new CollegeMasterRepository(CommonHelper);
                return _collegeMasterRepository;
            }
        }

        private IHospitalMasterRepository _HospitalMasterRepository;
        public IHospitalMasterRepository HospitalMasterRepository
        {
            get
            {
                if (_HospitalMasterRepository == null)
                    _HospitalMasterRepository = new HospitalMasterRepository(CommonHelper);
                return _HospitalMasterRepository;
            }
        }

        private ILegalEntityRepository legalEntityRepository;
        public ILegalEntityRepository LegalEntityRepository
        {
            get { return legalEntityRepository; }
        }

        private ICourseMasterRepository courseMasterRepository;
        public ICourseMasterRepository CourseMasterRepository
        {
            get { return courseMasterRepository; }
        }

        private IWorkFlowMasterRepository workFlowMasterRepository;
        public IWorkFlowMasterRepository WorkFlowMasterRepository
        {
            get { return workFlowMasterRepository; }
        }
        private ISMSMailRepository sMSMailRepository;
        public ISMSMailRepository SMSMailRepository
        {
            get { return sMSMailRepository; }
        }

        private IParliamentAreaMasterRepository parliamentAreaMasterRepository;
        public IParliamentAreaMasterRepository ParliamentAreaMasterRepository
        {
            get { return parliamentAreaMasterRepository; }
        }
        private ICommonMasterRepository commonMasterRepository;
        public ICommonMasterRepository CommonMasterRepository
        {
            get { return commonMasterRepository; }
        }
        private IAssemblyAreaMasterRepository assemblyAreaMasterRepository;
        public IAssemblyAreaMasterRepository AssemblyAreaMasterRepository
        {
            get { return assemblyAreaMasterRepository; }
        }

        private IUniversityMasterRepository universityMasterRepository;
        public IUniversityMasterRepository UniversityMasterRepository
        {
            get { return universityMasterRepository; }
        }
        private ILandAreaSituatedMasterRepository landAreaSituatedMasterRepository;
        public ILandAreaSituatedMasterRepository LandAreaSituatedMasterRepository
        {
            get { return landAreaSituatedMasterRepository; }
        }
        private IFacilitiesMasterRepository facilitiesMasterRepository;
        public IFacilitiesMasterRepository FacilitiesMasterRepository
        {
            get { return facilitiesMasterRepository; }
        }
        private ISubjectMasterRepository subjectMasterRepository;
        public ISubjectMasterRepository SubjectMasterRepository
        {
            get { return subjectMasterRepository; }
        }
        private IQualificationMasterRepository qualificationMasterRepository;
        public IQualificationMasterRepository QualificationMasterRepository
        {
            get { return qualificationMasterRepository; }
        }

        private IDocumentMasterRepository documentMasterRepository;
        public IDocumentMasterRepository DocumentMasterRepository
        {
            get { return documentMasterRepository; }
        }
        private IAddRoleMasterRepository addRoleMasterRepository;
        public IAddRoleMasterRepository AddRoleMasterRepository
        {
            get { return addRoleMasterRepository; }
        }


        private IStaffDetailRepository staffDetailRepository;
        public IStaffDetailRepository StaffDetailRepository
        {
            get { return staffDetailRepository; }
        }

        private IHostelDetailRepository hostelDetailRepository;
        public IHostelDetailRepository HostelDetailRepository
        {
            get { return hostelDetailRepository; }
        }
        private ISocietyMasterRepository societyMasterRepository;
        public ISocietyMasterRepository SocietyMasterRepository
        {
            get { return societyMasterRepository; }
        }
        private IFacilityDetailsRepository facilityDetailsRepository;
        public IFacilityDetailsRepository FacilityDetailsRepository
        {
            get { return facilityDetailsRepository; }
        }
        private IAcademicInformationDetailsRepository academicInformationDetailsRepository;
        public IAcademicInformationDetailsRepository AcademicInformationDetailsRepository
        {
            get { return academicInformationDetailsRepository; }
        }


        private ILandDetailsRepository landDetailsRepository;
        public ILandDetailsRepository LandDetailsRepository
        {
            get { return landDetailsRepository; }
        }
        private IRoomDetailsRepository roomDetailsRepository;
        public IRoomDetailsRepository RoomDetailsRepository
        {
            get { return roomDetailsRepository; }
        }
        private IOtherInformationRepository otherInformationRepository;
        public IOtherInformationRepository OtherInformationRepository
        {
            get { return otherInformationRepository; }
        }

        private ICollegeDocumentRepository collegeDocumentRepository;
        public ICollegeDocumentRepository CollegeDocumentRepository
        {
            get { return collegeDocumentRepository; }
        }

        private IOldNOCDetailRepository oldNOCDetailRepository;
        public IOldNOCDetailRepository OldNOCDetailRepository
        {
            get { return oldNOCDetailRepository; }
        }
        private IBuildingDetailsMasterRepository buildingDetailsMasterRepository;
        public IBuildingDetailsMasterRepository BuildingDetailsMasterRepository
        {
            get { return buildingDetailsMasterRepository; }
        }
         private ISSOAPIRepository sSOAPIRepository;
        public ISSOAPIRepository SSOAPIRepository
        {
            get { return sSOAPIRepository; }
        }
        private ITrusteeGeneralInfoMasterRepository _TrusteeGeneralInfoMasterRepository;
        public ITrusteeGeneralInfoMasterRepository TrusteeGeneralInfoMasterRepository
        {
            get
            {
                if (_TrusteeGeneralInfoMasterRepository == null)
                    _TrusteeGeneralInfoMasterRepository = new TrusteeGeneralInfoMasterRepository(CommonHelper);
                return _TrusteeGeneralInfoMasterRepository;
            }
        }
        private ICreateUserRepository createUserRepository;
        public ICreateUserRepository CreateUserRepository
        {
            get { return createUserRepository; }
        }
        private IApplyNOCRepository applyNOCRepository;
        public IApplyNOCRepository ApplyNOCRepository
        {
            get { return applyNOCRepository; }
        }
        private IPaymentRepository paymentRepository;
        public IPaymentRepository PaymentRepository
        {
            get { return paymentRepository; }
        }
        private IGeoTaggingRepository geoTaggingRepository;
        public IGeoTaggingRepository GeoTaggingRepository
        {
            get { return geoTaggingRepository; }
        }
        private IMedicalDocumentScrutinyRepository medicalDocumentScrutinyRepository;
        public IMedicalDocumentScrutinyRepository MedicalDocumentScrutinyRepository
        {
            get { return medicalDocumentScrutinyRepository; }
        }

        private IApplyNocParameterMasterRepository _ApplyNocParameterMasterRepository;
        public IApplyNocParameterMasterRepository ApplyNocParameterMasterRepository
        {
            get
            {
                if (_ApplyNocParameterMasterRepository == null)
                {
                    _ApplyNocParameterMasterRepository = new ApplyNocParameterMasterRepository(CommonHelper);
                }
                return _ApplyNocParameterMasterRepository;
            }
        }
        //private IScurtenyComitteeRepository scurtenyComitteeRepository;
        //public IScurtenyComitteeRepository ScurtenyComitteeRepository
        //{
        //    get { return scurtenyComitteeRepository; }
        //}
        

        private ICommitteeMasterRepository committeeMasterRepository;
        public ICommitteeMasterRepository CommitteeMasterRepository
        {
            get { return committeeMasterRepository; }
        }
        private IRNCCheckListMasterRepository rNCCheckListMasterRepository;
        public IRNCCheckListMasterRepository RNCCheckListMasterRepository
        {
            get { return rNCCheckListMasterRepository; }
        }

        private IStreamSubjectMappingDetailsRepository streamsubjectmappingdetailsrepository;
        public IStreamSubjectMappingDetailsRepository StreamSubjectMappingDetailsRepository
        {
            get { return streamsubjectmappingdetailsrepository; }
        }

        private IAnimalMasterRepository animalMasterRepository;
        public IAnimalMasterRepository AnimalMasterRepository
        {
            get { return animalMasterRepository; }
        }
        private IStreamMasterRepository streamMasterRepository;
        public IStreamMasterRepository StreamMasterRepository
        {
            get { return streamMasterRepository; }
        }
        private IVeterinaryHospitalRepository veterinaryHospitalRepository;
        public IVeterinaryHospitalRepository VeterinaryHospitalRepository
        {
            get { return veterinaryHospitalRepository; }
        }
        private ILoginMasterRepository loginMasterRepository;
        public ILoginMasterRepository LoginMasterRepository
        {
            get { return loginMasterRepository; }
        }

        private IFarmLandDetailsRepository farmLandDetailsRepository;
        public IFarmLandDetailsRepository FarmLandDetailsRepository
        {
            get { return farmLandDetailsRepository; }
        }

        private IAddCourseMasterRepository addCourseMasterRepository;
        public IAddCourseMasterRepository AddCourseMasterRepository
        {
            get { return addCourseMasterRepository; }
        }


        private IParamedicalHospitalRepository paramedicalHospitalRepository;
        public IParamedicalHospitalRepository ParamedicalHospitalRepository
        {
            get { return paramedicalHospitalRepository; }
        }

        private IClassWiseStudentDetailsRepository classwisestudentdetailsrepository;
        public IClassWiseStudentDetailsRepository ClassWiseStudentDetailsRepository
        {
            get { return classwisestudentdetailsrepository; }
        }

        private IAnimalDocumentScrutinyRepository animalDocumentScrutinyRepository;
        public IAnimalDocumentScrutinyRepository AnimalDocumentScrutinyRepository
        {
            get { return animalDocumentScrutinyRepository; }
        }
        private IAgricultureDocumentScrutinyRepository agricultureDocumentScrutinyRepository;
        public IAgricultureDocumentScrutinyRepository AgricultureDocumentScrutinyRepository
        {
            get { return agricultureDocumentScrutinyRepository; }
        }

        private IDepartmentOfCollegeDocumentScrutinyRepository departmentofcollegedocumentscrutinyrepository;
        public IDepartmentOfCollegeDocumentScrutinyRepository DepartmentOfCollegeDocumentScrutinyRepository
        {
            get { return departmentofcollegedocumentscrutinyrepository; }
        }
        private IFireQueryRepository fireQueryRepository;
        public IFireQueryRepository FireQueryRepository
        {
            get { return fireQueryRepository; }
        }
        private IStaffAttendanceRepository staffAttendanceRepository;
        public IStaffAttendanceRepository StaffAttendanceRepository
        {
            get { return staffAttendanceRepository; }
        }
        private ILOIFeeMasterRepository LoiFeeMasterRepository;
        public ILOIFeeMasterRepository LOIFeeMasterRepository
        {
            get { return LoiFeeMasterRepository; }
        }
        private ISeatInformationMasterRepository seatInformationMasterRepository;
        public ISeatInformationMasterRepository SeatInformationMasterRepository
        {
            get { return seatInformationMasterRepository; }
        }       
        private IMGOneDocumentScrutinyRepository mgoneDocumentScrutinyRepository;
        public IMGOneDocumentScrutinyRepository MGOneDocumentScrutinyRepository
        {
            get { return mgoneDocumentScrutinyRepository; }
        }
        
        private IGrievanceRepository grievanceRepository;
        public IGrievanceRepository GrievanceRepository
        {
            get { return grievanceRepository; }
        }

         private IDTECommitteeMasterRepository dTECommitteeMasterRepository;
        public IDTECommitteeMasterRepository DTECommitteeMasterRepository
        {
            get { return dTECommitteeMasterRepository; }
        }


        private IDepartmentOfTechnicalDocumentScrutinyRepository departmentoftechnicaldocumentscrutinyrepository;
        public IDepartmentOfTechnicalDocumentScrutinyRepository DepartmentOfTechnicalDocumentScrutinyRepository
        {
            get { return departmentoftechnicaldocumentscrutinyrepository; }
        }      
        private IUserManualDocumentMasterRepository userManualDocumentMasterRepository;
        public IUserManualDocumentMasterRepository UserManualDocumentMasterRepository
        {
            get { return userManualDocumentMasterRepository; }
        }

        private IActivityDetailsRepository activityDetailsRepository;
        public IActivityDetailsRepository ActivityDetailsRepository
        {
            get { return activityDetailsRepository; }
        }

        private IDTEStatistics_OfficersDetailsRepository dTEStatistics_OfficersDetailsRepository;
        public IDTEStatistics_OfficersDetailsRepository DTEStatistics_OfficersDetailsRepository
        {
            get { return dTEStatistics_OfficersDetailsRepository; }
        }
        
        private IDTEStatistics_AddressRepository dTEStatistics_AddressRepository;
        public IDTEStatistics_AddressRepository DTEStatistics_AddressRepository
        {
            get { return dTEStatistics_AddressRepository; }
        }
        
        private IDTEStatistics_ResidentialFacilityRepository dTEStatistics_ResidentialFacilityRepository;
        public IDTEStatistics_ResidentialFacilityRepository DTEStatistics_ResidentialFacilityRepository
        {
            get { return dTEStatistics_ResidentialFacilityRepository; }
        }
        private IDTEStatistics_RegionalCentersRepository dTEStatistics_RegionalCentersRepository;
        public IDTEStatistics_RegionalCentersRepository DTEStatistics_RegionalCentersRepository
        {
            get { return dTEStatistics_RegionalCentersRepository; }
        }
        
        private IDTEStatistics_OffShoreCenterRepository dTEStatistics_OffShoreCenterRepository;
        public IDTEStatistics_OffShoreCenterRepository DTEStatistics_OffShoreCenterRepository
        {
            get { return dTEStatistics_OffShoreCenterRepository; }
        }
        private IDTEStatistics_FacultyRepository dTEStatistics_FacultyRepository;
        public IDTEStatistics_FacultyRepository DTEStatistics_FacultyRepository
        {
            get { return dTEStatistics_FacultyRepository; }
        }
        private IDTEStatistics_DepartmentRepository dTEStatistics_DepartmentRepository;
        public IDTEStatistics_DepartmentRepository DTEStatistics_DepartmentRepository
        {
            get { return dTEStatistics_DepartmentRepository; }
        }
        
        private IDTEStatistics_RegularModeRepository dTEStatistics_RegularModeRepository;
        public IDTEStatistics_RegularModeRepository DTEStatistics_RegularModeRepository
        {
            get { return dTEStatistics_RegularModeRepository; }
        }
        private IDTEStatistics_PlacementDetailsRepository dTEStatistics_PlacementDetailsRepository;
        public IDTEStatistics_PlacementDetailsRepository DTEStatistics_PlacementDetailsRepository
        {
            get { return dTEStatistics_PlacementDetailsRepository; }
        }
        
        private IDTEStatistics_FinancialDetailsRepository dTEStatistics_FinancialDetailsRepository;
        public IDTEStatistics_FinancialDetailsRepository DTEStatistics_FinancialDetailsRepository
        {
            get { return dTEStatistics_FinancialDetailsRepository; }
        }
        
        private IDTEStatistics_InfrastructureDetailsRepository dTEStatistics_InfrastructureDetailsRepository;
        public IDTEStatistics_InfrastructureDetailsRepository DTEStatistics_InfrastructureDetailsRepository
        {
            get { return dTEStatistics_InfrastructureDetailsRepository; }
        }
        private IDTEStatistics_RegulatoryInformationRepository dTEStatistics_RegulatoryInformationRepository;
        public IDTEStatistics_RegulatoryInformationRepository DTEStatistics_RegulatoryInformationRepository
        {
            get { return dTEStatistics_RegulatoryInformationRepository; }
        }
        private IDTEStatistics_StudentEnrollmentDistanceModeRepository dTEStatistics_StudentEnrollmentDistanceModeRepository;
        public IDTEStatistics_StudentEnrollmentDistanceModeRepository DTEStatistics_StudentEnrollmentDistanceModeRepository
        {
            get { return dTEStatistics_StudentEnrollmentDistanceModeRepository; }
        }
        private IDTEStatistics_RegularForeignStudentEnrolmentRepository dTEStatistics_RegularForeignStudentEnrolmentRepository;
        public IDTEStatistics_RegularForeignStudentEnrolmentRepository DTEStatistics_RegularForeignStudentEnrolmentRepository
        {
            get { return dTEStatistics_RegularForeignStudentEnrolmentRepository; }
        }
        private IDTEStatistics_ExaminationResultsRepository dTEStatistics_ExaminationResultsRepository;
        public IDTEStatistics_ExaminationResultsRepository DTEStatistics_ExaminationResultsRepository
        {
            get { return dTEStatistics_ExaminationResultsRepository; }
        }
        private IDTEStatistics_ScholarshipFellowshipLoanAccRepository dTEStatistics_ScholarshipFellowshipLoanAccRepository;
        public IDTEStatistics_ScholarshipFellowshipLoanAccRepository DTEStatistics_ScholarshipFellowshipLoanAccRepository
        {
            get { return dTEStatistics_ScholarshipFellowshipLoanAccRepository; }
        }
        /// <summary>
        /// /////////
        /// </summary>
        /// <param name="commonHelper"></param>
        public void IntializeRepositories(CommonDataAccessHelper commonHelper)
        {
            commonFuncationRepository = new CommonFuncationRepository(commonHelper);
            projectMasterRepository = new ProjectMasterRepository(commonHelper);
            legalEntityRepository = new LegalEntityRepository(commonHelper);
            employeeLoginRepository = new EmployeeLoginRepository(commonHelper);
            employeeDashboardRepository = new EmployeeDashboardRepository(commonHelper);
            userMasterRepository = new UserMasterRepository(commonHelper);
            menuRepository = new MenuRepository(commonHelper);
            workFlowMasterRepository = new WorkFlowMasterRepository(commonHelper);
            courseMasterRepository = new CourseMasterRepository(commonHelper);
            sMSMailRepository = new SMSMailRepository(commonHelper);
            parliamentAreaMasterRepository = new ParliamentAreaMasterRepository(commonHelper);
            commonMasterRepository = new CommonMasterRepository(commonHelper);
            assemblyAreaMasterRepository = new AssemblyAreaMasterRepository(commonHelper);
            universityMasterRepository = new UniversityMasterRepository(commonHelper);
            landAreaSituatedMasterRepository = new LandAreaSituatedMasterRepository(commonHelper);
            facilitiesMasterRepository = new FacilitiesMasterRepository(commonHelper);
            qualificationMasterRepository = new QualificationMasterRepository(commonHelper);
            facilitiesMasterRepository = new FacilitiesMasterRepository(commonHelper);
            subjectMasterRepository = new SubjectMasterRepository(commonHelper);
            documentMasterRepository = new DocumentMasterRepository(commonHelper);
            addRoleMasterRepository = new AddRoleMasterRepository(commonHelper);
            hostelDetailRepository = new HostelDetailRepository(commonHelper);
            staffDetailRepository = new StaffDetailRepository(commonHelper);
            societyMasterRepository = new SocietyMasterRepository(commonHelper);
            facilityDetailsRepository = new FacilityDetailsRepository(commonHelper);
            academicInformationDetailsRepository = new AcademicInformationDetailsRepository(commonHelper);
            landDetailsRepository = new LandDetailsRepository(commonHelper);
            roomDetailsRepository = new RoomDetailsRepository(commonHelper);
            otherInformationRepository = new OtherInformationRepository(commonHelper);
            collegeDocumentRepository = new CollegeDocumentRepository(commonHelper);
            oldNOCDetailRepository = new OldNOCDetailRepository(commonHelper);
            buildingDetailsMasterRepository = new BuildingDetailsMasterRepository(commonHelper);
            sSOAPIRepository = new SSOAPIRepository(commonHelper);
            createUserRepository = new CreateUserRepository(commonHelper);
            applyNOCRepository = new ApplyNOCRepository(commonHelper);
            paymentRepository = new PaymentRepository(commonHelper);
            geoTaggingRepository = new GeoTaggingRepository(commonHelper);
            committeeMasterRepository = new CommitteeMasterRepository(commonHelper);
            medicalDocumentScrutinyRepository = new MedicalDocumentScrutinyRepository(commonHelper);
            //scurtenyComitteeRepository = new ScurtenyComitteeRepository(commonHelper);
            rNCCheckListMasterRepository = new RNCCheckListMasterRepository(commonHelper);
            animalMasterRepository = new AnimalMasterRepository(commonHelper);
            streamMasterRepository = new StreamMasterRepository(commonHelper);
            
            loginMasterRepository = new LoginMasterRepository(commonHelper); 
            veterinaryHospitalRepository = new VeterinaryHospitalRepository(commonHelper);
            streamsubjectmappingdetailsrepository = new  StreamSubjectMappingDetailsRepository(commonHelper);
            farmLandDetailsRepository = new  FarmLandDetailsRepositories(commonHelper);
            addCourseMasterRepository = new AddCourseMasterRepository(commonHelper);
            paramedicalHospitalRepository = new  ParamedicalHospitalRepository(commonHelper);
            classwisestudentdetailsrepository = new  ClassWiseStudentDetailsRepository(commonHelper);
            animalDocumentScrutinyRepository = new AnimalDocumentScrutinyRepository(commonHelper);
            agricultureDocumentScrutinyRepository = new AgricultureDocumentScrutinyRepository(commonHelper);
            departmentofcollegedocumentscrutinyrepository = new DepartmentOfCollegeDocumentScrutinyRepository(commonHelper);
            fireQueryRepository = new FireQueryRepository(commonHelper);
            staffAttendanceRepository = new StaffAttendanceRepository(commonHelper);
            LoiFeeMasterRepository = new LOIFeeMasterRepository(commonHelper);
            seatInformationMasterRepository = new SeatInformationMasterRepository(commonHelper);
            mgoneDocumentScrutinyRepository = new MGOneDocumentScrutinyRepository(commonHelper);
            grievanceRepository = new GrievanceRepository(commonHelper);
            departmentoftechnicaldocumentscrutinyrepository = new DepartmentOfTechnicalDocumentScrutinyRepository(commonHelper);
            dTECommitteeMasterRepository = new DTECommitteeMasterRepository(commonHelper);
            userManualDocumentMasterRepository = new UserManualDocumentMasterRepository(commonHelper);
            activityDetailsRepository = new ActivityDetailsRepository(commonHelper);
            dTEStatistics_OfficersDetailsRepository = new DTEStatistics_OfficersDetailsRepository(commonHelper);
            dTEStatistics_AddressRepository = new DTEStatistics_AddressRepository(commonHelper);
            dTEStatistics_ResidentialFacilityRepository = new DTEStatistics_ResidentialFacilityRepository(commonHelper);
            dTEStatistics_RegionalCentersRepository = new DTEStatistics_RegionalCentersRepository(commonHelper);
            dTEStatistics_OffShoreCenterRepository = new DTEStatistics_OffShoreCenterRepository(commonHelper);
            dTEStatistics_FacultyRepository = new DTEStatistics_FacultyRepository(commonHelper);
            dTEStatistics_DepartmentRepository = new DTEStatistics_DepartmentRepository(commonHelper);
            dTEStatistics_RegularModeRepository = new DTEStatistics_RegularModeRepository(commonHelper);
            dTEStatistics_PlacementDetailsRepository = new DTEStatistics_PlacementDetailsRepository(commonHelper);
            dTEStatistics_FinancialDetailsRepository = new DTEStatistics_FinancialDetailsRepository(commonHelper);
            dTEStatistics_InfrastructureDetailsRepository = new DTEStatistics_InfrastructureDetailsRepository(commonHelper);
            dTEStatistics_RegulatoryInformationRepository = new DTEStatistics_RegulatoryInformationRepository(commonHelper);
            dTEStatistics_StudentEnrollmentDistanceModeRepository = new DTEStatistics_StudentEnrollmentDistanceModeRepository(commonHelper);
            dTEStatistics_RegularForeignStudentEnrolmentRepository = new DTEStatistics_RegularForeignStudentEnrolmentRepository(commonHelper);
            dTEStatistics_ExaminationResultsRepository = new DTEStatistics_ExaminationResultsRepository(commonHelper);
            dTEStatistics_ScholarshipFellowshipLoanAccRepository = new DTEStatistics_ScholarshipFellowshipLoanAccRepository(commonHelper);
        }
    }
}
