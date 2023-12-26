using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_Utility.CustomerDomain;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_Utility;
using RJ_NOC_DataAccess.Interface;
using RJ_NOC_DataAccess.Repository;
using Microsoft.Extensions.Configuration;

using RJ_NOC_DataAccess.Repositories;

namespace RJ_NOC_Utility
{
    public class UtilityHelper : IUtilityHelper
    {

        // utilities
        public IRepositories UnitOfWork;

        public ICommonFuncation CommonFuncationUtility { get; private set; }
        public IProjectMaster ProjectMasterUtility { get; private set; }
        public ILegalEntity LegalEntity { get; private set; }
        public IEmployeeLogin EmployeeLoginUtility { get; private set; }
        public IEmployeeDashboard EmployeeDashboardUtility { get; private set; }
        public IUserMaster UserMasterUtility { get; private set; }
        public ISSOAPI SSOAPIUtility { get; private set; }
        public IMenu MenuUtility { get; private set; }
        public ICourseMaster CourseMasterUtility { get; private set; }
        public IWorkFlowMaster WorkFlowMasterUtility { get; private set; }
        public ICollegeMaster CollegeMasterUtility { get; private set; }
        public IHospitalMaster HospitalMasterUtility { get; private set; }
        public ISMSMail SMSMailUtility { get; private set; }
        public IParliamentAreaMaster ParliamentAreaMasterUtility { get; private set; }
        public ICommonMaster CommonMasterUtility { get; private set; }
        public IAssemblyAreaMaster AssemblyAreaMasterUtility { get; private set; }
        public IUniversityMaster UniversityMasterUtility { get; private set; }
        public ILandAreaSituatedMaster LandAreaSituatedMasterUtility { get; private set; }
        public IFacilitiesMaster FacilitiesMasterUtility { get; private set; }
        public ISubjectMaster SubjectMasterUtility { get; private set; }


        public IQualificationMaster QualificationMasterUtility { get; private set; }
        public IDocumentMaster DocumentMasterUtility { get; private set; }
        public IAddRoleMaster AddRoleMasterUtility { get; private set; }
        public IStaffDetail StaffDetailUtility { get; private set; }
        public IHostelDetail HostelDetailUtility { get; private set; }

        public ISocietyMaster SocietyMasterUtility { get; private set; }
        public IFacilityDetails FacilityDetailsUtility { get; private set; }
        public IAcademicInformationDetails AcademicInformationDetailsUtility { get; private set; }
        public ILandDetails LandDetailsUtility { get; private set; }

        public IRoomDetails RoomDetailsUtility { get; private set; }
        public IOtherInformation OtherInformationUtility { get; private set; }
        public ICollegeDocument CollegeDocumentUtility { get; private set; }
        public IOldNOCDetail OldNOCDetailUtility { get; private set; }

        public IBuildingDetailsMaster BuildingDetailsMasterUtility { get; private set; }


        public ITrusteeGeneralInfoMaster TrusteeGeneralInfoMasterUtility { get; private set; }
        public ICreateUser CreateUserUtility { get; private set; }

        public IApplyNOC ApplyNOCUtility { get; private set; }
        public IPayment PaymentUtility { get; private set; }
        public IGeoTagging GeoTaggingUtility { get; private set; }

        public IMedicalDocumentScrutiny MedicalDocumentScrutinyUtility { get; private set; }


        private IApplyNocParameterMaster _ApplyNocParameterMasterUtility;
      
        public IApplyNocParameterMaster ApplyNocParameterMasterUtility 
        {
            get
            {
                if(_ApplyNocParameterMasterUtility == null)
                {
                    _ApplyNocParameterMasterUtility = new ApplyNocParameterMaster(UnitOfWork);
                }
                return _ApplyNocParameterMasterUtility;
            }
        }
        public ICommitteeMaster CommitteeMasterUtility { get; private set; }
        public IRNCCheckListMaster RNCCheckListMasterUtility { get; private set; }

        public IStreamSubjectMaster StreamSubjectMaster { get; private set; }

        public IAnimalMaster AnimalMasterUtility { get; private set; }
        public IStreamMaster StreamMasterUtility { get; private set; }
        public IVeterinaryHospital VeterinaryHospitalUtility { get; private set; }

        public ILoginMaster LoginMasterUtility { get; private set; }

        public IAadharService AadharServiceUtility { get; private set; }
        public IFarmLandDetails FarmLandDetailsUtility { get; private set; }
        public IAddCourseMaster AddCourseMasterUtility { get; private set; }

        public IParamedicalHospital ParamedicalHospitalUtility { get; private set; }

        public IClassWiseStudentDetails ClassWiseStudentDetailsUtility { get; private set; }
        public IAnimalDocumentScrutiny AnimalDocumentScrutinyUtility { get; private set; }
        public IAgricultureDocumentScrutiny AgricultureDocumentScrutinyUtility { get; private set; }
        public IFireQuery FireQueryUtility { get; private set; }

        public IDepartmentOfCollegeDocumentScrutiny DepartmentOfCollegeScrutinyUtility { get; private set; }
        public IStaffAttendance StaffAttendanceUtility { get; private set; }
        public ILOIFeeMaster LOIFeeMasterUtility { get; private set; }
        public ISeatInformationMaster SeatInformationMasterUtility { get; private set; }
        public IMGOneDocumentScrutiny MGOneScrutinyUtility { get; private set; }
        public IGrievance GrievanceUtility { get; private set; }

        public IDepartmentOfTechnicalDocumentScrutiny DepartmentOfTechnicalScrutinyUtility { get; private set; }
        public UtilityHelper(IConfiguration configuration)
        {
            UnitOfWork = new CoreRepositories(configuration);
            InitializeUtilities();
        }
        public void InitializeUtilities()
        {
            CommonFuncationUtility = new CommonFuncation(UnitOfWork);
            ProjectMasterUtility = new ProjectMaster(UnitOfWork);
            LegalEntity = new LegalEntity(UnitOfWork);
            EmployeeLoginUtility = new EmployeeLogin(UnitOfWork);
            EmployeeDashboardUtility = new EmployeeDashboard(UnitOfWork);
            UserMasterUtility = new UserMaster(UnitOfWork);
            SSOAPIUtility = new SSOAPI(UnitOfWork);
            MenuUtility = new Menu(UnitOfWork);
            CourseMasterUtility = new CourseMaster(UnitOfWork);
            WorkFlowMasterUtility = new WorkFlowMaster(UnitOfWork);
            CollegeMasterUtility = new CollegeMaster(UnitOfWork);
            HospitalMasterUtility = new HospitalMaster(UnitOfWork);
            SMSMailUtility = new SMSMail(UnitOfWork);

            ParliamentAreaMasterUtility = new ParliamentAreaMaster(UnitOfWork);
            CommonMasterUtility = new CommonMaster(UnitOfWork);
            AssemblyAreaMasterUtility = new AssemblyAreaMaster(UnitOfWork);

            UniversityMasterUtility = new UniversityMaster(UnitOfWork);
            LandAreaSituatedMasterUtility = new LandAreaSituatedMaster(UnitOfWork);
            FacilitiesMasterUtility = new FacilitiesMaster(UnitOfWork);
            SubjectMasterUtility = new SubjectMaster(UnitOfWork);
            QualificationMasterUtility = new QualificationMaster(UnitOfWork);
            DocumentMasterUtility = new DocumentMaster(UnitOfWork);
            AddRoleMasterUtility = new AddRoleMaster(UnitOfWork);
            StaffDetailUtility = new StaffDetail(UnitOfWork);
            HostelDetailUtility = new HostelDetail(UnitOfWork);
            SocietyMasterUtility = new SocietyMaster(UnitOfWork);
            FacilityDetailsUtility = new FacilityDetails(UnitOfWork);
            AcademicInformationDetailsUtility = new AcademicInformationDetails(UnitOfWork);
            LandDetailsUtility = new LandDetails(UnitOfWork);
            RoomDetailsUtility = new RoomDetails(UnitOfWork);
            OtherInformationUtility = new OtherInformation(UnitOfWork);
            CollegeDocumentUtility = new CollegeDocument(UnitOfWork);
            OldNOCDetailUtility = new OldNOCDetail(UnitOfWork);
            BuildingDetailsMasterUtility = new BuildingDetailsMaster(UnitOfWork);
            TrusteeGeneralInfoMasterUtility = new TrusteeGeneralInfoMaster(UnitOfWork);
            CreateUserUtility = new CreateUser(UnitOfWork);
            ApplyNOCUtility = new ApplyNOC(UnitOfWork);
            PaymentUtility = new Payment(UnitOfWork);
            GeoTaggingUtility = new GeoTagging(UnitOfWork);
            CommitteeMasterUtility = new CommitteeMaster(UnitOfWork);
            MedicalDocumentScrutinyUtility = new MedicalDocumentScrutiny(UnitOfWork);
            RNCCheckListMasterUtility = new RNCCheckListMaster(UnitOfWork);
            AnimalMasterUtility = new AnimalMaster(UnitOfWork);
            StreamMasterUtility = new StreamMaster(UnitOfWork);
            StreamSubjectMaster = new  StreamSubjectMaster(UnitOfWork);
            VeterinaryHospitalUtility = new VeterinaryHospital(UnitOfWork);
            LoginMasterUtility = new LoginMaster(UnitOfWork);
            AadharServiceUtility = new AadharService(UnitOfWork);
            FarmLandDetailsUtility = new FarmLandDetails(UnitOfWork);
            AddCourseMasterUtility = new AddCourseMaster(UnitOfWork);
            ParamedicalHospitalUtility = new ParamedicalHospital(UnitOfWork);
            ClassWiseStudentDetailsUtility = new ClassWiseStudentDetails(UnitOfWork);
            AnimalDocumentScrutinyUtility = new AnimalDocumentScrutiny(UnitOfWork);
            AgricultureDocumentScrutinyUtility = new AgricultureDocumentScrutiny(UnitOfWork);
            DepartmentOfCollegeScrutinyUtility = new DepartmentOfCollegeDocumentScrutiny(UnitOfWork);
            FireQueryUtility = new FireQuery(UnitOfWork);
            StaffAttendanceUtility = new StaffAttendance(UnitOfWork);
            LOIFeeMasterUtility = new LOIFeeMaster(UnitOfWork);
            SeatInformationMasterUtility = new SeatInformationMaster(UnitOfWork);
            MGOneScrutinyUtility = new MGOneDocumentScrutiny(UnitOfWork);
            GrievanceUtility = new Grievance(UnitOfWork);
            DepartmentOfTechnicalScrutinyUtility = new DepartmentOfTechnicalDocumentScrutiny(UnitOfWork);
        }
    }
}
