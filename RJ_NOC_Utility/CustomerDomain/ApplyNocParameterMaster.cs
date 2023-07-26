using RJ_NOC_Model;
using RJ_NOC_Utility.CustomerDomain.Interface;
using RJ_NOC_DataAccess.Interface;
using Azure.Core;
using RJ_NOC_DataAccess.Common;
using System.Data;
using System.Text;

namespace RJ_NOC_Utility.CustomerDomain
{
    public class ApplyNocParameterMaster : UtilityBase, IApplyNocParameterMaster
    {
        public ApplyNocParameterMaster(IRepositories unitOfWork) : base(unitOfWork)
        {

        }

        public List<ApplyNocParameterMaster_ddl> GetApplyNocParameterMaster(int CollegeID)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocParameterMaster(CollegeID);
            List<ApplyNocParameterMaster_ddl> model = new List<ApplyNocParameterMaster_ddl>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocParameterMaster_ddl>>(dt);
            }
            return model;
        }
        public ApplyNocParameterMaster_TNOCExtensionDataModel GetApplyNocFor_TNOCExtension(int CollegeID, string ApplyNocFor)
        {
            var ds = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocForByParameter(CollegeID, ApplyNocFor);
            ApplyNocParameterMaster_TNOCExtensionDataModel model = new ApplyNocParameterMaster_TNOCExtensionDataModel();
            if (ds != null)
            {
                if (ds.Tables.Count >= 3)
                {
                    model = CommonHelper.ConvertDataTable<ApplyNocParameterMaster_TNOCExtensionDataModel>(ds.Tables[0]);
                    model.ApplyNocParameterCourseList = CommonHelper.ConvertDataTable<List<ApplyNocParameterCourseDataModel>>(ds.Tables[1]);
                    var subjectlist = CommonHelper.ConvertDataTable<List<ApplyNocParameterSubjectDataModel>>(ds.Tables[2]);
                    // map
                    model.ApplyNocParameterCourseList.ForEach(c =>
                    {
                        c.ApplyNocParameterSubjectList = subjectlist.Where(s => s.CourseID == c.CourseID)
                        .Select(sd => new ApplyNocParameterSubjectDataModel
                        {
                            ApplyNocID = sd.CourseID,
                            CourseID = sd.CourseID,
                            SubjectID = sd.SubjectID,
                            SubjectName = sd.SubjectName,
                        }).ToList();
                    });
                }
            }
            return model;
        }
        public ApplyNocParameterMaster_AdditionOfNewSeats60DataModel GetApplyNocFor_AdditionOfNewSeats60(int CollegeID, string ApplyNocFor)
        {
            var ds = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocForByParameter(CollegeID, ApplyNocFor);
            ApplyNocParameterMaster_AdditionOfNewSeats60DataModel model = new ApplyNocParameterMaster_AdditionOfNewSeats60DataModel();
            if (ds != null)
            {
                if (ds.Tables.Count >= 2)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        model = CommonHelper.ConvertDataTable<ApplyNocParameterMaster_AdditionOfNewSeats60DataModel>(ds.Tables[0]);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        model.ApplyNocParameterCourseList = CommonHelper.ConvertDataTable<List<ApplyNocParameterCourseDataModel>>(ds.Tables[1]);
                    }
                }
            }
            return model;
        }

        public bool SaveApplyNocApplication(ApplyNocParameterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@CollegeID={0},", request.CollegeID);
            sb.AppendFormat("@ApplicationTypeID={0},", request.ApplicationTypeID);
            sb.AppendFormat("@TotalFeeAmount={0},", request.TotalFeeAmount);
            sb.AppendFormat("@CreatedBy={0},", request.CreatedBy);
            sb.AppendFormat("@ModifyBy={0},", request.ModifyBy);
            sb.AppendFormat("@IPAddress='{0}',", IPAddress);
            sb.AppendFormat("@SSOID='{0}',", request.SSOID);

            // put ''value'' for child string values
            // child            
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("select * into ##ApplyNocParameterDetailList from(");
            foreach (var item in request.ApplyNocParameterMasterListDataModel.Where(x => x.IsChecked == true))
            {
                sb1.Append(" select");
                sb1.AppendFormat(" ApplyNocParameterDetailID={0},", 0);
                sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                sb1.AppendFormat(" ApplyNocParameterID={0},", item.ApplyNocID);
                sb1.AppendFormat(" ApplyNocFor=''{0}'',", item.ApplyNocFor);
                sb1.AppendFormat(" FeeAmount={0}", item.FeeAmount);
                sb1.Append(" union all");
            }
            sb1.Length = sb1.Length - 9;// remove union all
            sb1.Append(" ) as t");
            sb.AppendFormat("@ApplyNocParameterDetailList='{0}',", sb1.ToString());

            // child
            sb1 = new StringBuilder();
            sb1.Append("select * into ##ApplyNocApplicationDetailList from(");
            if (request.ApplyNocParameterMasterList_TNOCExtension != null)
            {
                foreach (var item in request.ApplyNocParameterMasterList_TNOCExtension.ApplyNocParameterCourseList.Where(x => x.IsChecked == true))
                {
                    foreach (var item1 in item.ApplyNocParameterSubjectList)
                    {
                        sb1.Append(" select");
                        sb1.AppendFormat(" ApplyNocApplicationDetailID={0},", 0);
                        sb1.AppendFormat(" ApplyNocParameterID={0},", item.ApplyNocID);
                        sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                        sb1.AppendFormat(" CourseID={0},", item.CourseID);
                        sb1.AppendFormat(" SubjectID={0},", item1.SubjectID);
                        sb1.AppendFormat(" CheckedStatus={0}", 1);
                        sb1.Append(" union all");
                    }
                }
            }
            if (request.ApplyNocParameterMasterList_AdditionOfNewSeats60 != null)
            {
                foreach (var item in request.ApplyNocParameterMasterList_AdditionOfNewSeats60.ApplyNocParameterCourseList.Where(x => x.IsChecked == true))
                {
                    sb1.Append(" select");
                    sb1.AppendFormat(" ApplyNocApplicationDetailID={0},", 0);
                    sb1.AppendFormat(" ApplyNocParameterID={0},", item.ApplyNocID);
                    sb1.AppendFormat(" ApplyNocApplicationID={0},", 0);
                    sb1.AppendFormat(" CourseID={0},", item.CourseID);
                    sb1.AppendFormat(" SubjectID={0},", 0);
                    sb1.AppendFormat(" CheckedStatus={0}", 1);
                    sb1.Append(" union all");
                }
            }
            sb1.Length = sb1.Length - 9;// remove union all  
            sb1.Append(" ) as t");

            // child
            sb1 = new StringBuilder();
            sb1.Append("select * into ##ApplyNocApplicationChangeInNameDetailList from(");
            if (request.ApplyNocParameterMasterList_ChangeInNameOfCollege != null)
            {
                sb1.Append(" select");
                sb1.AppendFormat(" ChangeInNameID={0},", 0);
                sb1.AppendFormat(" NewName_Eng=''{0}'',", request.ApplyNocParameterMasterList_ChangeInNameOfCollege.NewNameEnglish);
                sb1.AppendFormat(" NewName_Hi=''{0}'',", request.ApplyNocParameterMasterList_ChangeInNameOfCollege.NewNameHindi);
                sb1.AppendFormat(" DocumentName=''{0}''", request.ApplyNocParameterMasterList_ChangeInNameOfCollege.DocumentName);
                sb1.Append(" ) as t");
                sb.AppendFormat("@ApplyNocApplicationChangeInNameDetailList='{0}',", sb1.ToString());

            }
            // action
            sb.AppendFormat("@Action='{0}'", "SaveApplyNocApplication");
            // execute
            return UnitOfWork.ApplyNocParameterMasterRepository.SaveApplyNocApplication(sb.ToString());
        }
        public List<ApplyNocFDRDetailsDataModel> GetApplyNoc_FDRMasterByCollegeID(int CollegeID)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNoc_FDRMasterByCollegeID(CollegeID);
            List<ApplyNocFDRDetailsDataModel> model = new List<ApplyNocFDRDetailsDataModel>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocFDRDetailsDataModel>>(dt);
            }
            return model;
        }
        public bool SaveApplyNoc_FDRMasterDetail(ApplyNocFDRDetailsDataModel request)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.SaveApplyNoc_FDRMasterDetail(request);
        }
        public List<ApplyNocFDRDetailsDataModel> GetApplyNocFDRDetails(int ApplyNocFDRID, int ApplyNocID)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocFDRDetails(ApplyNocFDRID, ApplyNocID);
            List<ApplyNocFDRDetailsDataModel> model = new List<ApplyNocFDRDetailsDataModel>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocFDRDetailsDataModel>>(dt);
            }
            return model;
        }

        public List<ApplyNocApplicationDataModel> GetApplyNocApplicationList(string SSOID)
        {
            var dt = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocApplicationList(SSOID);
            List<ApplyNocApplicationDataModel> model = new List<ApplyNocApplicationDataModel>();
            if (dt != null)
            {
                model = CommonHelper.ConvertDataTable<List<ApplyNocApplicationDataModel>>(dt);
            }
            return model;
        }

        public ApplyNocApplicationDataModel GetApplyNocApplicationByApplicationID(int ApplyNocApplicationID)
        {
            var ds = UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocApplicationByApplicationID(ApplyNocApplicationID);
            ApplyNocApplicationDataModel model = new ApplyNocApplicationDataModel();
            if (ds != null && ds.Tables.Count >= 3)
            {
                // trn application
                model = CommonHelper.ConvertDataTable<ApplyNocApplicationDataModel>(ds.Tables[0]);
                // trn parameter
                model.ApplyNocApplicationParameterList = CommonHelper.ConvertDataTable<List<ApplyNocApplicationParameterDataModel>>(ds.Tables[1]);
                // trn application detail
                var trnApplicationDetail = CommonHelper.ConvertDataTable<List<ApplyNocApplicationDetailDataModel>>(ds.Tables[2]);
                // map
                model.ApplyNocApplicationParameterList.ForEach(c =>
                {
                    c.ApplyNocApplicationDetailList = trnApplicationDetail.Where(s => s.ApplyNocParameterID == c.ApplyNocParameterID)
                    .Select(sd => new ApplyNocApplicationDetailDataModel
                    {
                        ApplyNocApplicationID = sd.ApplyNocApplicationID,
                        ApplyNocParameterID = sd.ApplyNocParameterID,
                        CourseID = sd.CourseID,
                        CourseName = sd.CourseName,
                        SubjectID = sd.SubjectID,
                        SubjectName = sd.SubjectName,
                    }).ToList();
                });
            }
            return model;
        }

        public bool DeleteApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            return UnitOfWork.ApplyNocParameterMasterRepository.DeleteApplyNocApplicationByApplicationID(ApplyNocApplicationID, ModifyBy, IPAddress);
        }
        public bool FinalSubmitApplyNocApplicationByApplicationID(int ApplyNocApplicationID, int ModifyBy)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            return UnitOfWork.ApplyNocParameterMasterRepository.FinalSubmitApplyNocApplicationByApplicationID(ApplyNocApplicationID, ModifyBy, IPAddress);
        }

        public List<CommonDataModel_DataTable> GetApplyNocPaymentHistoryApplicationID(int ApplyNocApplicationID)
        {
            return UnitOfWork.ApplyNocParameterMasterRepository.GetApplyNocPaymentHistoryApplicationID(ApplyNocApplicationID);
        }
    }
}
