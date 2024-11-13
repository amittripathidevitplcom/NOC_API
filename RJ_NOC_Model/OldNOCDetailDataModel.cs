using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ_NOC_Model
{
    public class OldNocDetailsDataModel
    {
        public int OldNocID { get; set; }
        public int CollegeID { get; set; }
        public int DepartmentID { get; set; }
        public string? CollegeName { get; set; }
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int NOCTypeID { get; set; }
        public string? NOCTypeName { get; set; }
        public int SessionYear { get; set; }
        public string? FinancialYearName { get; set; }
        public int IssuedYear { get; set; }
        public string? IssuedYearName { get; set; }
        public string? NOCNumber { get; set; }
        public string? NOCReceivedDate { get; set; }
        public string? NOCExpireDate { get; set; }
        public string? UploadNOCDoc { get; set; }
        public string? UploadNOCDocPath { get; set; }
        public string? Dis_FileName { get; set; }
        public string? Remark { get; set; }
        public string? Action { get; set; }
        public List<OldNocDetails_SubjectDataModel>? SubjectData { get; set; }

        public string? C_Action { get; set; }
        public string? C_Remark { get; set; }
        public string? S_Action { get; set; }
        public string? S_Remark { get; set; }

        public string? FirstOrderNo { get; set; }
        public string? FirstOrderDate{ get; set; }
        public string? FirstRecognitionUploadDoc{ get; set; }
        public string? FirstRecognitionUploadDocPath{ get; set; }
        public string? FirstRecognitionUploadDoc_Dis_FileName{ get; set; }
        public string? RevisedOrderNo{ get; set; }
        public string? RevisedOrderDate{ get; set; }
        public string? RevisedRecognitionUploadDoc{ get; set; }
        public string? RevisedRecognitionUploadDocPath{ get; set; }
        public string? RevisedRecognitionUploadDoc_Dis_FileName{ get; set; }
        public string? StateOrderNo{ get; set; }
        public string? StateOrderDate{ get; set; }
        public string? StateRecognitionUploadDoc{ get; set; }
        public string? StateRecognitionUploadDocPath{ get; set; }
        public string? StateRecognitionUploadDoc_Dis_FileName{ get; set; }
        public string? RevisedStateOrderNo{ get; set; }
        public string? RevisedStateOrderDate{ get; set; }
        public string? RevisedStateRecognitionUploadDoc{ get; set; }
        public string? RevisedStateRecognitionUploadDocPath{ get; set; }
        public string? RevisedStateRecognitionUploadDoc_Dis_FileName{ get; set; }
    }
    public class OldNocDetails_SubjectDataModel
    {
        public int OldNOCSubjectID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
