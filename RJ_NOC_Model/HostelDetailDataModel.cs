using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class HostelDataModel
    {
        public int HostelCategoryID { get; set; }
        public int HostelDetailID { get; set; }
        public string IsHostelCampus { get; set; }
        public string HostelName { get; set; }
        public string ContactPersonName { get; set; }
        public string DistanceOfCollege { get; set; }
        public string HostelType { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContactNo { get; set; }
        public string RentDocument { get; set; }
        public string? RentDocumentPath { get; set; }
        public string? RentDocument_Dis_FileName { get; set; }
        public string ContactPersonNo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
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

        public string? DivisionName { get; set; }
        public string? DistrictName { get; set; }
        public string? TehsilName { get; set; }
        public string? PanchyatSamitiName { get; set; }
        public List<HostelDetailsDataModel_Hostel> HostelDetails { get; set; }
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
