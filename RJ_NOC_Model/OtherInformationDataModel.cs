using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class OtherInformationDataModels
    {
        public DataTable data { get; set; }
    }
    public class OtherInformationDataModel
    {
        public int CollegeWiseOtherInfoID { get; set; }
        public int CollegeID { get; set; }
        public int? NewCourseID { get; set; }
        public string? NewCourseName { get; set; }
        public int CourseID { get; set; }
        public int DepartmentID { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFilePath { get; set; }
        public string? Image_Dis_FileName { get; set; }
        public string BookImageFileName { get; set; }
        public string BookImageFilePath { get; set; }
        public string? BookImage_Dis_FileName { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int NoofBooks { get; set; }
        public int NoofComputers { get; set; }
        public int UserID { get; set; }

        public string? Action { get; set; }
        public string? Remark { get; set; }
        public string? CourseName { get; set; }


        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }

        public int NoOfRooms { get; set; }

        public string? BookInvoiceFileName { get; set; }
        public string? BookInvoiceFilePath { get; set; }
        public string? BookInvoice_Dis_FileName { get; set; }



        public string? FloorAreaofLibrary { get; set; }
        public string? Professional { get; set; }
        public string? Other { get; set; }
        public string? PeriodicalsNo { get; set; }
        public string? JournalsNo { get; set; }
        public string? SeatingCapacity { get; set; }
        public string? InternetFacility { get; set; }
        public string? CounterforSale { get; set; }
        public string? ComputerPrint { get; set; }
        public string? RegistersMaintained { get; set; }
        public string? LibraryTiming { get; set; }
    }
}
