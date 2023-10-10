using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class CommonFuncationDataModel
    {
        public int DrID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string RegistrationNo { get; set; }
        public string Address { get; set; }
        public string POBox { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public int CityID { get; set; }
        public string MobileNo { get; set; }
        public string EMail { get; set; }
        public bool RefDr { get; set; }

        public int DepartmentID { get; set; }
        public int SpecialistID { get; set; }


        public bool AutoMoneyReceive { get; set; }
        public bool AutoMoneyReceivePrint { get; set; }
        public int ServiceID { get; set; }

        public string Photo { get; set; }
        public string Dis_Photo { get; set; }

        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime RTS { get; set; }
        public string IPAddress { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }

    public class CommonDataModel_QualificationMasterDepartmentAndTypeWise
    {
        public int QualificationID { get; set; }
        public string QualificationName { get; set; }
        public string Type { get; set; }
    }

    public class CommonDataModel_BuildingType
    {
        public int BuildingTypeID { get; set; }
        public string BuildingTypeName { get; set; }
    }
    public class CommonDataModel_BuildingUploadDoc
    {
        public int DID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? Dis_FileName { get; set; }
        public string? SampleDocument { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsMandatory { get; set; }
    }

    //public class CommonDataModel_CommonMasterDepartmentAndTypeWise
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //    public string Code { get; set; }
    //}

    public class CommonDataModel_TermAndCondition
    {
        public int AID { get; set; }
        public int TermAndConditionID { get; set; }
        public string TermAndConditionName { get; set; }
    }
    public class CommonDataModel_Annexure
    {
        public int AID { get; set; }
        public int AnnexureID { get; set; }
        public string AnnexureName { get; set; }
        public int DepartmentID { get; set; }
        public int LandDocumentTypeID { get; set; }
        public int LandConversionID { get; set; }


    }

    public class CommonDataModel_OccupationDDL
    {
        public int OccupationID { get; set; }
        public string OccupationName { get; set; }
    }

    public class CommonDataModel_QualificationMasterDepartmentWise
    {
        public int QualificationID { get; set; }
        public string QualificationName { get; set; }
        public string Type { get; set; }
        public int IsDocCompulsory { get; set; }
        public int Orderby { get; set; }
    }

    public class CommonDataModel_CollegeWiseSubject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }

    public class CommonDataModel_FacilitesMasterDepartmentAndTypeWise
    {
        public int FID { get; set; }
        public string FacilitiesName { get; set; }
        public int MinSize { get; set; }
        public string Unit { get; set; }
        public string IsYesNoOption { get; set; }
    }
    public class CommonDataModel_DashBoard
    {
        public int TotalCollege { get; set; }
        public int TotalDraftApplication { get; set; }
        public int NOCIssued { get; set; }
        public int PendingNOC { get; set; }
        public int TotalLegalEntity { get; set; }
        public int TotalRevertApplication { get; set; }
        public int TotalApplyNocApplication { get; set; }
        public int TotalRejectApplication { get; set; }

        // Common use All Department
        public int Pending { get; set; }
        public int Revert { get; set; }
        public int Rejected { get; set; }
        public int Completed { get; set; }

        public int Clerk_Pending { get; set; }
        public int Clerk_Reverted { get; set; }
        public int Clerk_Rejected { get; set; }
        public int Clerk_Completed { get; set; }


        //secretar Counts
        public int secretary_Pending { get; set; }
        public int secretary_Completed { get; set; }
        public int secretary_Rejected { get; set; }
        public int secretary_Revert { get; set; }
        public int ScrutinyCommittee_Forward { get; set; }
        public int RegistratCommittee_Forward { get; set; }




        //Section Officer Count
        public int SectionOffs_Pending { get; set; }
        public int SectionOffs_Revert { get; set; }
        public int SectionOffs_Rejected { get; set; }
        public int SectionOffs_Completed { get; set; }


        //AssistantSecretary Count
        public int AssistantSecretary_Pending { get; set; }
        public int AssistantSecretary_Revert { get; set; }
        public int AssistantSecretary_Rejected { get; set; }
        public int AssistantSecretary_Completed { get; set; }



        //JointSecretary Pending
        public int JointSecretary_Pending { get; set; }
        public int JointSecretary_Revert { get; set; }
        public int JointSecretary_Rejected { get; set; }
        public int JointSecretary_Completed { get; set; }
        public int JointSecretary_ReleaseNOCPending { get; set; }
        public int JointSecretary_ReleaseNOC { get; set; }



        //JointSecretary Pending
        public int ScrutinyCommittee_Pending { get; set; }
        public int ScrutinyCommittee_Revert { get; set; }
        public int ScrutinyCommittee_Rejected { get; set; }
        public int ScrutinyCommittee_Completed { get; set; }

        // Registrat Committe
        public int RegistratCommittee_Pending { get; set; }
        public int RegistratCommittee_Revert { get; set; }
        public int RegistratCommittee_Rejected { get; set; }
        public int RegistratCommittee_Completed { get; set; }


        //Dec Data Modal
        public int Nodal_Pending { get; set; }
        public int Nodal_Reverted { get; set; }
        public int Nodal_Rejected { get; set; }
        public int Nodal_Completed { get; set; }

        //
        public int PVCommittee_Pending { get; set; }
        public int PVCommittee_Reverted { get; set; }
        public int PVCommittee_Rejected { get; set; }
        public int PVCommittee_Completed { get; set; }


        //Admin
        public int TotalApplication { get; set; }
        public int TotalApplicationPending { get; set; }
        public int TotalApplicationReject { get; set; }
        public int TotalApplicationCompleted { get; set; }


    }

    public class CommonDataModel_Stream
    {
        public int AID { get; set; }
        public int StreamMasterID { get; set; }
        public string StreamName { get; set; }
    }
}
