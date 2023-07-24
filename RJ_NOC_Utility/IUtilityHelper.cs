using System;
using System.Collections.Generic;
using System.Text;
using RJ_NOC_DataAccess.Interface;
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
        IStreamSubjectMaster StreamSubjectMaster { get; }


    }
}
