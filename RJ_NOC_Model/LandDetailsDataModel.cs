using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class LandDetailsDataModel
    {
        public int LandDetailID { get; set; }
        public int CollegeID { get; set; }
        public string CollegeName { get; set; }
        public int LandAreaID { get; set; }
        public string LandAreaSituatedName { get; set; }
        public int LandDocumentTypeID { get; set; }
        public string LandDocumentTypeName { get; set; }
        public int LandConvertedID { get; set; }
        public int LandTypeID { get; set; }
        public decimal LandArea { get; set; }
        public string KhasraNumber { get; set; }
        public string LandOwnerName { get; set; }
        public int BuildingHostelQuartersRoadArea { get; set; }
        public string LandConversionOrderDate { get; set; }
        public string AffidavitDate { get; set; }
        public string LandConversionOrderNo { get; set; }
        public string IsConvereted { get; set; }
        public int UserID { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }

        public List<CommonDataModel_BuildingUploadDoc> LandDetailDocument { get; set; }
        public List<CollegeLandTypeDetailsDataModel> CollegeLandTypeDetails { get; set; }
        public List<CollegeLandConversionDetailsDataModel> CollegeLandConversionDetails { get; set; }

        //Add by Deepak 28062023
        public string? LandTypeName { get; set; }
        public string? Code { get; set; }
        public string? Action { get; set; }
        public string? Remark { get; set; }



        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }
        public string? AreaType { get; set; }
     
    }

    //public class LandDetailDocumentDataModel:document
    //{
    //    //public int DID { get; set; }
    //    //public string DocumentName { get; set; }
    //    //public string SelectedFileName { get; set; }
    //    //public string SelectedFilePath { get; set; }
    //}

    public class CollegeLandTypeDetailsDataModel 
    {
        public int LandTypeID { get; set; }
        public string LandTypeName { get; set; }
        public decimal LandArea { get; set; }
        public string? KhasraNo { get; set; }
        public bool IsLandSelected { get; set; }

        public string? LandConversionOrderDate { get; set; }
        public string? LandConversionOrderNo { get; set; }
        public string? LandConverstionDocument { get; set; }
        public string? OtherDocument { get; set; }
        public bool? IsOtherDocument { get; set; }

        public string? Dis_FileName { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }


        public string? Dis_OtherFileName { get; set; }
        public string? FileOtherName { get; set; }
        public string? FileOtherPath { get; set; }

    }


    public class CollegeLandConversionDetailsDataModel
    {
        public int LandDetailID { get; set; }
        public int LandConversionID { get; set; }
        public string LandConversionOrderDate { get; set; }
        public string LandConversionOrderNo { get; set; }
    }
}

