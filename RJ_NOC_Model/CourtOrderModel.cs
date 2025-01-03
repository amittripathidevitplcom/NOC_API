using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class CourtOrderModel
    {
        public int CourtOrderID { get; set; }
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string? OrderName { get; set; }
        public string? CourtName { get; set; }
        public string? CivilPetitionNo { get; set; }
        public string? OrderDate { get; set; }
        public string? OrderDocumentName { get; set; }
        public string? OrderDocumentNamePath { get; set; }
        public string? OrderDocumentName_DisName { get; set; }  
        public string? PetitionDocument { get; set; }
        public string? PetitionDocumentPath { get; set; }
        public string? PetitionDocument_DisName { get; set; }
        public int UserID { get; set; }
    }
    public class CourtOrderSearchFilterDataModel
    {
        public int? UserID { get; set; }
        public int? DepartmentID { get; set; }
        public int? CollegeID { get; set; }
        public int? CourtOrderID { get; set; }
    }
}
