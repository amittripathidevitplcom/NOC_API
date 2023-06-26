using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RJ_NOC_Model
{
    public class BuildingDetailsDataModel
    {
        public int SchoolBuildingDetailsID { get; set; }
        public int BuildingTypeID { get; set; }
        public string? BuildingTypeName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FireNOCFileUpload { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string ExpiringOn { get; set; }
        public string PWDNOCFileUpload { get; set; }
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
        public string ContactNo { get; set; }
        public string OwnerName { get; set; }
        public string OwnBuildingOrderNo { get; set; }
        public string OwnBuildingOrderDate { get; set; }
        public string OwnBuildingFileUpload { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public List<DocuemntBuildingDetailsDataModel> lstBuildingDocDetails { get; set; }

    }
    public class BuildingDetailsDataModelList
    {
        public DataSet data { get; set; }
    }
    public class DocuemntBuildingDetailsDataModel
    {
        public int DID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public bool Isfile { get; set; }

    }

}

