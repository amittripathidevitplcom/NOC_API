using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class DCEStaffReportsDataModel
    {
        public int DesignationID { get; set; }
        public int CollegeID { get; set; }
        public string FaculityName { get; set; }
        public string MobileNo { get; set; }
       
        public string DateOfAppointment { get; set; }
        public string DateOfJoining { get; set; }
        public decimal MonthlySalary { get; set; }

        public int NOCStatus { get; set; }
        public string DuplicateAdharID { get; set; }

        public string Gender { get; set; }
        public string TempPermanentID { get; set; }
        public string IsReserachGuideID { get; set; }
        public string PFDeductionID { get; set; }

        public int PresentCollegeStatusID { get; set; }

        public int SubjectID { get; set; }
        public string CollegeName { get; set; }

      //  public int StatusofCollegeID { get; set; }
        public string AadhaarNo { get; set; }
      //  public string ResearchGuide { get; set; }
      //  public string StaffStatus { get; set; }


    }

    public class DCEStaffReportsDataModel_list
    {
        public DataTable data { get; set; }
    }

    public class DCEStaffReports_SubjectList
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int StaffDetailID { get; set; }
        public string StaffStatus { get; set; }
        public string PFDeduction { get; set; }

        public string AadhaarNo { get; set; }

        public string ResearchGuide { get; set; }

    }
}
