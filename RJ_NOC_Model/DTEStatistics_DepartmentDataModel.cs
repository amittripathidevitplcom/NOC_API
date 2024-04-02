using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RJ_NOC_Model
{
    public class DTEStatistics_DepartmentDataModel
    {
        public int EntryID { get; set; }
        public string? EntryDate { get; set; }
        public int Department { get; set; }
        public int CollegeID { get; set; }
        public string? SelectedCollegeEntryTypeName { get; set; }
        public int FYearID { get; set; }

        public List<DTEStatistics_Department_DepartmentDetails>? DepartmentDetails { get; set; }


        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public int ModifyBy { get; set; }
    }
    public class DTEStatistics_Department_DepartmentDetails
    {
        public string? NameofFaculty { get; set; }
        public string? NameOfDepartmentCentres { get; set; }
    }
}


