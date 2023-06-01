using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class ProjectMasterDataModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string EmpanelmentType { get; set; }
        public string DepartmentName { get; set; }
        public int NumberofResources { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
    }
    public class CandidateDocumentDataModel
    {
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public List<CommonDataModel_DocumentMasterList> DocumentDataList { get; set; }
        public List<ProjectMasterDataModel_CandidateInfo> CandidateInfo { get; set; }
    }

    public class ProjectMasterDataModel_CandidateInfo
    {
        public int CID { get; set; }
        public int ProjectID { get; set; }
        public string Designation { get; set; }
        public string CandidateName { get; set; }
        public string DateofJoining { get; set; }
        public string CTC { get; set; }
        public string EmailID { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
    }


    public class ProjectMaster_DocumentScrutiny_ApprovedReject
    {
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public List<CommonDataModel_EmployeeDocumentList> DocumentScrutiny_ApprovedRejectList { get; set; }
    }


    public class ProjectMasterDataModel_ProjectIPDetails
    {
        public int PIID { get; set; }
        public int ProjectID { get; set; }
        public string PINo { get; set; }
        public string TenderNo { get; set; }
        public string TenderValidUpTo { get; set; }
        public string InvoiceNo { get; set; }
        public string RefID { get; set; }
        public string PIRecievedDate { get; set; }
        public decimal PIGrossAmount { get; set; }
        public string Name { get; set; }
        public string GSTINNo { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public string CityName { get; set; }
        public string PinCode { get; set; }
        public string Address { get; set; }
        public string DocumentName { get; set; }
        public int AssignTo { get; set; }
        public int UserID { get; set; }
    }

}
