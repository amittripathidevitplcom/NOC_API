using RJ_NOC_Model;
using RJ_NOC_DataAccess.Interface;
using System.Data;
using Newtonsoft.Json;
using RJ_NOC_DataAccess.Common;
using System.Text;


namespace RJ_NOC_DataAccess.Repository
{
    public class DefaulterCollegeRequestRepository : IDefaulterCollegeRequestRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public DefaulterCollegeRequestRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        
        public List<CommonDataModel_DataTable> GetDefaulterCollegeRequestData(DefaulterCollegeSearchFilterDataModel request)
        {
            string SqlQuery = " exec [USP_GetDefaulterCollegeRequestData] @RequestID='" + request.RequestID+ "',@DepartmentID='" + request.DepartmentID+ "',@SSOID='" + request.SSOID+ "',@ApplicationStatus='" + request.ApplicationStatus + "',@UserID='" + request.UserID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.GetDefaulterCollegeRequestData");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }
        public bool SaveData(DefaulterCollegeRequestDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("@RequestID='{0}',", request.RequestID);
            sb.AppendFormat("@SSOID='{0}',", request.SSOID);
            sb.AppendFormat("@DepartmentID='{0}',", request.DepartmentID);
            sb.AppendFormat("@EverAppliedNOC='{0}',", request.EverAppliedNOC);
            sb.AppendFormat("@IsPNOC='{0}',", request.IsPNOC);
            sb.AppendFormat("@FirstNOCDoc='{0}',", request.FirstNOCDoc);
            sb.AppendFormat("@LastNOCDoc='{0}',", request.LastNOCDoc);
            sb.AppendFormat("@LatestAffiliationDoc='{0}',", request.LatestAffiliationDoc);
            sb.AppendFormat("@ResultLastSessionDoc='{0}',", request.ResultLastSessionDoc);
            sb.AppendFormat("@LastSessionProofOfExaminationDoc='{0}',", request.LastSessionProofOfExaminationDoc);
            sb.AppendFormat("@LastApplicationNo='{0}',", request.LastApplicationNo);
            sb.AppendFormat("@LastApplicationSubmittedDate='{0}',", request.LastApplicationSubmittedDate);
            sb.AppendFormat("@CollegeName='{0}',", request.CollegeName);
            sb.AppendFormat("@CollegeNameHi=N'{0}',", request.CollegeNameHi);
            sb.AppendFormat("@CollegeEmail='{0}',", request.CollegeEmail);
            sb.AppendFormat("@CollegeMobileNo='{0}',", request.CollegeMobileNo);
            sb.AppendFormat("@DivisionID='{0}',", request.DivisionID);
            sb.AppendFormat("@DistrictID='{0}',", request.DistrictID);
            sb.AppendFormat("@UniversityID='{0}',", request.UniversityID);
            sb.AppendFormat("@CollegeTypeID='{0}',", request.CollegeTypeID);
            sb.AppendFormat("@CollegeLevelID='{0}',", request.CollegeLevelID);
            sb.AppendFormat("@EstablishmentYearID='{0}',", request.EstablishmentYearID);
            sb.AppendFormat("@CollegePresentStatusID='{0}',", request.CollegePresentStatusID);
            sb.AppendFormat("@CaseOperatedTNOCLevel='{0}',", request.CaseOperatedTNOCLevel);
            sb.AppendFormat("@LastSessionOfTNOCID='{0}',", request.LastSessionOfTNOCID);
            sb.AppendFormat("@ActiveStatus='{0}',", request.ActiveStatus);
            sb.AppendFormat("@DeleteStatus='{0}',", request.DeleteStatus);
            sb.AppendFormat("@UserID='{0}',", request.UserID);
            sb.AppendFormat("@PendingCaseNOC='{0}',", request.PendingCaseNOC);
            sb.AppendFormat("@PendingCaseDoc='{0}',", request.PendingCaseDoc);
            sb.AppendFormat("@IPAddress='{0}'", IPAddress);

            string SqlQuery = $" exec USP_Trn_College_DefaulterRequest_IU  {sb.ToString()}";

            int Rows = _commonHelper.NonQuerry(SqlQuery, "DefaulterCollegeRequest.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool DeleteData(int RequestID)
        {
            string SqlQuery = "Exec [USP_DeleteDefaulterCollegeRequest] @RequestID='" + RequestID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DefaulterCollegeRequest.DeleteData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool SaveDefaulterCollegePenalty(ApplicationPenaltyDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " exec USP_DefaulterCollegePenalty_IU";

            SqlQuery += " @PenaltyID='" + request.PenaltyID + "',";
            SqlQuery += " @RequestID='" + request.ApplyNOCID + "',";
            SqlQuery += " @Penaltyfor='" + request.Penaltyfor + "',";
            SqlQuery += " @PenaltyAmount='" + request.PenaltyAmount + "',";
            SqlQuery += " @PenaltyDoc='" + request.PenaltyDoc + "',";
            SqlQuery += " @CreatedBy='" + request.CreatedBy + "',";
            SqlQuery += " @ApproveReject='" + request.ApproveReject + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DefaulterCollege.SaveDefaulterCollegePenalty");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public List<CommonDataModel_DataTable> GetDefaulterCollegePenalty(int RequestID,int PenaltyID)
        {
            string SqlQuery = " exec USP_GetDefaulterCollegePenalty @PenaltyID='" + PenaltyID + "', @RequestID ='" + RequestID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollege.GetDefaulterCollegePenalty");

            List<CommonDataModel_DataTable> dataModels = new List<CommonDataModel_DataTable>();
            CommonDataModel_DataTable dataModel = new CommonDataModel_DataTable();
            dataModel.data = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool DeleteDefaulterCollegePenalty(int PenaltyID)
        {
            string SqlQuery = "update Trn_DefaulterCollegePenalty SET ActiveStatus=0, DeleteStatus=1,ModifyDate=getdate()   WHERE PenaltyID='" + PenaltyID + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DefaulterCollegeRequest.DeleteDefaulterCollegePenalty");
            if (Rows > 0)
                return true;
            else
                return false;
        }
        public bool IfExists(string ApplicationNo, string SubmittedDate)
        {
            string SqlQuery = "USP_IfExistsOldDefaulterCollege @ApplicationNo='" + ApplicationNo + "', @SubmittedDate='" + SubmittedDate + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.IfExists");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public List<DataTable> GetDefaulterRequestCount(int DepartmentID, int UserID)
        {
            string SqlQuery = " exec USP_GetDefaulterRequestCount @DepartmentID='" + DepartmentID + "',@UserID='" + UserID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.GetDefaulterRequestCount");
            List<DataTable> dataModels = new List<DataTable>();
            DataTable dataModel = new DataTable();
            dataModel = dataTable;
            dataModels.Add(dataModel);
            return dataModels;
        }

        public bool CompareCollegeName(string SSOID, string CollegeName)
        {
            string SqlQuery = "USP_CompareCollegeNameDefaulterRequest @SSOID='" + SSOID + "', @CollegeName='" + CollegeName + "'";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DefaulterCollegeRequest.CompareCollegeName");
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }


    }
}
