using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace RJ_NOC_Model
{
    public class GeoTaggingDataModels
    {
        public DataTable data { get; set; }
    }
    public class GeoTaggingDataModel
    {
        //public int UserID { get; set; }
        //public string LoginSSOID { get; set; }
        //public string UserName { get; set; }
        //public string Token { get; set; }
        //public string Type { get; set; }
        public string Geo_Type { get; set; } = "UpdateCollegeData";
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string? TGC_Latitude { get; set; }
        public string? TGC_Longitude { get; set; }
        public bool IsGeoTagging { get; set; }
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }

    }


    public class NotificationDataModel
    {
        public int NotificationID { get; set; }
    }
    public class InspectionGeoTaggingDataModel
    {
        public int ApplicationID { get; set; }
        public string GT_Image1 { get; set; }
        public string GT_Image2 { get; set; }
        public string GT_Latitude { get; set; }
        public string GT_Longitude { get; set; }
        public bool IsGeoTagging { get; set; }
        public int GT_CreatedBy { get; set; }

    }
}
