using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class HostelDataModel
    {
        public int? HostelTypeID { get; set; }
        public int HostelCategoryID { get; set; }
        public int HostelDetailID { get; set; }
        public string IsHostel { get; set; }
        public string IsHostelCampus { get; set; }
        public string HostelName { get; set; }
        public string ContactPersonName { get; set; }
        public string DistanceOfCollege { get; set; }
        public string? HostelType { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContactNo { get; set; }
        public string RentDocument { get; set; }
        public string? RentDocumentPath { get; set; }
        public string? RentDocument_Dis_FileName { get; set; }
        public string ContactPersonNo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string IsRuralUrban { get; set; }
        public int DivisionID { get; set; }
        public int DistrictID { get; set; }
        public int? TehsilID { get; set; }
        public int? PanchayatSamitiID { get; set; }
        public string CityTownVillage { get; set; }
        public int Pincode { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        
        public int CreatedBy { get; set; }
        public int ModifyBy { get; set; }

        public string?Furnished { get; set; }
        public string?Toilet{ get; set; }
        public string?Mess{ get; set; }
        public string?Hygiene{ get; set; }
        public string?Commonroom{ get; set; }
        public string?Visitor{ get; set; }
        public string? DivisionName { get; set; }
        public string? DistrictName { get; set; }
        public string? TehsilName { get; set; }
        public string? PanchyatSamitiName { get; set; }
        public List<HostelDetailsDataModel_Hostel> HostelDetails { get; set; }

        public string? Action { get; set; }
        public string? Remark { get; set; }

        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }
        public string? HostelCategory { get; set; }
        public string? HostelCategoryType { get; set; }
       
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public string? BuiltUpArea { get; set; }



        public string? OwnerShhipRentDocument { get; set; }
        public string? OwnerShhipRentDocumentPath { get; set; }
        public string? OwnerShhipRentDocument_Dis_FileName { get; set; }

        public string? BluePrintDocument { get; set; }
        public string? BluePrintDocumentPath { get; set; }
        public string? BluePrintDocument_Dis_FileName { get; set; }
        public string? DistanceCertificateDocument { get; set; }
        public string? DistanceCertificateDocumentPath { get; set; }
        public string? DistanceCertificateDocument_Dis_FileName { get; set; }

    }

    public class HostelDetailsDataModel_Hostel
    {
        public int HostelBlockDetailID { get; set; }
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public int Width { get; set; }
        public int NoOf { get; set; }
        public int Length { get; set; }
        public int StudentCapacity { get; set; }
        public string ImageFileName { get; set; }
        public string? ImageFilePath { get; set; }
        public string? Dis_FileName { get; set; }
        public string? CourseName { get; set; }
    }
}
