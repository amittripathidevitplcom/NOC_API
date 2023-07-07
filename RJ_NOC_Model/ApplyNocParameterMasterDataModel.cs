
using System.Numerics;

namespace RJ_NOC_Model
{
    public class ApplyNocParameterMasterDataModel
    {

    }
    public class ApplyNocParameterDataModel
    {
        public int ApplyNocApplicationID { get; set; }
        public int ApplyNocID { get; set; }
        public int DepartmentID { get; set; }
        public string ApplyNocFor { get; set; }
        public decimal FeeAmount { get; set; }
        public int CollegeID { get; set; }
        public string? CollegeName { get; set; }
        public int ApplicationTypeID { get; set; }
        public string? ApplicationTypeName { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public int CreatedBy { get; set; }
        public int? ApplicationStatus { get; set; }
        public int ModifyBy { get; set; }
        public string? IPAddress { get; set; }

        public List<ApplyNocParameterMasterListDataModel> ApplyNocParameterMasterListDataModel { get; set; }
        public ApplyNocParameterMaster_TNOCExtensionDataModel? ApplyNocParameterMasterList_TNOCExtension { get; set; }
        public ApplyNocParameterMaster_AdditionOfNewSeats60DataModel? ApplyNocParameterMasterList_AdditionOfNewSeats60 { get; set; }
    }
    public class ApplyNocParameterMaster_ddl
    {
        public int ApplyNocID { get; set; }
        public string ApplyNocFor { get; set; }
        public decimal FeeAmount { get; set; }
        public bool IsChecked { get; set; } = false;
    }
    public class ApplyNocParameterMasterListDataModel
    {
        public int ApplyNocID { get; set; }
        public string ApplyNocFor { get; set; }
        public decimal FeeAmount { get; set; }
        public bool IsChecked { get; set; } = false;
    }
    public class ApplyNocParameterMaster_TNOCExtensionDataModel : ApplyNocParameterMasterListDataModel
    {
        public List<ApplyNocParameterCourseDataModel> ApplyNocParameterCourseList { get; set; }
    }
    public class ApplyNocParameterCourseDataModel
    {
        public int ApplyNocID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public bool IsChecked { get; set; } = false;
        public List<ApplyNocParameterSubjectDataModel>? ApplyNocParameterSubjectList { get; set; }
    }
    public class ApplyNocParameterSubjectDataModel
    {
        public int ApplyNocID { get; set; }
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool IsChecked { get; set; } = false;
    }
    public class ApplyNocParameterMaster_AdditionOfNewSeats60DataModel : ApplyNocParameterMasterListDataModel
    {
        public List<ApplyNocParameterCourseDataModel> ApplyNocParameterCourseList { get; set; }
    }

    // application details
    public class ApplyNocApplicationListDataModel
    {
        public int ApplyNocApplicationID { get; set; }
        public int CollegeID { get; set; }
        public string? CollegeName { get; set; }
        public int ApplicationTypeID { get; set; }
        public string? ApplicationTypeName { get; set; }
        public decimal TotalFeeAmount { get; set; }

    }
}
