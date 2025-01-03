using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RJ_NOC_Model
{
    public class BuildingDetailsDataModel
    {
        public int CollegeID { get; set; }
        public int SchoolBuildingDetailsID { get; set; }
        public int BuildingTypeID { get; set; }
        public string? BuildingTypeName { get; set; }

        public string FireNOCOrderNumber { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FireNOCFileUpload { get; set; }
        public string? Dis_FireNOCFileUpload { get; set; }
        public string? FireNOCFileUploadPath { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string ExpiringOn { get; set; }
        public string PWDNOCFileUpload { get; set; }
        public string? Dis_PWDNOCFileUpload { get; set; }
        public string? PWDNOCFileUploadPath { get; set; }
        public string? OtherFileUpload { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string RuralUrban { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public int TehsilID { get; set; }
        public int PanchayatSamitiID { get; set; }
        public string CityTownVillage { get; set; }
        public int Pincode { get; set; }
        public decimal BuildingHostelQuartersRoadArea { get; set; }
        public string ContactNo { get; set; }
        public string OwnerName { get; set; }
        public string OwnBuildingOrderNo { get; set; }
        public string OwnBuildingOrderDate { get; set; }
        public string OwnBuildingFileUpload { get; set; }
        public string? Dis_OwnBuildingFileUpload { get; set; }
        public string? OwnBuildingFileUploadPath { get; set; }
        public string RentAgreementFileUpload { get; set; }
        public string? Dis_RentAgreementFileUpload { get; set; }
        public string? RentAgreementFileUploadPath { get; set; }


        public string buildingOtherDoc1FileUpload { get; set; }
        public string? Dis_buildingOtherDoc1FileUpload { get; set; }
        public string? buildingOtherDoc1FileUploadPath { get; set; }

        public string buildingOtherDoc2FileUpload { get; set; }
        public string? Dis_buildingOtherDoc2FileUpload { get; set; }
        public string? buildingOtherDoc2FileUploadPath { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public string? Action { get; set; }
        public string? Remark { get; set; }

        public string TotalProjectCost { get; set; }
        public string TotalProjectCostFileUpload { get; set; }
        public string? Dis_TotalProjectCostFileUpload { get; set; }
        public string? TotalProjectCostFileUploadPath { get; set; }
        public string SourceCostAmount { get; set; }
        public string SourceCostAmountFileUpload { get; set; }
        public string? Dis_SourceCostAmountFileUpload { get; set; }
        public string? SourceCostAmountFileUploadPath { get; set; }
        public string AmountDeposited { get; set; }
        public string AmountDepositedFileUpload { get; set; }
        public string? Dis_AmountDepositedFileUpload { get; set; }
        public string? AmountDepositedFileUploadPath { get; set; }
        public string OtherFixedAssetsAndSecurities { get; set; }
        public string OtherFixedAssetsAndSecuritiesFileUpload { get; set; }
        public string? Dis_OtherFixedAssetsAndSecuritiesFileUpload { get; set; }
        public string? OtherFixedAssetsAndSecuritiesFileUploadPath { get; set; }
        public string GATEYearBalanceSecret { get; set; }
        public string GATEYearBalanceSecretFileUpload { get; set; }
        public string? Dis_GATEYearBalanceSecretFileUpload { get; set; }
        public string? GATEYearBalanceSecretFileUploadPath { get; set; }
        public string OtherFinancialResources { get; set; }
        public string OtherFinancialResourcesFileUpload { get; set; }
        public string? Dis_OtherFinancialResourcesFileUpload { get; set; }
        public string? OtherFinancialResourcesFileUploadPath { get; set; }
        public string? MGOneIstheCampusUnitary { get; set; }
        public string? MGOneIstheCampusUnitaryName { get; set; }
        public int? Distance { get; set; }
        public string? NameoftheAuthority { get; set; }
        public string? AuthorityDateApproval { get; set; }       
        public int?ResidentialBuildingTypeID { get; set; }
        public string? MGOneResidentialIstheCampusUnitary { get; set; }
        public string? ResidentialOwnerName { get; set; }
        public string? ResidentialAddressLine1 { get; set; }
        public string? ResidentialAddressLine2 { get; set; }
        public string? ResidentialRuralUrban { get; set; }
        public string? ResidentialDistance { get; set; }
        public int? ResidentialDivisionID { get; set; }
        public int?ResidentialDistrictID { get; set; }
        public int?ResidentialTehsilID { get; set; }
        public int?ResidentialCityID { get; set; }
        public int?ResidentialPanchayatSamitiID { get; set; }
        public string? ResidentialCityTownVillage { get; set; }
        public string? ResidentialContactNo { get; set; }
        public string? ResidentialPincode { get; set; }
        public int?ResidentialBuildingHostelQuartersRoadArea { get; set; }
        public string? ResidentialRentvaliditydate { get; set; }
        public string? ResidentialbuildingOtherDoc1FileUpload { get; set; }
        public string? ResidentialDis_buildingOtherDoc1FileUpload { get; set; }
        public string? ResidentialbuildingOtherDoc1FileUploadPath { get; set; }
        public string? ResidentialbuildingOtherDoc2FileUpload{ get; set; }
        public string? ResidentialDis_buildingOtherDoc2FileUpload{ get; set; }
        public string? ResidentialbuildingOtherDoc2FileUploadPath{ get; set; }
        public string? ResidentialRentAgreementFileUpload{ get; set; }
        public string? ResidentialDis_RentAgreementFileUpload{ get; set; }
        public string? ResidentialRentAgreementFileUploadPath{ get; set; }
        public string? AuthoritybuildingOtherDoc1FileUpload{ get; set; }
        public string? AuthorityDis_buildingOtherDoc1FileUpload{ get; set; }
        public string? AuthoritybuildingOtherDoc1FileUploadPath{ get; set; }
        public string? MGOneDrainage{ get; set; }
        public string? BuildingUseNameoftheAuthority { get; set; }
        public string? BuildingUseOrderNo { get; set; }
        public string? BuildingUseDateApproval { get; set; }
        public string? buildingUseOtherDoc1FileUpload{ get; set; }
        public string?Dis_buildingUseOtherDoc1FileUpload{ get; set; }
        public string?buildingUseOtherDoc1FileUploadPath{ get; set; }
       
        public string? PollutionDateApproval { get; set; }
        public string? ValidDateApproval{ get; set; }
        public string?PollutionbuildingOtherDoc1FileUpload{ get; set; }
        public string?PollutionDis_buildingOtherDoc1FileUpload{ get; set; }
        public string? PollutionbuildingOtherDoc1FileUploadPath { get; set; }
        public string? ResidentialBuildingName { get; set; }
        public List<DocuemntBuildingDetailsDataModel> lstBuildingDocDetails { get; set; }
        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }
        public string? Rentvaliditydate { get; set; }

        public int? CityID { get; set; }
        public string? CityName { get; set; }

        public string? IsApproved { get; set; }

    }
    public class BuildingDetailsDataModelList
    {
        public DataSet data { get; set; }
    }
    public class DocuemntBuildingDetailsDataModel
    {
        public int DID { get; set; }
        public string DocumentType { get; set; }
        public string? DocumentName { get; set; }
        public string? FilePath { get; set; }
        public string FileName { get; set; }
        public string? Dis_FileName { get; set; }
        public bool Isfile { get; set; }

    }

}

